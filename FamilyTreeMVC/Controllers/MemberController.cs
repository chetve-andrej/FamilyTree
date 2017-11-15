using FamilyTreeMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyTreeMVC.Controllers
{
    //Контроллер для работы с данными о членах семьи
    public class MemberController : Controller
    {
        private MembersDataManager _mdm;
        public MemberController()
        {
            Init();
        }

        //Инициализация
        private void Init()
        {
            _mdm = new MembersDataManager();
        }

        //Передача в форму создания члена семьи списка уже созданных
        public ActionResult Adding()
        {
            return View(_mdm.GetItems());
        }

        /// <summary>
        /// Создание члена
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="midleName">Отчество</param>
        /// <param name="birthDay">День рождения</param>
        /// <param name="deathDay">День смерти</param>
        /// <param name="sex">Пол</param>
        /// <param name="motherId">Идентификатор матери</param>
        /// <param name="fatherId">Идентификатор отца</param>
        /// <returns>Обновляем дерево связанности</returns>
        public ActionResult Add(string firstName,string lastName,string midleName,DateTime birthDay,DateTime? deathDay,int sex,int motherId,int fatherId)
        {
            var mbr = new Member()
            {
                SEX = sex,
                FirstName = firstName,
                LastName = lastName,
                MidleName=midleName,
                BirthDay =birthDay,
                DeathDay=deathDay,
                MotherID=motherId,
                FatherID=fatherId
            };
            int count=_mdm.Add(mbr);

            return View("FamilyTree");
        }


        /// <summary>
        /// Обновление страницы визуализации семейного дерева
        /// </summary>
        /// <returns></returns>
        public ActionResult FamilyTree()
        {
            return View();
        }
        /// <summary>
        /// Подготовка данных для формы редактирования
        /// </summary>
        /// <param name="id">Идентификатор члена семьи</param>
        /// <returns>Передаем в представление идентификатор и список созданных членов.</returns>
        public ActionResult Editing(int id)
        {            
            return View(new KeyValuePair<int,IEnumerable<Member>>(id,_mdm.GetItems()));
        }

        //Редактировани члена семьи
        public ActionResult Edit(string fid,string firstName, string lastName, string midleName, DateTime birthDay, DateTime? deathDay, int sex, int motherId, int fatherId)
        {
            EditInternal(fid,firstName,lastName,midleName,birthDay,deathDay,sex,motherId,fatherId);

            return View("FamilyTree");
        }

        //Удаление члена семьи
        public ActionResult Delete(int? fid)
        {
            
            var childrens = GetChildrens((int)fid);
            foreach (var children in childrens)
            {
                if (children.FatherID == fid) children.FatherID = 0;
                if (children.MotherID == fid) children.MotherID = 0;

                EditInternal(children);
            }
            _mdm.Remove(fid);
            return View("FamilyTree");
        }

        /// <summary>
        /// Формирование графа 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGraphJson()
        {
            var mList = _mdm.GetItems();
            FamilyGraph fg = new FamilyGraph(mList);
            var jres = new JsonResult() { Data = fg };
            return jres;

        }

        /// <summary>
        /// Получение прямых потомков по идентификатору родителя
        /// </summary>
        /// <param name="fid">Идентификатор</param>
        /// <returns></returns>
        private IEnumerable<Member> GetChildrens(int fid)
        {
            var m = _mdm.GetItems().Where(item => item.FID == fid).FirstOrDefault();
            if (m == null) return null;
            return GetChildrens(m);
        }
        /// <summary>
        /// Получение прямых потомков.
        /// </summary>
        /// <param name="m">Член семьи</param>
        /// <returns></returns>
        private IEnumerable<Member> GetChildrens(Member m)
        {
            return _mdm.GetItems().Where(item => m.SEX == 0 ? item.MotherID == m.FID : item.FatherID == m.FID);
        }
        /// <summary>
        /// Редактирование члена семьи
        /// </summary>
        /// <param name="member">Член семьи </param>
        private void EditInternal(Member member)
        {
            EditInternal(member.FID.ToString(),member.FirstName,member.LastName,member.MidleName,(DateTime)member.BirthDay,member.DeathDay,(int)member.SEX,(int)member.MotherID,(int)member.FatherID);
        }

        /// <summary>
        /// Редактирование по набору параметров.
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="midleName"></param>
        /// <param name="birthDay"></param>
        /// <param name="deathDay"></param>
        /// <param name="sex"></param>
        /// <param name="motherId"></param>
        /// <param name="fatherId"></param>
        private void EditInternal(string fid, string firstName, string lastName, string midleName, DateTime birthDay, DateTime? deathDay, int sex, int motherId, int fatherId)
        {
            int intValue;
            var mbr = new Member()
            {
                FID = Int32.TryParse(fid, out intValue) ? (int?)intValue : null,
                SEX = sex,
                FirstName = firstName,
                LastName = lastName,
                MidleName = midleName,
                BirthDay = birthDay,
                DeathDay = deathDay,
                MotherID = motherId,
                FatherID = fatherId
            };
            int count = _mdm.Update(mbr);
        }
    }
}

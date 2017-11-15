using FamilyTreeModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeMVC.Models
{
    /// <summary>
    /// Менеджер работы с данными о членах семьи
    /// </summary>
    class MembersDataManager : IFamilyData<Member>
    {
        private MembersAccessor _ma;

        public MembersDataManager()
        {
            var dp = new BLToolkit.Data.DataProvider.SQLiteDataProvider();
            _ma = MembersAccessor.CreateInstance(new BLToolkit.Data.DbManager(dp, ConfigurationManager.ConnectionStrings["ConnectionString.SQLite.localdb"].ConnectionString));
        }

        public int Add(Member item)
        {
            return _ma.Insert((int)item.SEX,item.MotherID,item.FatherID,item.FirstName,item.LastName,item.MidleName,item.BirthDay,item.DeathDay);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetItems()
        {
            return _ma.GetAll();
        }

        public List<Member> GetItems(IDictionary<string, object> paramsFilter)
        {
            throw new NotImplementedException();
        }

        public int Remove(Member item)
        {
            return _ma.Remove(item.FID);
        }

        public int Remove(int? fid)
        {
            return _ma.Remove(fid);
        }


        public int Update(Member item)
        {
            return _ma.Update(item.FID, item.SEX, item.MotherID, item.FatherID, item.FirstName, item.LastName, item.MidleName, item.BirthDay, item.DeathDay);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace FamilyTreeMVC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FamilyGraph
    {
        private Dictionary<int,FamilyNode> _nodes;
        private List<Edge> _edges;

        private Random rnd = new Random();

        public FamilyGraph(IEnumerable<Member> members)
        {
            Init(members);          
        }
        /// <summary>
        /// Инициализация графа родственных связей
        /// </summary>
        /// <param name="members">Коллекция членов семьи</param>
        private void Init(IEnumerable<Member> members)
        {
            _nodes = new Dictionary<int,FamilyNode>();
            _edges = new List<Edge>();

            foreach (var m in members)
            {
                if (m.FID == null) throw new Exception("Uncorrect nodeId");
                int id = (int)m.FID;
                _nodes.Add(id, new FamilyNode(id) {
                    label = m.FirstName + " " + m.LastName,
                    size=4.0,
                    color= "rgb("+ Convert.ToInt32(rnd.NextDouble() * 255) + ","+ Convert.ToInt32(rnd.NextDouble() * 255) + ","+ Convert.ToInt32(rnd.NextDouble() * 255) + ")",
                    y = Convert.ToInt32(m.BirthDay.Value.Year*6- 1000)
                });

                if(m.MotherID != null && m.MotherID!=0)
                _edges.Add(new Edge((int)m.MotherID,id));
                if(m.FatherID!=null && m.FatherID!=0)
                _edges.Add(new Edge((int)m.FatherID,id));
            }
            FillPosition(members);



        }
        /// <summary>
        /// Позиционирование узлов графа
        /// </summary>
        /// <param name="members">Коллекция членов семьи</param>
        private void FillPosition(IEnumerable<Member> members)
        {
            int minYear = members.Min(m => m.BirthDay.Value.Year);
            int maxYear = members.Max(m => m.BirthDay.Value.Year);
            int deltayear = 15;
            for (int dyear = minYear; dyear < maxYear; dyear += deltayear)
            {
                var mbrs = members.Where(m =>
                {
                    int birthdyear = m.BirthDay.Value.Year;
                    return birthdyear >= dyear && birthdyear < dyear + deltayear;
                }
                );
                if (mbrs.Any())
                {
                    var membersWithParents = mbrs.Where(mbpr => mbpr.FatherID != null || mbpr.MotherID != null || members.Where(mch=>mch.FatherID==mbpr.FID || mch.MotherID==mbpr.FID).Any());
                    var membersWithoutPrnt = mbrs.Where(mbpr => mbpr.FatherID == null && mbpr.MotherID == null && !members.Where(mch => mch.FatherID == mbpr.FID || mch.MotherID == mbpr.FID).Any());
                    int dx = 150;
                    int x = -membersWithParents.Count() * dx / 2+ Convert.ToInt32(rnd.NextDouble() * dx / 2 - dx / 4);
                    foreach (var m in membersWithParents)
                    {
                        _nodes[(int)m.FID].x = x;
                        x += dx+Convert.ToInt32(rnd.NextDouble()*dx/2-dx/4);
                    }
                    foreach (var m in membersWithoutPrnt)
                    {
                        _nodes[(int)m.FID].x= Convert.ToInt32(rnd.NextDouble()*2000 - 1000);
                    }

                }
            }

        }

        public List<FamilyNode> nodes { get { return _nodes.Select(n=>n.Value).ToList(); } }

        public List<Edge> edges { get { return _edges; } }

        public string GetJson()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
    /// <summary>
    /// Узел связанности
    /// </summary>
    public abstract class Node
    {
        public string label { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int id { get; set; }
        public string color { get; set; }
        public double size { get; set; }
    }
    /// <summary>
    /// Ребро связанности
    /// </summary>
    public class Edge
    {
        private int _source;
        private int _target;

        public Edge(int source,int target)
        {
            _source = source;
            _target = target;
        }
       public int source {
            get { return _source; }
            set { _source = value; }
        }
        public int target
        {
            get { return _target; }
            set { _target = value; }
        }
        public int id
        {
            get { return Convert.ToInt32(string.Format("{0}{1}",source,target)); }
        }

    }
    /// <summary>
    /// Узел родственной связанности
    /// </summary>
    public sealed class FamilyNode:Node
    {
        public FamilyNode(int id)
        {
            this.id = id;
        }
    }
}

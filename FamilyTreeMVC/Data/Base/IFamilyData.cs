using FamilyTreeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeModels.Models
{
    public interface IFamilyData<T> where T :IFamily
    {
        List<T> GetItems();
        List<T> GetItems(IDictionary<string, object> paramsFilter);
        int Update(T item);
        int Add(T item);
        int Remove(T item);
        void Commit();
    }
}

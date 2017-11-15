using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTreeMVC.Models
{
    public enum Sex
    {
        Female,
        Male
    }

    public class Member:IFamily
    {
        public int? FID;
        public int? SEX;
        public int? MotherID;
        public int? FatherID;
        public string FirstName;
        public string LastName;
        public string MidleName;
        public DateTime? BirthDay;
        public DateTime? DeathDay;
    }
}
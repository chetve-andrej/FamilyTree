using BLToolkit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyTreeMVC.Models
{
    public abstract class MembersAccessor: DataAccessor<Member,MembersAccessor> 
    {
        [SqlQuery("SELECT * FROM Members")]
        public abstract List<Member> GetAll();

        [SqlQuery("INSERT INTO Members (SEX,MotherId,FatherId,FirstName,LastName,MidleName,BirthDay,DeathDay) VALUES(@SEX,@MotherId,@FatherId,@FirstName,@LastName,@MidleName,@BirthDay,@DeathDay)")]
        public abstract int Insert(int? SEX, int? MotherID, int? FatherID, string FirstName, string LastName, string MidleName, DateTime? BirthDay, DateTime? DeathDay);

        [SqlQuery("UPDATE Members Set SEX=@SEX,MotherID=@MotherID,FatherID=@FatherID,FirstName=@FirstName,LastName=@LastName,MidleName=@MidleName,BirthDay=@BirthDay,DeathDay=@DeathDay where FID=@FID")]
        public abstract int Update(int? FID, int? SEX, int? MotherID, int? FatherID, string FirstName, string LastName, string MidleName, DateTime? BirthDay, DateTime? DeathDay);

        [SqlQuery("DELETE FROM Members WHERE FID=@FID")]
        public abstract int Remove(int? FID);

    }
}

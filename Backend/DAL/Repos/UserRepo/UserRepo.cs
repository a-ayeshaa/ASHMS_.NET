using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.UserRepo
{
    internal class UserRepo:IRepo<User,int,User>
    {
        ASHMS_Context db;
        public UserRepo()
        {
            db = new ASHMS_Context();
        }
        public User Add(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int username)
        {
            var data = db.Users.Find(username);
            db.Users.Remove(data);
            return db.SaveChanges() > 0;
        }

        public User Get(int username)
        {
            return db.Users.Find(username);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Update(User obj)
        {
            var dbobj = db.Users.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


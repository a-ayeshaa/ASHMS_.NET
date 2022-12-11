using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.AdminRepo
{
    internal class AccountRepo : Repo, IRepo<Account, int, Account>
    {
        public Account Add(Account obj)
        {
            db.Accounts.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Accounts.Find(id);
            db.Accounts.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public List<Account> Get()
        {
            return db.Accounts.ToList();
        }

        public bool Update(Account obj)
        {
            var dbobj = db.Accounts.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.PatientRepo
{
    internal class Test_TransactionRepo:Repo,IRepo<Test_Transaction,int,Test_Transaction>
    {
        public Test_Transaction Add(Test_Transaction obj)
        {
            db.Test_Transactions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Test_Transactions.Find(id);
            db.Test_Transactions.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Test_Transaction Get(int id)
        {
            return db.Test_Transactions.Find(id);
        }

        public List<Test_Transaction> Get()
        {
            return db.Test_Transactions.ToList();
        }

        public bool Update(Test_Transaction obj)
        {
            var dbobj = db.Test_Transactions.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.PatientRepo
{
    internal class TestTransactionRepo:Repo,IRepo<TestTransaction,int,TestTransaction>
    {
        public TestTransaction Add(TestTransaction obj)
        {
            db.TestTransactions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.TestTransactions.Find(id);
            db.TestTransactions.Remove(data);
            return db.SaveChanges() > 0;
        }

        public TestTransaction Get(int id)
        {
            return db.TestTransactions.Find(id);
        }

        public List<TestTransaction> Get()
        {
            return db.TestTransactions.ToList();
        }

        public bool Update(TestTransaction obj)
        {
            var dbobj = db.TestTransactions.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


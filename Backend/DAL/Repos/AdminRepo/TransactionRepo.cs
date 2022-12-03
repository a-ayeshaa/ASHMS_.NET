using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.AdminRepo
{
    internal class TransactionRepo : IRepo<Transaction, int, Transaction>
    {

        ASHMS_Context db;
        public TransactionRepo()
        {
            db = new ASHMS_Context(); 
        }
        public Transaction Add(Transaction obj)
        {
            db.Transactions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Transactions.Find(id);
            db.Transactions.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public List<Transaction> Get()
        {
            return db.Transactions.ToList();
        }

        public bool Update(Transaction obj)
        {
            var dbobj = db.Transactions.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

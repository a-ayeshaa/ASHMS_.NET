using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.PatientRepo
{
    internal class TestCartRepo:Repo,IRepo<TestCart,int,TestCart>
    {
        public TestCart Add(TestCart obj)
        {
            db.TestCarts.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.TestCarts.Find(id);
            db.TestCarts.Remove(data);
            return db.SaveChanges() > 0;
        }

        public TestCart Get(int id)
        {
            return db.TestCarts.Find(id);
        }

        public List<TestCart> Get()
        {
            return db.TestCarts.ToList();
        }

        public bool Update(TestCart obj)
        {
            var dbobj = db.TestCarts.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


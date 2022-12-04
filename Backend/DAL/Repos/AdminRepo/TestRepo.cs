
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.AdminRepo
{
    internal class TestRepo:Repo,IRepo<Test,int,Test>
    {

        public Test Add(Test obj)
        {
            db.Tests.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Tests.Find(id);
            db.Tests.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Test Get(int id)
        {
            return db.Tests.Find(id);
        }

        public List<Test> Get()
        {
            return db.Tests.ToList();
        }

        public bool Update(Test obj)
        {
            var dbobj = db.Tests.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

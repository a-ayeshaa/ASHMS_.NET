using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.AdminRepo
{
    internal class MedicineRepo:Repo, IRepo<Medicine, int, Medicine>
    {
        public Medicine Add(Medicine obj)
        {
            db.Medicines.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Medicines.Find(id);
            db.Medicines.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Medicine Get(int id)
        {
            return db.Medicines.Find(id);
        }

        public List<Medicine> Get()
        {
            return db.Medicines.ToList();
        }

        public bool Update(Medicine obj)
        {
            var dbobj = db.Medicines.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


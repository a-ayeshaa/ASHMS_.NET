using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.DoctorRepo
{
    internal class PrescriptionRepo: Repo, IRepo<Prescription,int,Prescription>
    {
        public Prescription Add(Prescription obj)
        {
            db.Prescriptions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Prescription Get(int id)
        {
            return db.Prescriptions.Find(id);
        }

        public List<Prescription> Get()
        {
            return db.Prescriptions.ToList();
        }

        public bool Update(Prescription obj)
        {
            var dbobj = db.Prescriptions.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}

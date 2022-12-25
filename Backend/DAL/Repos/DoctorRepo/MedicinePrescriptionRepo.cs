using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.DoctorRepo
{
    internal class MedicinePrescriptionRepo:Repo, IRepo<MedicinePrescription,int,MedicinePrescription>
    {
        public MedicinePrescription Add(MedicinePrescription obj)
        {
            db.MedicinePrescriptions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.MedicinePrescriptions.Find(id);
            db.MedicinePrescriptions.Remove(data);
            return db.SaveChanges() > 0;
        }

        public MedicinePrescription Get(int id)
        {
            return db.MedicinePrescriptions.Find(id);
        }

        public List<MedicinePrescription> Get()
        {
            return db.MedicinePrescriptions.ToList();
        }

        public bool Update(MedicinePrescription obj)
        {
            var dbobj = db.MedicinePrescriptions.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

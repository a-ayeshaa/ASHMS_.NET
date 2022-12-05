using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.DoctorRepo
{
    internal class AppointmentRepo : Repo, IRepo<Appointment, int, Appointment>
    {
        public Appointment Add(Appointment obj)
        {
            db.Appointments.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var data = db.Appointments.Find(id);
            db.Appointments.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Appointment Get(int id)
        {
            return db.Appointments.Find(id);
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public bool Update(Appointment obj)
        {
            var dbobj = db.Appointments.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

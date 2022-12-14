using AutoMapper;
using BLL.DTO;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.DoctorDTOS;

namespace BLL.Services.DoctorServices
{
    public class DoctorServices
    {
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var Doctor = mapper.Map<DoctorDTO>(data);
            return Doctor;
        }

        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var Patients = mapper.Map<List<DoctorDTO>>(data);
            return Patients;
        }

        public static DoctorDTO Add(DoctorDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Doctor>(obj);
            var data = DataAccessFactory.DoctorDataAccess().Add(newobj);
            return mapper.Map<DoctorDTO>(data);

        }

        public static bool Delete(int id)
        {
            var doctor = DataAccessFactory.DoctorDataAccess().Get(id);

            if(DataAccessFactory.DoctorDataAccess().Delete(doctor.Id))
            {
                return DataAccessFactory.UserDataAccess().Delete(doctor.UserId);                
            }
            else
            {
                return false;
            }
        }

        public static bool Update(DoctorDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Doctor>(obj);
            var data = DataAccessFactory.DoctorDataAccess().Update(newobj);
            return data;
        }
        public static void netEarnings()
        {
            var data = Get();
            
            foreach(var item in data)
            {
                var fees = (from i in AppointmentServices.Get()
                            where item.Id == i.Doctor_Id && i.status == "Complete"
                            select i).ToList();
                item.Net_Earnings = item.Appointment_Fees * fees.Count;
                Update(item);
            }
        }
        public static DoctorDTO getId(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var doc = (from i in data
                       where i.UserId == id
                       select i).SingleOrDefault();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<DoctorDTO>(doc);


            return newobj;
        }
    }
}

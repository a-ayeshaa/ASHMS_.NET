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

        public static DoctorDTO Update(DoctorDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Doctor, DoctorDTO>();
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Doctor>(obj);
            var data = DataAccessFactory.DoctorDataAccess().Update(newobj);
            return mapper.Map<DoctorDTO>(data);
        }
    }
}

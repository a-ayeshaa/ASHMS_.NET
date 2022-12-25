using AutoMapper;
using BLL.DTO.DoctorDTOS;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorServices
{
    public class PrescriptionServices
    {
        public static PrescriptionDTO Get(int id)
        {
            var data = DataAccessFactory.PrescriptionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var Prescription = mapper.Map<PrescriptionDTO>(data);
            return Prescription;
        }

        public static List<PrescriptionDTO> Get()
        {
            var data = DataAccessFactory.PrescriptionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var Patients = mapper.Map<List<PrescriptionDTO>>(data);
            return Patients;
        }

        public static PrescriptionDTO Add(PrescriptionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Prescription, PrescriptionDTO>();
                c.CreateMap<PrescriptionDTO, Prescription>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Prescription>(obj);
            var data = DataAccessFactory.PrescriptionDataAccess().Add(newobj);
            return mapper.Map<PrescriptionDTO>(data);

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.PrescriptionDataAccess().Get(id);

           
            return DataAccessFactory.PrescriptionDataAccess().Delete(data.Id);
            
        }

        public static bool Update(PrescriptionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Prescription, PrescriptionDTO>();
                c.CreateMap<PrescriptionDTO, Prescription>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Prescription>(obj);
            var data = DataAccessFactory.PrescriptionDataAccess().Update(newobj);
            return data;
        }
        public static PrescriptionDTO GetWithAppointment(int aid)
        {
            var data = DataAccessFactory.PrescriptionDataAccess().Get();

            var prescription = (from i in data
                                where i.Appointment_Id == aid
                                select i).SingleOrDefault();

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var Prescription = mapper.Map<PrescriptionDTO>(prescription);
            return Prescription;
        }
    }
}

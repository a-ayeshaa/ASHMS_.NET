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
    public class MedicinePrescriptionServices
    {
        public static MedicinePrescriptionDTO Get(int id)
        {
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var MedicinePrescription = mapper.Map<MedicinePrescriptionDTO>(data);
            return MedicinePrescription;
        }

        public static List<MedicinePrescriptionDTO> Get()
        {
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var Patients = mapper.Map<List<MedicinePrescriptionDTO>>(data);
            return Patients;
        }

        public static MedicinePrescriptionDTO Add(MedicinePrescriptionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
                c.CreateMap<MedicinePrescriptionDTO, MedicinePrescription>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<MedicinePrescription>(obj);
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Add(newobj);
            return mapper.Map<MedicinePrescriptionDTO>(data);

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Get(id);


            return DataAccessFactory.MedicinePrescriptionDataAccess().Delete(data.Id);

        }

        public static bool Update(MedicinePrescriptionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
                c.CreateMap<MedicinePrescriptionDTO, MedicinePrescription>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<MedicinePrescription>(obj);
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Update(newobj);
            return data;
        }
        //public static MedicinePrescriptionDTO GetWithAppointment(int aid)
        //{
        //    var data = DataAccessFactory.MedicinePrescriptionDataAccess().Get();

        //    var prescription = (from i in data
        //                        where i.Appointment_Id == aid
        //                        select i).SingleOrDefault();

        //    var config = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
        //    });
        //    var mapper = new Mapper(config);
        //    var MedicinePrescription = mapper.Map<MedicinePrescriptionDTO>(prescription);
        //    return MedicinePrescription;
        //}
    }
}

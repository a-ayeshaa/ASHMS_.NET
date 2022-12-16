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
    public class AppointmentServices
    {
        public static AppointmentDTO Get(int id)
        {
            var data = DataAccessFactory.AppointmentDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            var Appointment = mapper.Map<AppointmentDTO>(data);
            return Appointment;
        }

        public static List<AppointmentDTO> Get()
        {
            var data = DataAccessFactory.AppointmentDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            //changes to be done here
            var Appointments = mapper.Map<List<AppointmentDTO>>(data);
            return Appointments;
        }

        public static AppointmentDTO Add(AppointmentDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentDTO>();
                c.CreateMap<AppointmentDTO, Appointment>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Appointment>(obj);
            var data = DataAccessFactory.AppointmentDataAccess().Add(newobj);
            return mapper.Map<AppointmentDTO>(data);

        }

        public static bool Delete(int id)
        {
            var appointment = DataAccessFactory.AppointmentDataAccess().Get(id);

            
            return DataAccessFactory.AppointmentDataAccess().Delete(id);
            
        }

        public static bool Update(AppointmentDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentDTO>();
                c.CreateMap<AppointmentDTO, Appointment>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Appointment>(obj);
            var data = DataAccessFactory.AppointmentDataAccess().Update(newobj);
            return data;
        }
    }
}

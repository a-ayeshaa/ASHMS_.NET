using AutoMapper;
using BLL.DTO.DoctorDTOS;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorServices
{
    public class AppointmentPrescriptionServices
    {
        public static AppointmentPrescriptionDTO GetAppointmentPrescription(int id)
        {
            var app = DataAccessFactory.AppointmentDataAccess().Get(id);
            var data = app.Prescription[0];
            var med = data.MedicinePrescriptions;
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentPrescriptionDTO>();
                c.CreateMap<Prescription, PrescriptionDTO>();
                //c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var obj= mapper.Map<AppointmentPrescriptionDTO>(app);
            return obj;
        }

        public static AppointmentPrescriptionDTO GetAppointmentPrescriptionMed(int id)
        {
            var app = DataAccessFactory.AppointmentDataAccess().Get(id);
            var data = app.Prescription[0];
            var med = data.MedicinePrescriptions;
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Appointment, AppointmentPrescriptionDTO>();
                c.CreateMap<Prescription, PrescriptionDTO>();
                //c.CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var obj = mapper.Map<AppointmentPrescriptionDTO>(app);
            
            return obj;
        }
    }
}

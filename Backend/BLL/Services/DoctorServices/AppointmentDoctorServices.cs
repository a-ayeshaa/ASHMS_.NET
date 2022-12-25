using AutoMapper;
using BLL.DTO.DoctorDTOS;
using BLL.DTO.PatientDTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorServices
{
    public class AppointmentDoctorServices
    {
        public static DoctorAppointmentDTO DoctorAppoinments(int id)
        {
            var doctor = DataAccessFactory.DoctorDataAccess().Get(id);
            var app = doctor.Appointments;
            var patient = doctor.Appointments[0].Patient;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorAppointmentDTO>();
                c.CreateMap<Appointment, AppointmentPatientDTO>();
                c.CreateMap<Patient, PatientDTO>();

            });
            var mapper = new Mapper(cfg);
            var obj = mapper.Map<DoctorAppointmentDTO>(doctor);



            foreach (var item in obj.Appointments)
            {
                var p = (from i in obj.Appointments
                         where i.Patient_Id == item.Patient_Id && i.status.Equals("Complete")
                         select i).ToList();
                item.revisit_count = p.Count;
                AppointmentServices.Update(item);
            }

            return obj;
        }
        //public static PatientAppointmentDTO PatientAppointments(DoctorAppointmentDTO data)
        //{

        //    //var patient = DataAccessFactory.PatientDataAccess().Get();
        //    var cfg = new MapperConfiguration(c => {
        //        c.CreateMap<Patient, PatientAppointmentDTO>();
        //        c.CreateMap<Appointment, AppointmentDTO>();
        //        //c.CreateMap<Patient, PatientDTO>();

        //    });
        //    var mapper = new Mapper(cfg);
        //    var obj = mapper.Map<PatientAppointmentDTO>(data.Appointments);

        //    //foreach (var item in data.Appointments)
        //    //{
        //    //    var p = (from i in obj.Appointments
        //    //             where i.Patient_Id == item.Patient_Id
        //    //             select i).ToList();
        //    //}

        //    return obj;

        //}

        public static List<AppointmentDoctorDTO> AppointmentDoctors()
        {
            var doctor = DataAccessFactory.AppointmentDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Appointment, AppointmentDoctorDTO>();
                c.CreateMap<Doctor, DoctorDTO>();

            });
            var mapper = new Mapper(cfg);
            var obj = mapper.Map<List<AppointmentDoctorDTO>>(doctor);



           
            return obj;
        }

    }
}

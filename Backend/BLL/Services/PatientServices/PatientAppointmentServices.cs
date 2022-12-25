using BLL.DTO.DoctorDTOS;
using BLL.DTO.PatientDTOs;
using BLL.Services.DoctorServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services.PatientServices
{
    public class PatientAppointmentServices
    {
        public static Days GetAppointments(int id)
        {
            var data = AppointmentDoctorServices.DoctorAppoinments(id);
            //DateTime d = new List<DateTime>();
            var days = new Days();
            foreach (var date in data.Appointments)
            {
                if(date.startedAt.DayOfWeek==DayOfWeek.Sunday)
                {
                    days.Sunday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Monday)
                {
                    days.Monday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Tuesday)
                {
                    days.Tuesday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Wednesday)
                {
                    days.Wednesday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Thursday)
                {
                    days.Thursday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Friday)
                {
                    days.Friday++;
                }
                if (date.startedAt.DayOfWeek == DayOfWeek.Saturday)
                {
                    days.Saturday++;
                }
            }
            return days;
        }

        public static List<AppointmentDoctorDTO> GetAppointment(int id)
        {
            var data = AppointmentDoctorServices.AppointmentDoctors();
            var patient = (from i in data
                           where i.Patient_Id == id
                           select i).ToList();
            return patient;
        }
    }
}

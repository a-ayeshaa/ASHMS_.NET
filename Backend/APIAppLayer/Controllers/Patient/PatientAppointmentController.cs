using APIAppLayer.AuthFilter;
using BLL.DTO.DoctorDTOS;
using BLL.Services.DoctorServices;
using BLL.Services.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers.Patient
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class PatientAppointmentController : ApiController
    {

        [Route("api/patient/appointment/book")]
        [HttpPost]
        public HttpResponseMessage BookAppointment(AppointmentDTO data)
        {
            try
            {
                var d = AppointmentServices.Add(data);
                return Request.CreateResponse(HttpStatusCode.OK, d);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patient/appointment/all")]
        [HttpGet]
        public HttpResponseMessage GetAppointment()
        {
            try
            {
                var d = PatientServices.GetPatientUser(Request.Headers.Authorization.ToString());
                var data = PatientAppointmentServices.GetAppointment(d.PatientDTO.Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}

using APIAppLayer.AuthFilter;
using BLL.DTO.DoctorDTOS;
using BLL.DTO.UserDTOs;
using BLL.Services.DoctorServices;
using BLL.Services.PatientServices;
using BLL.Services.UserServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace APIAppLayer.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]

    public class DoctorController : ApiController
    {
        [Route("api/doctors")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                DoctorServices.netEarnings();
                var data = DoctorServices.Get();
                
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = DoctorServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]CompositeObject json)
        {
            try
            {
                UserDTO user = json.User;
                DoctorDTO doc = json.Doctor;

                if (user != null && doc!= null)
                {
                    var userData = UserServices.Add(user);
                    var doctorData = DoctorServices.Add(doc);

                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = DoctorServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/doctors/update")]
        [HttpPost]
        public HttpResponseMessage Update(DoctorDTO doctor)
        {
            try
            {
                var data = DoctorServices.Update(doctor);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/doctor/appointments")]
        [HttpGet]
        public HttpResponseMessage GetAppointments()
        {
            try
            {
                var user = TokenServices.Get(Request.Headers.Authorization.ToString());
                var doctor = DoctorServices.getId(user.User_Id);
                var data = AppointmentDoctorServices.DoctorAppoinments(doctor.Id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/doctor/appointments/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAppointments(int id)
        {
            try
            {
                var user = TokenServices.Get(Request.Headers.Authorization.ToString());
                var doctor = DoctorServices.getId(user.User_Id);
                var data = AppointmentDoctorServices.DoctorAppoinments(doctor.Id);

                var appointment = (from i in data.Appointments
                                   where i.Id == id
                                   select i).SingleOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, appointment);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }


    }
}

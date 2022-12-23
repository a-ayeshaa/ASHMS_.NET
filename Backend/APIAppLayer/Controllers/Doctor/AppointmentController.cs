using APIAppLayer.AuthFilter;
using BLL.DTO.DoctorDTOS;
using BLL.DTO.UserDTOs;
using BLL.Services.DoctorServices;
using BLL.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers.Doctor
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class AppointmentController : ApiController
    {
        [Route("api/appointments")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                
                var data = AppointmentServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/appointments/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AppointmentServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/appointments/add")]
        [HttpPost]
        public HttpResponseMessage Add(AppointmentDTO obj)
        {
            try
            {
                //AppointmentDTO user = json.;
                //DoctorDTO doc = json.Doctor;

                if (obj != null)
                {
                    //var userData = UserServices.Add(user);
                    var doctorData = AppointmentServices.Add(obj);

                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/appointments/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AppointmentServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/appointments/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(int id, AppointmentDTO doctor)
        {
            try
            {
                doctor.Id = id;
                var data = AppointmentServices.Update(doctor);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}

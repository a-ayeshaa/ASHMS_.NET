using APIAppLayer.AuthFilter;
using BLL.DTO.DoctorDTOS;
using BLL.Services.DoctorServices;
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
    public class PrescriptionController : ApiController
    {
        [Route("api/prescriptions")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {

                var data = PrescriptionServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/prescriptions/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PrescriptionServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/prescriptions/add")]
        [HttpPost]
        public HttpResponseMessage Add(PrescriptionDTO obj)
        {
            try
            {
                //PrescriptionDTO user = json.;
                //DoctorDTO doc = json.Doctor;

                if (obj != null)
                {
                    //var userData = UserServices.Add(user);
                    var Data = PrescriptionServices.Add(obj);

                    return Request.CreateResponse(HttpStatusCode.OK, Data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/prescriptions/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PrescriptionServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/prescriptions/update")]
        [HttpPost]
        public HttpResponseMessage Update(PrescriptionDTO doctor)
        {
            try
            {
                var data = PrescriptionServices.Update(doctor);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/prescriptions/appointment/{aid}")]
        [HttpGet]
        public HttpResponseMessage GetWithAppointment(int aid)
        {
            try
            {
                var data = PrescriptionServices.GetWithAppointment(aid);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}

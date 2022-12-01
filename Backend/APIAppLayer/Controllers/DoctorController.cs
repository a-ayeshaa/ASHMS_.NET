using BLL.DTO.DoctorDTOS;
using BLL.Services.DoctorServices;
using BLL.Services.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAppLayer.Controllers
{
    public class DoctorController : ApiController
    {
        [Route("api/doctors")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
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
        public HttpResponseMessage Add(DoctorDTO doctor)
        {
            try
            {
                var data = DoctorServices.Add(doctor);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}

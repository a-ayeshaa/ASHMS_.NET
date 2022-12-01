using BLL.Services.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAppLayer.Controllers
{
    public class PatientController : ApiController
    {
        [Route("api/patients")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PatientServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patients/add")]
        [HttpGet]
        public HttpResponseMessage Add()
        {
            try
            {
                var data = PatientServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}

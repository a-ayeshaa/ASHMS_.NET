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

    }
}

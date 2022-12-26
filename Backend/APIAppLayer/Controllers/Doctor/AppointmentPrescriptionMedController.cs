using APIAppLayer.AuthFilter;
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
    public class AppointmentPrescriptionMedController : ApiController
    {
        [Route("api/prescription/med/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PrescriptionPresMedicineServices.medicinePrescriptions(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}

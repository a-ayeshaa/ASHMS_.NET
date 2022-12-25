using APIAppLayer.AuthFilter;
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
    public class PatientPrescriptionController : ApiController
    {
        [Route("api/patient/{id}/prescription")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AppointmentPrescriptionServices.GetAppointmentPrescription(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}

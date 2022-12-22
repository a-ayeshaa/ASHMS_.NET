using APIAppLayer.AuthFilter;
using BLL.Services.PatientServices;
using BLL.Services.UserServices;
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
    public class TestCart_TestController : ApiController
    {
        [Route("api/patient/testcarts")]
        [HttpGet]
        public HttpResponseMessage GetTestCart()
        {
            try
            {
                var token = TokenServices.Get(Request.Headers.Authorization.ToString());
                var patient_id = PatientUserServices.GetwithPatient(token.User_Id).PatientDTO.Id;
                //var data = Paitent_TestCartServices.GetwithPatientandTest(patient_id);
                var data = Patient_TestCartServices.GetwithPatientTest(patient_id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patient/testcarts/total")]
        [HttpGet]
        public HttpResponseMessage GetTotal()
        {
            try
            {
                var token = TokenServices.Get(Request.Headers.Authorization.ToString());
                var patient_id = PatientUserServices.GetwithPatient(token.User_Id).PatientDTO.Id;
                //var data = Paitent_TestCartServices.GetwithPatientandTest(patient_id);
                var data = Patient_TestCartServices.GetTotal(patient_id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}

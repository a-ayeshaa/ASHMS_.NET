using APIAppLayer.AuthFilter;
using BLL.DTO.PatientDTOs;
using BLL.Services.DoctorServices;
using BLL.Services.PatientServices;
using BLL.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers.Patient
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class PatientController : ApiController
    {
        //PATIENTS
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
        [Route("api/patients/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PatientServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patients/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PatientServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patients/add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]CompositeObject data)
        {
            try
            {
                var user = data.User;
                var patient = data.Patient;
                if (user != null && patient != null)
                {
                    var userData = UserServices.Add(user);
                    patient.UserId = userData.Id;
                    patient.RegisteredAt=DateTime.Now;

                    var patientData = PatientServices.Add(patient);

                    return Request.CreateResponse(HttpStatusCode.OK, patientData);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR OCCURED");

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/patients/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(int id,PatientDTO data)
        {
            try
            {
                data.Id = id;
                var obj = PatientServices.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, obj);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/patient/details")]
        [HttpGet]
        public HttpResponseMessage PatientDetails()
        {
            try
            {
                
                var user = TokenServices.Get(Request.Headers.Authorization.ToString());
                var patient = PatientUserServices.GetwithPatient(user.User_Id);
                return Request.CreateResponse(HttpStatusCode.OK, patient);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}

using APIAppLayer.AuthFilter;
using BLL.DTO.PatientDTOs;
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
    public class TestTransactionController : ApiController
    {
        [Route("api/testtransactions")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TestTransactionServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/testtransactions/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TestTransactionServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/testtransactions/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = TestTransactionServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/testtransactions/add")]
        [HttpGet]
        public HttpResponseMessage Add()
        {
            try
            {
                var token = TokenServices.Get(Request.Headers.Authorization.ToString());
                var patient_id = PatientUserServices.GetwithPatient(token.User_Id).PatientDTO.Id;
                var testtransactionData = TestTransactionServices.Add(patient_id);
                return Request.CreateResponse(HttpStatusCode.OK, testtransactionData);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/testtransactions/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(int id, TestTransactionDTO data)
        {
            try
            {
                data.Id = id;
                var obj = TestTransactionServices.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, obj);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/testtransaction/patient")]
        [HttpGet]
        public HttpResponseMessage GetwithPatient()
        {
            try
            {
                var patient = PatientServices.GetPatientUser(Request.Headers.Authorization.ToString());
                //var data = TestTransactionServices.GetwithPatient(patient.PatientDTO.Id);
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}


using BLL.DTO.PatientDTOs;
using BLL.Services.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAppLayer.Controllers.Patient
{
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

        [Route("api/testtransactions/add/{patient_id}")]
        [HttpPost]
        public HttpResponseMessage Add(int patient_id,TestTransactionDTO data)
        {
            try
            {
                var testtransactionData = TestTransactionServices.Add(data,patient_id);
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

    }
}


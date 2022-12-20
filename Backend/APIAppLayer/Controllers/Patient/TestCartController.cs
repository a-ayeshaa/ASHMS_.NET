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
    public class TestCartController : ApiController
    {
        [Route("api/testcarts")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TestCartServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/testcarts/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TestCartServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/testcarts/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = TestCartServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/testcarts/add")]
        [HttpPost]
        public HttpResponseMessage Add(TestCartDTO data)
        {
            try
            {
                var token = TokenServices.Get(Request.Headers.Authorization.ToString());
                data.Patient_Id = PatientUserServices.GetwithPatient(token.User_Id).PatientDTO.Id;
                var testcartData = TestCartServices.Add(data);
                return Request.CreateResponse(HttpStatusCode.OK, testcartData);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/testcarts/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(int id, TestCartDTO data)
        {
            try
            {
                data.Id = id;
                var obj = TestCartServices.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, obj);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}

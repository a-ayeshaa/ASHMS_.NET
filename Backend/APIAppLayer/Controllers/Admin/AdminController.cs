using APIAppLayer.AuthFilter;
using BLL.DTO.AdminDTOs;
using BLL.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class AdminController : ApiController
    {
        [Route("api/tests")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {

                var data = TestServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/tests/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TestServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/tests/add")]
        [HttpPost]
        public HttpResponseMessage Add(TestDTO obj)
        {
            try
            {
                if (obj != null)
                {
                    var doctorData = TestServices.Add(obj);

                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/tests/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = TestServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/tests/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(TestDTO test,int id)
        {
            try
            {
                test.Id= id;
                var data = TestServices.Update(test);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}

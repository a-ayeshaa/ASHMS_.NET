using APIAppLayer.AuthFilter;
using BLL.DTO.UserDTOs;
using BLL.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers.Admin
{
        [EnableCors("*", "*", "*")]
        //[Logged]
        public class TransactionController : ApiController
        {
            [Route("api/Transaction")]
            [HttpGet]
            public HttpResponseMessage Get()
            {
                try
                {

                    var data = TransactionService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/Transaction/{id}")]
            [HttpGet]
            public HttpResponseMessage Get(int id)
            {
                try
                {
                    var data = TransactionService.Get(id);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/Transaction/add")]
            [HttpPost]
            public HttpResponseMessage Add(TransactionDTO obj)
            {
                try
                {
                    if (obj != null)
                    {
                        var doctorData = TransactionService.Add(obj);

                        return Request.CreateResponse(HttpStatusCode.OK, obj);
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/Transaction/delete/{id}")]
            [HttpGet]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = TransactionService.Delete(id);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            [Route("api/Transaction/update/{id}")]
            [HttpPost]
            public HttpResponseMessage Update(TransactionDTO test, int id)
            {
                try
                {
                    test.Id = id;
                    var data = TransactionService.Update(test);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
        }
    }


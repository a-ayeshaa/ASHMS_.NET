using BLL.DTO.AdminDTOs;
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
    public class AccountController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [Route("api/accounts")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {

                var data = AccountServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/accounts/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AccountServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/accounts/add")]
        [HttpPost]
        public HttpResponseMessage Add(AccountDTO obj)
        {
            try
            {
                if (obj != null)
                {
                    var doctorData = AccountServices.Add(obj);

                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/accounts/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AccountServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/accounts/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(AccountDTO Account,int id)
        {
            try
            {
                Account.Id=id;
                var data = AccountServices.Update(Account);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}

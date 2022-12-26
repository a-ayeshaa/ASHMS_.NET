using BLL.DTO.UserDTOs;
using BLL.Services.UserServices;
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

    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var token = AuthServices.Authenticate(login.Username, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Username or Password Invalid");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            try
            {

                var token = TokenServices.Get(Request.Headers.Authorization.ToString());
                token.expiredAt = DateTime.Now;
                var t = TokenServices.Update(token);
                return Request.CreateResponse(HttpStatusCode.OK, t);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Username or Password Invalid");
            }
          
           
        }


    }
}

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

namespace APIAppLayer.Controllers.Admin
{
    [EnableCors("*","*","*")]
    [Logged]
    public class MedicineController : ApiController
    {
        [Route("api/medicines")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {

                var data = MedicineServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/medicines/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = MedicineServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/medicines/add")]
        [HttpPost]
        public HttpResponseMessage Add(MedicineDTO obj)
        {
            try
            {
                if (obj != null)
                {
                    var medicineData = MedicineServices.Add(obj);

                    return Request.CreateResponse(HttpStatusCode.OK, medicineData);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/medicines/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = MedicineServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/medicines/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(MedicineDTO test,int id)
        {
            try
            {
                test.Id = id;
                var data = MedicineServices.Update(test);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}

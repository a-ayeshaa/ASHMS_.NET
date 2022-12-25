using APIAppLayer.AuthFilter;
using BLL.DTO.DoctorDTOS;
using BLL.Services.DoctorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers.Doctor
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class MedicinePrescriptionController : ApiController
    {      
      
            [Route("api/medprescriptions")]
            [HttpGet]
            public HttpResponseMessage Get()
            {
                try
                {

                    var data = MedicinePrescriptionServices.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/medprescriptions/{id}")]
            [HttpGet]
            public HttpResponseMessage Get(int id)
            {
                try
                {
                    var data = MedicinePrescriptionServices.Get(id);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/medprescriptions/add")]
            [HttpPost]
            public HttpResponseMessage Add(MedicinePrescriptionDTO obj)
            {
                try
                {
                    //MedicinePrescriptionDTO user = json.;
                    //DoctorDTO doc = json.Doctor;

                    if (obj != null)
                    {
                        //var userData = UserServices.Add(user);
                        var Data = MedicinePrescriptionServices.Add(obj);

                        return Request.CreateResponse(HttpStatusCode.OK, Data);
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            [Route("api/medprescriptions/delete/{id}")]
            [HttpGet]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = MedicinePrescriptionServices.Delete(id);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            [Route("api/medprescriptions/update")]
            [HttpPost]
            public HttpResponseMessage Update(MedicinePrescriptionDTO doctor)
            {
                try
                {
                    var data = MedicinePrescriptionServices.Update(doctor);

                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
        }
}

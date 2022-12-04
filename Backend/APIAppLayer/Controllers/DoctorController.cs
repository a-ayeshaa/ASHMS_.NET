﻿using BLL.DTO.DoctorDTOS;
using BLL.DTO.UserDTOs;
using BLL.Services.DoctorServices;
using BLL.Services.PatientServices;
using BLL.Services.UserServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace APIAppLayer.Controllers
{
    public class DoctorController : ApiController
    {
        [Route("api/doctors")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DoctorServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = DoctorServices.Get(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]CompositeObject json)
        {
            try
            {
                UserDTO user = json.User;
                DoctorDTO doc = json.Doctor;

                if (user != null && doc!= null)
                {
                    var userData = UserServices.Add(user);
                    var doctorData = DoctorServices.Add(doc);

                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Route("api/doctors/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = DoctorServices.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [Route("api/doctors/update")]
        [HttpPost]
        public HttpResponseMessage Update(DoctorDTO doctor)
        {
            try
            {
                var data = DoctorServices.Update(doctor);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

    }
}

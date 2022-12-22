using AutoMapper;
using BLL.DTO.PatientDTOs;
using BLL.DTO.UserDTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public class PatientUserServices
    {
        public static PatientUserDTO GetwithPatient(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var patient = PatientServices.Get(data.Patients[0].Id);

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, PatientUserDTO>();
                c.CreateMap<Patient, PatientDTO>();

            });
            var mapper = new Mapper(config);
            var val = mapper.Map<PatientUserDTO>(data);
            val.PatientDTO= patient;

            return val;

        }
    }
}

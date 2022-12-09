using AutoMapper;
using BLL.DTO.PatientDTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public class TestCart_TestServices
    {
        public static TestCart_TestDTO GetwithTest(int id)
        {
            var data = DataAccessFactory.TestDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test, TestCart_TestDTO>();
                c.CreateMap<TestCart, TestCartDTO>();

            });
            var mapper = new Mapper(config);
            return mapper.Map<TestCart_TestDTO>(data);

        }
    }
}

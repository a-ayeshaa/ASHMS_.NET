using AutoMapper;
using BLL.DTO.AdminDTOs;
using BLL.DTO.PatientDTOs;
using BLL.Services.AdminServices;
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
            var result= mapper.Map<TestCart_TestDTO>(data);
            return result;

        }

        public static Test_TestCartDTO GetwithTestDetail(int id)
        {
            var data = DataAccessFactory.TestCartDataAccess().Get(id);
            var test = TestServices.Get(data.Test.Id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestCart, Test_TestCartDTO>();
                c.CreateMap<Test, TestDTO>();

            });
            var mapper = new Mapper(config);
            var result = mapper.Map<Test_TestCartDTO>(data);
            result.TestDTO = test;
            return result;

        }

    }
}

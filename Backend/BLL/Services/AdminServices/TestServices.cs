using AutoMapper;
using BLL.DTO.AdminDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.AdminServices
{
    public class TestServices
    {
        public static TestDTO Get(int id)
        {
            var data = DataAccessFactory.TestDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test, TestDTO>();
            });
            var mapper = new Mapper(config);
            var Test = mapper.Map<TestDTO>(data);
            return Test;
        }

        public static List<TestDTO> Get()
        {
            var data = DataAccessFactory.TestDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test, TestDTO>();
            });
            var mapper = new Mapper(config);
            //changes to be done here
            var Tests = mapper.Map<List<TestDTO>>(data);
            return Tests;
        }

        public static TestDTO Add(TestDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test, TestDTO>();
                c.CreateMap<TestDTO, Test>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Test>(obj);
            var data = DataAccessFactory.TestDataAccess().Add(newobj);
            return mapper.Map<TestDTO>(data);

        }

        public static bool Delete(int id)
        {
            var Test = DataAccessFactory.TestDataAccess().Get(id);


            return DataAccessFactory.TestDataAccess().Delete(Test.Id);

        }

        public static bool Update(TestDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test, TestDTO>();
                c.CreateMap<TestDTO, Test>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Test>(obj);
            var data = DataAccessFactory.TestDataAccess().Update(newobj);
            return data;
        }
    }
}

using AutoMapper;
using BLL.DTO.PatientDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public class TestCartServices
    {
        public static TestCartDTO Get(int id)
        {
            var data = DataAccessFactory.TestCartDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestCart, TestCartDTO>();
            });
            var mapper = new Mapper(config);
            var TestCart = mapper.Map<TestCartDTO>(data);
            return TestCart;
        }

        public static List<TestCartDTO> Get()
        {
            var data = DataAccessFactory.TestCartDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestCart, TestCartDTO>();
            });
            var mapper = new Mapper(config);
            var TestCarts = mapper.Map<List<TestCartDTO>>(data);
            return TestCarts;
        }

        public static TestCartDTO Add(TestCartDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestCart, TestCartDTO>();
                c.CreateMap<TestCartDTO, TestCart>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestCart>(obj);
            var data = DataAccessFactory.TestCartDataAccess().Add(newobj);
            return mapper.Map<TestCartDTO>(data);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TestCartDataAccess().Delete(id);
        }

        public static bool Update(TestCartDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestCart, TestCartDTO>();
                c.CreateMap<TestCartDTO, TestCart>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestCart>(obj);
            var data = DataAccessFactory.TestCartDataAccess().Update(newobj);
            return data;
        }
    }
}

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
    public class TestTransactionServices
    {
        public static TestTransactionDTO Get(int id)
        {
            var data = DataAccessFactory.TestTransactionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
            });
            var mapper = new Mapper(config);
            var TestTransaction = mapper.Map<TestTransactionDTO>(data);
            return TestTransaction;
        }

        public static List<TestTransactionDTO> Get()
        {
            var data = DataAccessFactory.TestTransactionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
            });
            var mapper = new Mapper(config);
            var TestTransactions = mapper.Map<List<TestTransactionDTO>>(data);
            return TestTransactions;
        }

        public static TestTransactionDTO Add(TestTransactionDTO obj,int patient_id)
        {
            var total = 0.00f;
            var testcarts = TestCartServices.Get();
            var testcart=(from t in testcarts
                          where t.Patient_Id == patient_id
                          select t).ToList();
            foreach (var t in testcarts)
            {
                
            }
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
                c.CreateMap<TestTransactionDTO, TestTransaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestTransaction>(obj);
            var data = DataAccessFactory.TestTransactionDataAccess().Add(newobj);
            return mapper.Map<TestTransactionDTO>(data);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TestTransactionDataAccess().Delete(id);
        }

        public static bool Update(TestTransactionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
                c.CreateMap<TestTransactionDTO, TestTransaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestTransaction>(obj);
            var data = DataAccessFactory.TestTransactionDataAccess().Update(newobj);
            return data;
        }

        
    }
}

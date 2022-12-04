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
    public class Test_TransactionServices
    {
        public static Test_TransactionDTO Get(int id)
        {
            var data = DataAccessFactory.Test_TransactionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test_Transaction, Test_TransactionDTO>();
            });
            var mapper = new Mapper(config);
            var Test_Transaction = mapper.Map<Test_TransactionDTO>(data);
            return Test_Transaction;
        }

        public static List<Test_TransactionDTO> Get()
        {
            var data = DataAccessFactory.Test_TransactionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test_Transaction, Test_TransactionDTO>();
            });
            var mapper = new Mapper(config);
            var Test_Transactions = mapper.Map<List<Test_TransactionDTO>>(data);
            return Test_Transactions;
        }

        public static Test_TransactionDTO Add(Test_TransactionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test_Transaction, Test_TransactionDTO>();
                c.CreateMap<Test_TransactionDTO, Test_Transaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Test_Transaction>(obj);
            var data = DataAccessFactory.Test_TransactionDataAccess().Add(newobj);
            return mapper.Map<Test_TransactionDTO>(data);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.Test_TransactionDataAccess().Delete(id);
        }

        public static bool Update(Test_TransactionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Test_Transaction, Test_TransactionDTO>();
                c.CreateMap<Test_TransactionDTO, Test_Transaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Test_Transaction>(obj);
            var data = DataAccessFactory.Test_TransactionDataAccess().Update(newobj);
            return data;
        }
    }
}

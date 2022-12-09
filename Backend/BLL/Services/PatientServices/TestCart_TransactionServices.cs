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
    public class TestCart_TransactionServices
    {
        public static TestCart_TransactionDTO GetwithCart(int id)
        {
            var data = DataAccessFactory.TestTransactionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestCart_TransactionDTO>();
                c.CreateMap<TestCart, TestCartDTO>();

            });
            var mapper = new Mapper(config);
            return mapper.Map<TestCart_TransactionDTO>(data);

        }
    }
}

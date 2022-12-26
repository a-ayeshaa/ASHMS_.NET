using AutoMapper;
using BLL.DTO.UserDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.AdminServices
{
    public class TransactionService
    {
        public static TransactionDTO Get(int id)
        {
            var data = DataAccessFactory.TransactionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(config);
            var Transaction = mapper.Map<TransactionDTO>(data);
            return Transaction;
        }

        public static List<TransactionDTO> Get()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(config);
            //changes to be done here
            var Transactions = mapper.Map<List<TransactionDTO>>(data);
            return Transactions;
        }

        public static TransactionDTO Add(TransactionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Transaction, TransactionDTO>();
                c.CreateMap<TransactionDTO, Transaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Transaction>(obj);
            var data = DataAccessFactory.TransactionDataAccess().Add(newobj);
            return mapper.Map<TransactionDTO>(data);

        }

        public static bool Delete(int id)
        {
            var Transaction = DataAccessFactory.TransactionDataAccess().Get(id);


            return DataAccessFactory.TransactionDataAccess().Delete(Transaction.Id);

        }

        public static bool Update(TransactionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Transaction, TransactionDTO>();
                c.CreateMap<TransactionDTO, Transaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Transaction>(obj);
            var data = DataAccessFactory.TransactionDataAccess().Update(newobj);
            return data;
        }
    }
}

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
    public class AccountServices
    {
        public static AccountDTO Get(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            var Account = mapper.Map<AccountDTO>(data);
            return Account;
        }

        public static List<AccountDTO> Get()
        {
            var data = DataAccessFactory.AccountDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            //changes to be done here
            var Accounts = mapper.Map<List<AccountDTO>>(data);
            return Accounts;
        }

        public static AccountDTO Add(AccountDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
                c.CreateMap<AccountDTO, Account>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Account>(obj);
            var data = DataAccessFactory.AccountDataAccess().Add(newobj);
            return mapper.Map<AccountDTO>(data);

        }

        public static bool Delete(int id)
        {
            var Account = DataAccessFactory.AccountDataAccess().Get(id);


            return DataAccessFactory.AccountDataAccess().Delete(Account.Id);

        }

        public static bool Update(AccountDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
                c.CreateMap<AccountDTO, Account>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Account>(obj);
            var data = DataAccessFactory.AccountDataAccess().Update(newobj);
            return data;
        }
    }
}

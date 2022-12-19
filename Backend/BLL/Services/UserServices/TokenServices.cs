using AutoMapper;
using BLL.DTO.UserDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UserServices
{
    public class TokenServices
    {
        public static TokenDTO Get(int id)
        {
            var data = DataAccessFactory.TokenDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var Token = mapper.Map<TokenDTO>(data);
            return Token;
        }

        public static List<TokenDTO> Get()
        {
            var data = DataAccessFactory.TokenDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var Tokens = mapper.Map<List<TokenDTO>>(data);
            return Tokens;
        }

        public static TokenDTO Add(TokenDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
                c.CreateMap<TokenDTO, Token>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Token>(obj);
            var data = DataAccessFactory.TokenDataAccess().Add(newobj);
            return mapper.Map<TokenDTO>(data);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TokenDataAccess().Delete(id);
        }

        public static TokenDTO Update(TokenDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
                c.CreateMap<TokenDTO, Token>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Token>(obj);
            var data = DataAccessFactory.TokenDataAccess().Update(newobj);
            return mapper.Map<TokenDTO>(data);
        }
    }
}

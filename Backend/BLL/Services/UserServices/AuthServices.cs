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
    public class AuthServices
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var rs = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            if (rs!=null)
            {
                var tk = new Token();
                tk.User_Id = rs.Id;
                tk.createdAt = DateTime.Now;
                tk.expiredAt = null;
                tk.token = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<TokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.expiredAt == null)
            {
                return true;
            }
            return false;

        }
    }
}

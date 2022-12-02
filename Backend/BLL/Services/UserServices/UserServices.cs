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
    public class UserServices
    {
        private UserDTO userDTO;

        public UserServices(UserDTO userDTO)
        {
            this.userDTO = userDTO;
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var User = mapper.Map<UserDTO>(data);
            return User;
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var Users = mapper.Map<List<UserDTO>>(data);
            return Users;
        }

        public static UserDTO Add(UserDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<User>(obj);
            var data = DataAccessFactory.UserDataAccess().Add(newobj);
            return mapper.Map<UserDTO>(data);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }

        public static UserDTO Update(UserDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<User>(obj);
            var data = DataAccessFactory.UserDataAccess().Update(newobj);
            return mapper.Map<UserDTO>(data);
        }
    }
}


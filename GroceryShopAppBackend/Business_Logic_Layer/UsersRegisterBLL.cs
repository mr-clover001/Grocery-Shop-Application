using AutoMapper;
using Business_Logic_Layer.ModelsDTO;
using Data_Access_Layer.Repository.Entities;
using GroceryShopApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public class UsersRegisterBLL
    {

        private Data_Access_Layer.UsersRegisterDAL _DAL;
        private Mapper _UsersRegisterMapper;
        private Mapper _UserLoginMapper;

        public UsersRegisterBLL()
        {
            _DAL = new Data_Access_Layer.UsersRegisterDAL();

            var _configUsersRegister = new MapperConfiguration(cfg => cfg.CreateMap<UsersRegister, UsersRegisterDTO>().ReverseMap());
            _UsersRegisterMapper = new Mapper(_configUsersRegister);


            var _configLogin = new MapperConfiguration(cfg => cfg.CreateMap<UserLogin, UserLoginDTO>().ReverseMap());
            _UserLoginMapper = new Mapper(_configLogin);

            }

        public List<UsersRegisterDTO> GetUsersRegister()
        {
            List<UsersRegister> usersRegisterFromDb = _DAL.GetUsersRegister();
            List<UsersRegisterDTO> usersRegisterM = _UsersRegisterMapper.Map<List<UsersRegister>, List<UsersRegisterDTO>>(usersRegisterFromDb);
            return usersRegisterM;
        }

        public bool AddUsersRegister(UsersRegisterDTO usersRegisterM)
        {

            if (IsEmailExists(usersRegisterM.Email))
            {
                return true;
            }
            else
            {
                UsersRegister usersRegisterEntity = _UsersRegisterMapper.Map<UsersRegisterDTO, UsersRegister>(usersRegisterM);
                _DAL.AddUsersRegister(usersRegisterEntity);
                return false;
            }

        }

        private bool IsEmailExists(string email)
        {
            return _DAL.IsEmailExists(email);
        }

        public UsersRegisterDTO UserLoggedIn(UserLoginDTO userLoginM)
        {
            var userLogin = new UserLogin { Email = userLoginM.Email, Password = userLoginM.Password };
            var LoginUserFromDB = _DAL.IsLogin(userLogin);

            UsersRegisterDTO usersLoginM = _UsersRegisterMapper.Map<UsersRegister, UsersRegisterDTO>(LoginUserFromDB);

            return usersLoginM;


        }

    }
}

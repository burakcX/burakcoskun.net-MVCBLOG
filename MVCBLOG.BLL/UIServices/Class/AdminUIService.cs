using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.BLL.UIServices.Interface;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.ENTITY.Model_Object;

namespace MVCBLOG.BLL.UIServices.Class
{
    public class AdminUIService : IBaseUIService<UserDTO>
    {
        #region Değişkenler

        private readonly RepoDAL<User> UserRepo;

        #endregion

        #region ctor

        public AdminUIService()
        {
            UserRepo=new RepoDAL<User>();
        }
        #endregion

        #region Metodlar
        public List<UserDTO> TumListe()
        {
            List<User> UserList = UserRepo.TumListe().ToList();
            List<UserDTO> UserDtoList = new List<UserDTO>();

            foreach (User item in UserList)
            {
                UserDTO AdminDto = new UserDTO()
                {
                    UserNameDTO = item.UserName,
                    PasswordDTO = item.Password
                };
                UserDtoList.Add(AdminDto);
            }
            return UserDtoList;
        }

        public UserDTO IdIleGetir(int Id)
        {
            throw new NotImplementedException();
        }

        public UserDTO KullaniciAdiIleGetir(string UserName)
        {
            UserDTO AdminUserDto = new UserDTO();

            User AdminUser = new User();

            throw new NotImplementedException();
        }

        public bool Kayit(UserDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool PasifYap(UserDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool SilDb(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(UserDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public UserDTO AdGetirKullaniciAdiIle(LoginViewModel model)
        {
            User UserEntity = UserRepo.NesneGetirQueryable(x => x.UserName == model.UserName);

            UserDTO UserDto = new UserDTO()
            {
                IdDTO = UserEntity.Id,
                NameDTO = UserEntity.Name,
                SurnameDTO = UserEntity.Surname,
                UserNameDTO = UserEntity.UserName
                
            };

            return UserDto;
        }

        #endregion
    }
}

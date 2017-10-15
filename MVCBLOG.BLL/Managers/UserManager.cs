using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.ENTITY.Model_Object;

namespace MVCBLOG.BLL.Managers
{
    public class UserManager
    {
        //Bu işlemler kullanıcı işlemleri olduğu için bir usermanager a ihtiyacımız bulunmaktadır.

        #region Değişkenler

        private readonly RepoDAL<User> UserRepo;

        #endregion

        #region ctor
        public UserManager()
        {
            UserRepo = new RepoDAL<User>();
        }

        #endregion

        public void RegisterUser(RegisterViewModel model, string Ip)
        {
            //Kullanıcı UserName Kontrolü
            //Kullanıcı E-posta Kontrolü
            //Kayıt İşlemi
            //Aktivasyon E-postası Gönderimi

            User User = UserRepo.NesneGetirDegereGore(x => x.UserName == model.UserName || x.EMail == model.EMail);

            //Ön tarafa DTO dönmem gerekmiyor.

            //UserDTO UserDto = new UserDTO()
            //{
            //    UserNameDTO = User.UserName,
            //    EMailDTO = User.EMail
            //};


            if (User != null)
            {
                throw new Exception("Kayıtlı kullanıcı veya e-posta adresi");
            }

            else if (User == null)
            {
                User UserEntity = new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    EMail = model.EMail,
                    Password = model.Password,
                    RePassword = model.RePassword,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    Type = 2,
                    Ip = Ip,
                    CreatedUserName = "system",
                    CreatedDate = DateTime.Now,
                    ModifiedUserName = "system",
                    ModifiedDate = DateTime.Now,

                };

                UserRepo.Kayit(UserEntity);

            }

        }

        public void LoginUser(LoginViewModel model, string Ip)
        {
            //Giriş Kontrolü.
            //Hesap Aktive Edilmiş mi?
            //Yönlendirme.
            //Session'a kullanıcı bilgileri saklama.

            User User = UserRepo.NesneGetirQueryable(x => x.UserName == model.UserName && x.Password == model.Password);

            
            if (User != null)
            {
                if (User.IsActive == true)
                {

                }

                else if (User.IsActive == false)
                {
                    throw new Exception("Kullanıcı aktifleştirilmemiştir. Lütfen E-posta adresinizi kontrol ediniz.");
                }
            }

            else if (User == null)
            {
                throw new Exception("Böyle bir kullanıcı kayıtlı değildir. Giriş yapmak için lütfen kayıt olunuz.");
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.ENTITY.Model_Object;

namespace MVCBLOG.BLL.UIServices.Class
{
    public class UserUIService
    {

        #region Değişkenler

        private readonly RepoDAL<User> UserRepo;

        #endregion

        #region ctor

        public UserUIService()
        {
            UserRepo = new RepoDAL<User>();
        }

        #endregion

        #region Metodlar

        public BusinessLayerResult<User> RegisterUser(RegisterViewModel model, string Ip)
        {
            //Kullanıcı UserName Kontrolü
            //Kullanıcı E-posta Kontrolü
            //Kayıt İşlemi
            //Aktivasyon E-postası Gönderimi

            BusinessLayerResult<User> LayerResult = new BusinessLayerResult<User>();
            User User = UserRepo.NesneGetirDegereGore(x => x.UserName == model.UserName || x.EMail == model.EMail);

            if (User != null)
            {
                if (User.UserName == model.UserName)
                {
                    LayerResult.Errors.Add("Kullanıcı adı kayıtlı!");
                }
                if (User.EMail == model.EMail)
                {
                    LayerResult.Errors.Add("E-posta adresi kayıtlı!");
                }
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
                    CreatedUserName = model.UserName,
                    CreatedDate = DateTime.Now,
                    ModifiedUserName = model.UserName,
                    ModifiedDate = DateTime.Now,
                };

                bool dbresult = UserRepo.Kayit(UserEntity);

                if (dbresult)
                {
                    LayerResult.Result = UserRepo.TumListeQueryable().FirstOrDefault(x => x.UserName == model.UserName && x.EMail == model.EMail);
                }
            }

            return LayerResult;
        }

        public BusinessLayerResult<User> LoginUser(LoginViewModel model, string Ip)
        {
            //Giriş Kontrolü.
            //Hesap Aktive Edilmiş mi?
            //Yönlendirme.
            //Session'a kullanıcı bilgileri saklama.

            BusinessLayerResult<User> LayerResult = new BusinessLayerResult<User>();
            User User = UserRepo.TumListeQueryable().FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (User == null)
            {
                LayerResult.Errors.Add("Böyle bir kullanıcı kayıtlı değildir.");
            }

            return LayerResult;

            //    if (User.IsActive == true)
            //    {

            //    }

            //    else if (User.IsActive == false)
            //    {
            //        throw new Exception("Kullanıcı aktifleştirilmemiştir. Lütfen E-posta adresinizi kontrol ediniz.");
            //    }
            //}

            //else if (User == null)
            //{
            //    throw new Exception("Böyle bir kullanıcı kayıtlı değildir. Giriş yapmak için lütfen kayıt olunuz.");
            //}

        }

        #endregion

    }
}

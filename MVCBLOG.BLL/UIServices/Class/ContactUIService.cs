using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.BLL.UIServices.Class
{
    public class ContactUIService
    {

        #region Değişkenler
        private readonly RepoDAL<Contact> ContactRepo;

        #endregion


        #region ctor

        public ContactUIService()
        {
            ContactRepo = new RepoDAL<Contact>();
        }

        #endregion


        #region Metodlar

        public bool Insert(ContactDTO model)
        {
            Contact ContactEntity = new Contact()
            {
                Name = model.NameDTO,
                Surname = model.SurnameDTO,
                Email = model.EmailDTO,
                Subject = model.SubjectDTO,
                Message = model.MessageDTO,
                CreatedUserName = model.CreatedUserNameDto,
                CreatedDate = model.CreatedDateDto,
                ModifiedUserName = model.ModifiedUserNameDto,
                ModifiedDate = model.ModifiedDateDto
            };

            return ContactRepo.Kayit(ContactEntity);
        }

        #endregion




    }
}

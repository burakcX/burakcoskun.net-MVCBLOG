using MVCBLOG.BLL.UIServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.ENTITY;
using MVCBLOG.DAL.Repository.Interface;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.BLL.UIServices.Class
{
    public class CategoryUIService : ICategoryUIService
    {

        #region Değişkenler
        private readonly RepoDAL<Category> CategoryRepo;
        #endregion

        #region ctor
        public CategoryUIService()
        {
            CategoryRepo = new RepoDAL<Category>();
        }
        #endregion

        #region Metodlar

        public List<CategoryDTO> TumListe()
        {
            List<Category> CategoryList = CategoryRepo.TumListe().ToList();
            List<CategoryDTO> CategoryDtoList = new List<CategoryDTO>();

            foreach (Category item in CategoryList)
            {
                CategoryDTO CategoryDto = new CategoryDTO()
                {
                    CategoryDtoId = item.Id,
                    CreatedUserNameDto = item.CreatedUserName,
                    CreatedDateDto = item.CreatedDate,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate,
                    NameCategoryDto = item.Name,
                    DescriptionCategoryDto = item.Description,
                    PostDtoList = item.Posts.Select(postEntity => new PostDTO
                    {
                        PostDtoId = postEntity.Id,

                    }).ToList()
                };
                CategoryDtoList.Add(CategoryDto);
            }
            return CategoryDtoList;
        }

        //TODO: BU KISIMA DEVAM EDİLECEK..

        public CategoryDTO IdIleGetir(int Id)
        {
            Category Category = CategoryRepo.IdIleGetir(Id);

            CategoryDTO CategoryDTO = new CategoryDTO()
            {
                CategoryDtoId = Category.Id,
                NameCategoryDto = Category.Name,
                DescriptionCategoryDto = Category.Description
            };

            return CategoryDTO;

        }

        public CategoryDTO KullaniciAdiIleGetir(string User)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(CategoryDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool Kayit(CategoryDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool PasifYap(CategoryDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool SilDb(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

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
                    CreatedDateDto = item.CreatedDate.Value,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate.Value,
                    NameCategoryDto = item.Name,
                    SeoCategoryDTO = item.SeoCategory,
                    DescriptionCategoryDto = item.Description,
                    PostDtoList = item.PostList.Select(postEntity => new PostDTO
                    {
                        PostDtoId = postEntity.Id,

                    }).ToList()
                };
                CategoryDtoList.Add(CategoryDto);
            }
            return CategoryDtoList;
        }

        //TODO: NOT..

        public CategoryDTO IdIleGetir(int Id)
        {
            Category Category = CategoryRepo.IdIleGetir(Id);

            CategoryDTO CategoryDTO = new CategoryDTO()
            {
                CategoryDtoId = Category.Id,
                NameCategoryDto = Category.Name,
                SeoCategoryDTO = Category.SeoCategory,
                DescriptionCategoryDto = Category.Description,
                CreatedUserNameDto = Category.CreatedUserName,
                ModifiedUserNameDto = Category.ModifiedUserName,
                CreatedDateDto = Category.CreatedDate,
                ModifiedDateDto = Category.ModifiedDate
                
            };

            return CategoryDTO;

        }

        public int KayitSayisiGetir()
        {
            return CategoryRepo.KayitSayisi();
        }

        public CategoryDTO KullaniciAdiIleGetir(string User)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(CategoryDTO ModelDto)
        {
            Category CategoryEntity = CategoryRepo.IdIleGetir(ModelDto.CategoryDtoId);

            CategoryEntity.Id = ModelDto.CategoryDtoId;
            CategoryEntity.Name = ModelDto.NameCategoryDto;
            CategoryEntity.SeoCategory = ModelDto.SeoCategoryDTO;
            CategoryEntity.Description = ModelDto.DescriptionCategoryDto;

            return CategoryRepo.Guncelle(CategoryEntity);
        }

        public bool Kayit(CategoryDTO ModelDto)
        {
            Category CategoryEntity = new Category()
            {
                Id = ModelDto.CategoryDtoId,
                Name = ModelDto.NameCategoryDto,
                SeoCategory = ModelDto.SeoCategoryDTO,
                Description = ModelDto.DescriptionCategoryDto,
                CreatedUserName = ModelDto.CreatedUserNameDto,
                CreatedDate = ModelDto.CreatedDateDto,
                ModifiedUserName = ModelDto.ModifiedUserNameDto,
                ModifiedDate = ModelDto.ModifiedDateDto

            };

            return CategoryRepo.Kayit(CategoryEntity);
        }

        public bool PasifYap(CategoryDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool SilDb(int Id)
        {
            Category CategoryEntity = CategoryRepo.IdIleGetir(Id);
            return CategoryRepo.SilDb(CategoryEntity);
        }
        #endregion

    }
}

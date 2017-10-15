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
    public class PostUIService : IPostUIService
    {
        #region Değişkenler
        private readonly RepoDAL<Post> PostRepo;
        #endregion

        #region ctor
        public PostUIService()
        {
            PostRepo = new RepoDAL<Post>();
        }
        #endregion

        #region Metodlar

        public int KayitSayisiGetir()
        {
            return PostRepo.KayitSayisi();
        }

        public List<PostDTO> TumListe()
        {
            List<Post> PostList = PostRepo.TumListe().ToList();

            List<PostDTO> PostDTOList = new List<PostDTO>();

            foreach (Post item in PostList)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    PostDtoId = item.Id,
                    TitleDto = item.Title,
                    ContentDto = item.Content,
                    CreatedUserNameDto = item.CreatedUserName,
                    CreatedDateDto = item.CreatedDate,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate,
                    CategoryDTO = new CategoryDTO()
                    {
                        CategoryDtoId = item.Category.Id,
                        NameCategoryDto = item.Category.Name,
                        DescriptionCategoryDto = item.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = item.User.Name,
                        SurnameDTO = item.User.Surname,
                        CreatedDateDto = item.CreatedDate
                    }
                };

                PostDTOList.Add(PostDTO);
            }

            return PostDTOList;

            //BU KISIMDA CONVERTION HATASI VAR. FOR EACH ILE DONEREK TEK TEK ESLESTIRME YAPILMASI GEREKIYOR.
        }

        public PostDTO PostDetayGetirIdIle(int Id)
        {
            Post PostEntity = PostRepo.NesneGetirDegereGore(x => x.Id == Id);

            if (PostEntity != null)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    TitleDto = PostEntity.Title,
                    ContentDto = PostEntity.Content
                };
                return PostDTO;
            }
            return new PostDTO();
        }

        public PostDTO PostGetirKullaniciAdiIle(string UserName)
        {
            Post PostEntity = PostRepo.NesneGetirDegereGore(x => x.User.EMail == UserName);

            if (PostEntity != null)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    TitleDto = PostEntity.Title,
                    ContentDto = PostEntity.Content
                };
                return PostDTO;
            }
            return new PostDTO();
        }

        public bool Guncelle(PostDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public List<PostDTO> PostListeleCatIdIle(int Id)
        {
            List<Post> PostList = PostRepo.ListSorgulaDegereGore(x => x.Category.Id == Id);

            List<PostDTO> PostDtoList = new List<PostDTO>();

            foreach (Post item in PostList)
            {
                PostDTO PostDto = new PostDTO()
                {
                    PostDtoId = item.Id,
                    TitleDto = item.Title,
                    ContentDto = item.Content,
                    CreatedUserNameDto = item.CreatedUserName,
                    CreatedDateDto = item.CreatedDate,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate,
                    CategoryDTO = new CategoryDTO()
                    {
                        NameCategoryDto = item.Category.Name,
                        DescriptionCategoryDto = item.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = item.User.Name,
                        SurnameDTO = item.User.Surname,
                        CreatedDateDto = item.CreatedDate
                    }

                };

                PostDtoList.Add(PostDto);
            }

            return PostDtoList;
        }

        public bool PasifYap(PostDTO ModelDto)
        {
            throw new NotImplementedException();
        }

        public bool Kayit(PostDTO ModelDto)
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

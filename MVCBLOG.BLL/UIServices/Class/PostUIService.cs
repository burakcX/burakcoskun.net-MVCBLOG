using MVCBLOG.BLL.UIServices.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.ENTITY;
using MVCBLOG.DAL.Repository.Interface;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.ENTITY.Model_Object;


namespace MVCBLOG.BLL.UIServices.Class
{
    public class PostUIService : IPostUIService
    {
        #region Değişkenler

        private readonly RepoDAL<Post> PostRepo;
        private readonly RepoDAL<Category> CategoryRepo;

        #endregion

        #region ctor
        public PostUIService()
        {
            PostRepo = new RepoDAL<Post>();
            CategoryRepo = new RepoDAL<Category>();
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
                    SeolinkDto = item.Seolink,
                    CreatedUserNameDto = item.CreatedUserName,
                    CreatedDateDto = item.CreatedDate.Value,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate.Value,
                    ViewCountDto = item.ViewCount.Value,
                    LikeCountDto = item.LikeCount.Value,
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
                        CreatedDateDto = item.CreatedDate.Value
                    }
                };

                PostDTOList.Add(PostDTO);
            }

            return PostDTOList;

        }

        public PostDTO PostDetayGetirIdIle(int Id)
        {
            Post PostEntity = PostRepo.NesneGetirDegereGore(x => x.Id == Id);

            if (PostEntity != null)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    PostDtoId = PostEntity.Id,
                    TitleDto = PostEntity.Title,
                    ContentDto = PostEntity.Content,
                    ViewCountDto = PostEntity.ViewCount.Value,
                    CreatedUserNameDto = PostEntity.CreatedUserName,
                    CreatedDateDto = PostEntity.CreatedDate.Value,
                    ModifiedUserNameDto = PostEntity.ModifiedUserName,
                    ModifiedDateDto = PostEntity.ModifiedDate.Value,
                    CategoryDTO = new CategoryDTO()
                    {
                        CategoryDtoId = PostEntity.Category.Id,
                        NameCategoryDto = PostEntity.Category.Name,
                        DescriptionCategoryDto = PostEntity.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = PostEntity.User.Name,
                        SurnameDTO = PostEntity.User.Surname,
                        CreatedDateDto = PostEntity.CreatedDate.Value
                    }

                };
                return PostDTO;
            }
            return new PostDTO();
        }

        public PostDTO PostDetayGetirSeoLinkIle(string SeoLink)
        {
            Post PostEntity = PostRepo.NesneGetirDegereGore(x => x.Seolink == SeoLink);

            if (PostEntity != null)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    PostDtoId = PostEntity.Id,
                    TitleDto = PostEntity.Title,
                    ContentDto = PostEntity.Content,
                    ViewCountDto = PostEntity.ViewCount.Value,
                    CreatedUserNameDto = PostEntity.CreatedUserName,
                    CreatedDateDto = PostEntity.CreatedDate.Value,
                    ModifiedUserNameDto = PostEntity.ModifiedUserName,
                    ModifiedDateDto = PostEntity.ModifiedDate.Value,
                    CategoryDTO = new CategoryDTO()
                    {
                        CategoryDtoId = PostEntity.Category.Id,
                        NameCategoryDto = PostEntity.Category.Name,
                        DescriptionCategoryDto = PostEntity.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = PostEntity.User.Name,
                        SurnameDTO = PostEntity.User.Surname,
                        CreatedDateDto = PostEntity.CreatedDate.Value
                    }

                };
                return PostDTO;
            }
            return new PostDTO();
        }

        public PostDTO PostGetirIdIle(int Id)
        {
            Post Post = PostRepo.IdIleGetir(Id);

            PostDTO PostDto = new PostDTO()
            {
                PostDtoId = Post.Id,
                TitleDto = Post.Title,
                ContentDto = Post.Content,
                SeolinkDto = Post.Seolink,
                CategoryDtoId = Post.CategoryId,
                CreatedUserNameDto = Post.CreatedUserName,
                ModifiedUserNameDto = Post.ModifiedUserName

            };

            return PostDto;
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

        public List<PostDTO> PostGetirBaslikIle(string Baslik)
        {
            List<Post> PostEntityList = PostRepo.TumListeQueryable().Where(x=>x.Title.Contains(Baslik)).ToList();

            List<PostDTO> PostDtoList = new List<PostDTO>();

            foreach (Post PostEntity in PostEntityList)
            {
                PostDTO PostDTO = new PostDTO()
                {
                    PostDtoId = PostEntity.Id,
                    TitleDto = PostEntity.Title,
                    ContentDto = PostEntity.Content,
                    SeolinkDto = PostEntity.Seolink,
                    ViewCountDto = PostEntity.ViewCount.Value,
                    CreatedUserNameDto = PostEntity.CreatedUserName,
                    CreatedDateDto = PostEntity.CreatedDate.Value,
                    ModifiedUserNameDto = PostEntity.ModifiedUserName,
                    ModifiedDateDto = PostEntity.ModifiedDate.Value,
                    CategoryDTO = new CategoryDTO()
                    {
                        CategoryDtoId = PostEntity.Category.Id,
                        NameCategoryDto = PostEntity.Category.Name,
                        DescriptionCategoryDto = PostEntity.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = PostEntity.User.Name,
                        SurnameDTO = PostEntity.User.Surname,
                        CreatedDateDto = PostEntity.CreatedDate.Value
                    }
                };

                PostDtoList.Add(PostDTO);
            }

            return PostDtoList;
        }

        public bool OkunmaSayisiArttir(PostDTO model)
        {
            Post PostEntity = PostRepo.IdIleGetir(model.PostDtoId);
            PostEntity.ViewCount = PostEntity.ViewCount + 1;
            return PostRepo.Guncelle(PostEntity);
        }

        public bool Guncelle(PostDTO model)
        {
            throw new NotImplementedException();

        }

        public bool UpdatePost(PostViewModel model)
        {
            Post PostEntity = PostRepo.IdIleGetir(model.PostId);

            PostEntity.Id = model.PostId;
            PostEntity.Title = model.Title;
            PostEntity.Seolink = model.Seolink;
            PostEntity.Content = model.Content;
            PostEntity.CategoryId = model.CategoryId;
            PostEntity.CreatedDate = DateTime.Now;
            PostEntity.ModifiedDate = DateTime.Now;
            PostEntity.ModifiedUserName = model.ModifiedUserName;

            return PostRepo.Guncelle(PostEntity);

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
                    CreatedDateDto = item.CreatedDate.Value,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate.Value,
                    CategoryDTO = new CategoryDTO()
                    {
                        NameCategoryDto = item.Category.Name,
                        DescriptionCategoryDto = item.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = item.User.Name,
                        SurnameDTO = item.User.Surname,
                        CreatedDateDto = item.CreatedDate.Value
                    }

                };

                PostDtoList.Add(PostDto);
            }

            return PostDtoList;
        }

        public List<PostDTO> PostListeleCatSeoLinkIle(string SeoLinkUrl)
        {
            Category CategoryEntity = CategoryRepo.NesneGetirDegereGore(x => x.SeoCategory == SeoLinkUrl);

            List<PostDTO> PostDtoList = new List<PostDTO>();

            foreach (Post item in CategoryEntity.PostList)
            {
                PostDTO PostDto = new PostDTO()
                {
                    PostDtoId = item.Id,
                    TitleDto = item.Title,
                    ContentDto = item.Content,
                    SeolinkDto = item.Seolink,
                    CreatedUserNameDto = item.CreatedUserName,
                    CreatedDateDto = item.CreatedDate.Value,
                    ModifiedUserNameDto = item.ModifiedUserName,
                    ModifiedDateDto = item.ModifiedDate.Value,
                    CategoryDTO = new CategoryDTO()
                    {
                        NameCategoryDto = item.Category.Name,
                        DescriptionCategoryDto = item.Category.Description
                    },
                    UserDTO = new UserDTO()
                    {
                        NameDTO = item.User.Name,
                        SurnameDTO = item.User.Surname,
                        CreatedDateDto = item.CreatedDate.Value
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

            Post PostEntity = new Post()
            {
                Title = ModelDto.TitleDto,
                Content = ModelDto.ContentDto,
                CreatedUserName = "system",
                CreatedDate = ModelDto.CreatedDateDto,
                ModifiedUserName = "system",
                ModifiedDate = ModelDto.ModifiedDateDto,
                LikeCount = 15,
                ViewCount = 20,
                Category = new Category()
                {
                    Id = ModelDto.CategoryDTO.CategoryDtoId
                },
                User = new User()
                {
                    Id = ModelDto.UserDTO.IdDTO
                }
            };

            return PostRepo.Kayit(PostEntity);

        }

        public bool SilDb(int Id)
        {
            Post PostEntity = PostRepo.IdIleGetir(Id);
            return PostRepo.SilDb(PostEntity);
        }

        public void AddPost(PostViewModel model)
        {
            Post PostEntity = new Post()
            {
                Title = model.Title,
                Seolink = model.Seolink,
                Content = model.Content,
                LikeCount = 0,
                ViewCount = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedUserName = model.CreatedUserName,
                ModifiedUserName = model.ModifiedUserName,
                UserId = model.UserId,
                CategoryId = model.CategoryId,

            };

            PostRepo.Kayit(PostEntity);

        }

        #endregion

    }
}

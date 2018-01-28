using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.DAL.Repository.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.BLL.UIServices.Class
{
    public class FileUIService
    {
        #region Değişkenler

        private readonly RepoDAL<File> RepoFile;

        #endregion


        #region ctor

        public FileUIService()
        {
            RepoFile = new RepoDAL<File>();
        }

        #endregion


        #region Metodlar

        public bool Insert(FileDTO model)
        {
            File FileEntity = new File()
            {
                FileName = model.FileNameDto,
                FileUrl = model.FileUrlDto,
                FileSize = model.FileSizeDto,
                FileExtension = model.FileExtensionDto,
                FileType = model.FileTypeDto,
                CreatedUserName = model.CreatedUserNameDto,
                CreatedDate = model.CreatedDateDto,
                ModifiedUserName = model.ModifiedUserNameDto,
                ModifiedDate = model.ModifiedDateDto
            };

            return RepoFile.Kayit(FileEntity);
        } 
        #endregion





    }
}

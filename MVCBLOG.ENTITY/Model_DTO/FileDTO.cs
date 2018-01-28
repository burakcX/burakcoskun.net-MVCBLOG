using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class FileDTO : BaseDTO
    {
        public int IdDto { get; set; }
        public string FileNameDto { get; set; }
        public string FileUrlDto { get; set; }
        public int? FileSizeDto { get; set; }
        public string FileExtensionDto { get; set; }
        public string FileTypeDto { get; set; }

    }
}

﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Common.structureServices.Attachments
{
    public interface IAttachmentService
    {

        Task<string> UploadAsync(IFormFile file, string folderName);

        bool Delete(string filePath);





    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Common.structureServices.Attachments
{
    public class AttachmentService : IAttachmentService
    {

        private readonly List<string> _allowedExtensions = new() { ".png", ".jpg", ".jpeg" };
        private const int _allowedMaxSize = 2_097_152;
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        public string? Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_allowedExtensions.Contains(extension))
                return null;
            if (file.Length > _allowedMaxSize)
                return null;

            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{extension}"; //must be unique

            var filePath = Path.Combine(folderPath, fileName); // file location placed

            //streaming => data per time
          using  var fileStream = new FileStream(filePath, FileMode.Create);
          
            file.CopyTo(fileStream);
            return fileName;

            }
        }
    }










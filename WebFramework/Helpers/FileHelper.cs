using DataLayer.SSOT;
using HeyRed.Mime;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileType = DataLayer.SSOT.FileType;

namespace WebFramework.Helpers
{
    public static class FileHelper
    {
        public static string SaveFile(IFormFile file, FileConfig config, FileType fileType, long? length = null)
        {
            if (file.Length <= 0)
            {
                throw new Exception("there is no content in uploaded file.");
            }

            var date = DateTime.Now;
            var relativePath = $"{fileType}/{date.Year}/{date.Month}/{date.Day}/";
            var folderPath = Path.Combine(config.PhysicalAddress, relativePath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            Directory.CreateDirectory(folderPath);
            var filepath = Path.Combine(folderPath, fileName);

            var stream = file.OpenReadStream();
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            var fileByte = memoryStream.ToArray();
            var newBytes = fileByte;

            if (length.HasValue)
            {
                newBytes = ImageResizer.ResizeImage(fileByte, (int)length.Value);
            }

            System.IO.File.WriteAllBytes(filepath, newBytes);


            //Check Mime Type
            var allowedExtensions = new List<string>
            {
                "image/png",
                "image/tiff",
                "image/jpeg",
                "image/bmp",
                "image/gif",
            };

            if (fileType == FileType.file)
            {
                allowedExtensions.Add("application/msword");
                allowedExtensions.Add("audio/mpeg");
                allowedExtensions.Add("audio/x-wav");
                allowedExtensions.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                allowedExtensions.Add("application/vnd.ms-excel");
                allowedExtensions.Add("application/octet-stream");
                allowedExtensions.Add("multipart/x-zip");
                allowedExtensions.Add("application/x-rar");
                allowedExtensions.Add("application/zip");
                allowedExtensions.Add("application/x-rar-compressed");
                allowedExtensions.Add("application/x-zip-compressed");
                allowedExtensions.Add("application/pdf");
                allowedExtensions.Add("application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }

            var mimeType = MimeGuesser.GuessMimeType(filepath);

            if (allowedExtensions.Contains(mimeType))
                return Path.Combine(relativePath, fileName);


            try
            {
                File.Delete(filepath);
            }
            catch (IOException)
            {

            }

            throw new Exception("فایل مورد نظر غیر مجاز می‌باشد");
        }
    }
}

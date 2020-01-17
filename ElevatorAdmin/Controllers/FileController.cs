using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.SSOT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFramework.Helpers;
using FileType = DataLayer.SSOT.FileType;


namespace ElevatorAdmin.Controllers
{
    public class FileController : Controller
    {

        private readonly FileConfig _fileConfig;

        public FileController(FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
        }

        public ActionResult Image(string field = "")
        {
            ViewBag.Field = field;
            return View();
        }

        public ActionResult File(string field = "", long? length = null, string type = "image")
        {
            ViewBag.Field = field;
            ViewBag.Length = length;
            ViewBag.FileType = type;
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(string field, IFormFile file)
        {
            // TODO: upload file
            ViewBag.Field = field;

            try
            {
                ViewBag.FileName = FileHelper.SaveFile(file, _fileConfig, FileType.image);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(string field, IFormFile file, long? length, string type = "image")
        {
            // TODO: upload file
            ViewBag.Field = field;

            try
            {
                ViewBag.FileName = FileHelper.SaveFile(file, _fileConfig, FileType.file, length);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return View();
        }
    }

}
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Onboarding.Handlers.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Handlers.ImageHandler
{
    public class ImageHandler:IImageHandler
    {
        private readonly IWebHostEnvironment hosting;
        private readonly ILogger<ImageHandler> logger;
        public ImageHandler(ILogger<ImageHandler> logger,IWebHostEnvironment _hosting)
        {
            this.hosting = _hosting;
            this.logger = logger;
        }
        public string UploadImage(IFormFile file)
        {
            try
            {
                var check = CheckFormat(file.FileName);
                if (!check) return null;

                FileInfo Fi = new FileInfo(file.FileName);
                var filename = "File_"+ Guid.NewGuid().ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString() + Fi.Extension;
                var path = Path.Combine("", hosting.WebRootPath + "\\images\\" + filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return path;
            }
            catch (Exception e)
            {
                logger.LogError($"[{e.GetBaseException()}]");
                return null;
            }
        }
        public bool DeleteImage(string path)
        {
            try
            {
                FileInfo Fi = new FileInfo(path);
                System.IO.File.Delete(path);
                Fi.Delete();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"[{e.GetBaseException()}]");
                return false;
            }
        }
        public bool CheckFormat(string FileName)
        {
            try
            {
                string[] extensions=new string[] { ".jpg",".png"};
                var extension = Path.GetExtension(FileName);
                if (!extensions.Contains(extension.ToLower()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"[{e.GetBaseException()}]");
                return false;
            }
        }

    }
}

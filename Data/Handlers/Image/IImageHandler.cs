using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Handlers.Image
{
    public interface IImageHandler
    {
        string UploadImage(IFormFile file);
        bool DeleteImage(string path);
    }
}

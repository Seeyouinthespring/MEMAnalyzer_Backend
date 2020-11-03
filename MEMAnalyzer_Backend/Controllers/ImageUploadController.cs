using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Image")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IHostingEnvironment _environment;

        public ImageUploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        protected async Task<string> UploadImageAsync([FromForm] IFormFile files)
        {
            if (files.Length > 0)
            {
                try
                {
                    var filePath = Path.Combine("Uploads\\");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    using FileStream filestream = System.IO.File.Create(filePath + files.FileName);
                    files.CopyTo(filestream);
                    await filestream.FlushAsync();
                    return "\\Uploads\\" + files.FileName;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }

        protected async Task<FileContentResult> GetImage(string fileName)
        {
            byte[] result;
            var filePath = Path.Combine("Uploads\\" + fileName);
            if (!System.IO.File.Exists(filePath))
                return null;
            result = await System.IO.File.ReadAllBytesAsync(filePath);

            return new FileContentResult(result, "image/jpeg");
        }

        protected async Task<byte[]> GetImageBytes(string fileName)
        {
            byte[] result;
            var filePath = Path.Combine("Uploads\\" + fileName);
            if (!System.IO.File.Exists(filePath))
                return null;
            result = await System.IO.File.ReadAllBytesAsync(filePath);
            return result;
        }
    }
}

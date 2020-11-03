using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Memes")]
    [ApiController]
    public class MemesController : ImageUploadController
    {
        private readonly IMemesService _memesService;
        
        public MemesController(IMemesService memesService, IHostingEnvironment environment) : base(environment)
        {
            _memesService = memesService;
        }

        /// <summary>
        /// Get all memes with pictures in byte[] and info
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMemes")]
        [Swagger200(typeof(List<IActionResult>))]
        public async Task<IActionResult> GetMemes()
        {
            List<MemViewModel> result = await _memesService.GetAllMemesAsync();
            foreach (var i in result) 
            {
                i.ImageBytes = await GetImageBytes(i.Picture);
            }
            return new JsonResult(result);
        }

        /// <summary>
        /// Upload file to the project
        /// </summary>
        /// <param name="files">Uploading file. Example key.jpg</param>
        /// <returns></returns>
        [HttpPost("UploadMem")]
        [Swagger200(typeof(string))]
        public async Task<string> AddImage([FromForm] IFormFile files)
        {
            return await UploadImageAsync(files);
        }

        /// <summary>
        /// Get one mem as a picture by fileName
        /// </summary>
        /// <param name="fileName">Name of the file. Example keys.jpg</param>
        /// <returns></returns>
        [Swagger200(typeof(List<FileContentResult>))]
        [HttpGet("GetRealMem")]
        public async Task<IActionResult> GetRealImage([FromQuery] string fileName)
        {

            FileContentResult a = await GetImage(fileName);
            if (a == null) 
                return new JsonResult( new { Message = "file doesn`t exist"});
            return a;
        }
    }
}

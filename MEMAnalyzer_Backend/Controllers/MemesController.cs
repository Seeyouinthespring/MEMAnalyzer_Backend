using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Memes")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IMemesService _memesService;
        private readonly IHostingEnvironment _environment;


        public MemesController(IMemesService memesService, IHostingEnvironment environment)
        {
            _memesService = memesService;
            _environment = environment;
        }

        /// <summary>
        /// Get all memes with pictures in byte[]
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMemes")]
        [Swagger200(typeof(List<IActionResult>))]
        public async Task<IActionResult> GetMemes()
        {
            List<MemViewModel> result = await _memesService.GetAllMemesAsync();   
            return new JsonResult(result);
        }

        /// <summary>
        /// Upload file to the project
        /// </summary>
        /// <param name="files">Uploading file. Example brokendog</param>
        /// <param name="categoryId">Category of the mem. Example 1 or 2 or 3 or 4 or 5</param>
        /// <returns></returns>
        [HttpPost("UploadMem")]
        [Swagger200(typeof(string))]
        public async Task<string> AddImage([FromForm] IFormFile files, [FromQuery] long categoryId)
        {
            try 
            {
                if (files == null || files.Length == 0)
                    return "the file is empty";

                byte[] fileBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    await files.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                if (!await _memesService.AddMemAsync(fileBytes, files.FileName, categoryId))
                    return "an error ocured while additing mem to the database";
                return "picture was successfuly added";
            }
            catch (Exception ex) 
            { 
                return ("error: " + ex); 
            }
        }

        /// <summary>
        /// Get one mem as a picture by Name
        /// </summary>
        /// <param name="name">Name of the file. Example keys.jpg</param>
        /// <returns></returns>
        [Swagger200(typeof(List<IActionResult>))]
        [HttpGet("GetRealMem")]
        public async Task<IActionResult> GetRealImage([FromQuery] string name)
        {
            byte[] fileBytes = await _memesService.GetMemBytesAsync(name);
            if (fileBytes == null)
                return BadRequest("Mem with that code not found");

            FileContentResult image = new FileContentResult(fileBytes, "image/jpeg"); ;
            if (image == null) 
                return new JsonResult( new 
                { 
                    Message = "file doesn`t exist"
                });
            return image;
        }
    }
}

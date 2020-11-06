using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Memes")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IMemesService _memesService;


        public MemesController(IMemesService memesService)
        {
            _memesService = memesService;
        }

        /// <summary>
        /// Get all memes with pictures in byte[]
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMemes")]
        [Swagger200(typeof(List<MemViewModel>))]
        public async Task<IActionResult> GetMemes()
        {
            List<MemViewModel> result = await _memesService.GetAllMemesAsync();
            return new JsonResult(result);
        }

        /// <summary>
        /// Upload file to the project
        /// </summary>
        /// <param name="file">Uploading file string. Example brokendog</param>
        /// <param name="categoryId">Category of the mem. Example 1 or 2 or 3 or 4 or 5</param>
        [HttpPost("UploadMem")]
        [Swagger200(typeof(string))]
        public async Task<string> AddImage([FromQuery] string file, [FromQuery] long categoryId)
        { 
            if (file == null || file.Length == 0)
                return "the file is empty";
            if (!await _memesService.AddMemAsync(file, categoryId))
                return "an error ocured while additing mem to the database";
            return "picture was successfuly added";   
        }

        /// <summary>
        /// Calculate results
        /// </summary>
        /// <param name="results">List of users answers. Example [{1,5},{12,3},{29,1}]</param>
        /// <returns></returns>
        [Swagger200(typeof(ResultViewModel))]
        [HttpPost("Result")]
        public async Task<IActionResult> HandleResult([FromBody][Required][MinLength(1)] ResultToHandleModel[] results)
        {
            ResultViewModel model = await _memesService.CalculateResultAsync(results.ToList());
            if (model == null)
                return new JsonResult(new
                {
                    Message = "something went wrong, sorry"
                });
            return new JsonResult(model);
        }
    }
}

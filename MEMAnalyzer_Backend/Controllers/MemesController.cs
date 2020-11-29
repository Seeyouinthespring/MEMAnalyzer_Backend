using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Business.Constants;
using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        public async Task<string> AddImage([FromQuery][Required] string file, [FromQuery][Required] long categoryId)
        { 
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
            DateTime currentDate = GetCurrentDate();
            string currentUserId = GetCurrentUserId();
            ResultViewModel model = await _memesService.CalculateResultAsync(results.ToList(), currentUserId, currentDate);
            if (model == null)
                return new JsonResult(new
                {
                    Message = "something went wrong, sorry"
                });
            return new JsonResult(model);
        }

        internal DateTime GetCurrentDate()
        {
            string dateFromRequest = Request.Headers["Current-Date"].ToString();
            if (string.IsNullOrEmpty(dateFromRequest))
                return DateTime.Now;
            return DateTime.TryParse(dateFromRequest, null, DateTimeStyles.AdjustToUniversal, out var currentDate) ? currentDate : DateTime.Now;
        }

        /// <summary>
        /// Get mem by id
        /// </summary>
        /// <param name="id">id of a mem. Example 1</param>
        /// <returns></returns>
        [Swagger200(typeof(MemViewModel))]
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        public async Task<IActionResult> GetMem(long id)
        {
            MemViewModel result = await _memesService.GetMemByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        /// <summary>
        /// Get mem by id
        /// </summary>
        /// <param name="id">id of a mem. Example 1</param>
        /// <param name="model">model of mem to update</param>
        /// <returns></returns>
        [Swagger200(typeof(MemViewModel))]
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        public async Task<IActionResult> UpdateMem(long id, MemDtoModel model)
        {
            MemViewModel result = await _memesService.UpdateMemAsync(id, model);

            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        internal string GetCurrentUserId()
        {
            return TokenHelper.GetCurrentUserId(Request);
        }

        /// <summary>
        /// Get random mem
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(MemViewModel))]
        [HttpGet("Random")]
        public async Task<IActionResult> GetRandomMem()
        {
            MemViewModel result = await _memesService.GetRandomMemAsync();

            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }
    }
}

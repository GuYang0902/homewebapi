using System;
using System.Collections.Generic;
using System.IO;
using Chloe;
using Chloe.MySql;
using home.api.Model;
using home.dbhelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace home.api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return null;
        }
        [HttpPost]
        public IActionResult Post([FromForm(Name = "file")] IFormFile file)
        {
            if (file == null) return BadRequest();
            string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {

                file.CopyTo(fileStream);
            }
         return Ok("success");
    }
        [HttpGet]
        public IActionResult Get(IFormFile input)
        {
          
            return Ok();
        }
    }
}

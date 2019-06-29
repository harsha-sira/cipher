using System.Data.Common;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.IO.Enumeration;
using System.Net.Http;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;

namespace cipher.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase 
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }
        
        // GET  api/v1/files/download
        [HttpGet("download")]
        public async Task<IActionResult> Download(string filename)  
        {  
            if (filename == null)  
                return Content("filename not present");  
        
            var path = Path.Combine(  
                            Directory.GetCurrentDirectory(),  
                            "upload", filename);  
        
            var memory = new MemoryStream();  
            using (var stream = new FileStream(path, FileMode.Open))  
            {  
                await stream.CopyToAsync(memory);  
            }  
            memory.Position = 0;  
            return File(memory, "text/plain", Path.GetFileName(path));  
        } 

        // POST  api/v1/files/upload
        [HttpPost("Upload")]
        public async Task<IActionResult> uploadFiles(IFormFile file)
        {
            if (file == null || file.Length == 0)  
                return Content("file not selected");  
            
            var path = Path.Combine(  
                        Directory.GetCurrentDirectory(), "upload",   
                        file.FileName);  
    
            using (var stream = new FileStream(path, FileMode.Create))  
            {  
                await file.CopyToAsync(stream);  
            }     
  
            return Ok(new { file.FileName});
        }

    } 
}

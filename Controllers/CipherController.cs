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
    public class CipherController : ControllerBase 
    {
        // GET  api/v1/cipher/encode
        [HttpGet("encode")]
        public async Task<string> cipherEncode(string filename)
        {
            var result = new StringBuilder();
            var path = Path.Combine(  
                        Directory.GetCurrentDirectory(), "upload",   
                        filename);
            FileStream fileStream = new FileStream(path, FileMode.Open);            
            using (var reader = new StreamReader(fileStream))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync()); 
            }
            return result.ToString();
        //    return Ok( new { filename });
        }

    }
}
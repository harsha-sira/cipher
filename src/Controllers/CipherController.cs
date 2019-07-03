using System.Threading.Tasks.Dataflow;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
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
using cipher.Utility;
using Newtonsoft.Json;
using System.Diagnostics;

namespace cipher.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CipherController : ControllerBase 
    {

        /// <summary>
        /// generate  a cipher and save in a file.
        /// </summary>
        
        // GET  api/v1/cipher/encode
        [HttpGet("encode")]
        public async Task<IActionResult> cipherEncode(string filename)
        {
            var result = new StringBuilder();
            var path = Path.Combine(  
                        Directory.GetCurrentDirectory(), "upload",   
                        filename);

            byte[] buffer  = new byte[2048];
            KeyStore.getStoreInsatance();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, (buffer.Length*2),  FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                int readSize = await file.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(true);

                while( readSize > 0)
                {
                    result.Append( GenerateCipher.CipherString( System.Text.Encoding.UTF8.GetString(buffer).ToCharArray()) );
                    // Console.WriteLine("***************** enctpting ... " +  System.Text.Encoding.UTF8.GetString(buffer));
                    readSize = await file.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(true);
                }
            }
            sw.Stop();
            Console.WriteLine($"***************** Read() Took {sw.ElapsedMilliseconds}ms");
            
            // writes ciphered string to file
            // string s = GenerateCipher.CipherString(result.ToString());
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine(result.ToString());
            }
            
            return Ok( new { filename });
        }

    }
}
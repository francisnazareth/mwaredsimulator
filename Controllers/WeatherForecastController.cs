using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.IO;
using System.Text;

namespace mwared2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/xml")]
        //[Produces("application/xml")]
        public string PostXml([FromBody] XElement xml)
        {
            var xmlElement = xml.Descendants("IM_BUKRS").FirstOrDefault()?.Value;

            if (xmlElement == null)
            {
                string returnValue = xml.Value; 
                return returnValue;
            }

            string path = Environment.GetEnvironmentVariable("FILE_PATH") ?? @"C:\Work\2024\GAC\";
            string fileName = path + xmlElement + ".xml";

            string readText = System.IO.File.ReadAllText(fileName);
            Console.WriteLine(readText);

            return readText;
        }

    }
}

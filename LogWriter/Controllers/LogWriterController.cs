using LogWriter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogWriter.Controllers
{
    [RoutePrefix("api")]
    public class LogWriterController : ApiController
    {
        private static readonly string logLocation = @"c:\MobileCrashes\";
        [Route("ping")]
        [HttpGet]
        public string[] Ping()
        {
            return new string[]
            {
                "Hello",
                "World"
            };
        }

        [Route("write")]
        [HttpPost]
        public HttpStatusCode writeLog(Log data)
        {
            if (!ModelState.IsValid)
                return HttpStatusCode.BadRequest;
            // Check if log directory exists
            if (!Directory.Exists(logLocation))
                Directory.CreateDirectory(logLocation);

            // Check if directory for device exists
            string directoryToBeWrittenIn = logLocation + @"\" + data.deviceId;
            if (!Directory.Exists(directoryToBeWrittenIn))
                Directory.CreateDirectory(directoryToBeWrittenIn);

            //Write the file with stacktrace
            string fileToBeWritten = directoryToBeWrittenIn + @"\" + data.timestamp + @".crash";
            File.WriteAllText(fileToBeWritten, data.stacktrace);

            return HttpStatusCode.NoContent;
        }
    }
}

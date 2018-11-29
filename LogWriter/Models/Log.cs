using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogWriter.Models
{
    public class Log
    {
        public string deviceId { get; set; }
        public string timestamp { get; set; }
        public string stacktrace { get; set; }
    }
}
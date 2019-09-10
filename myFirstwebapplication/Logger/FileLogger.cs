using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstwebapplication.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("D://Error//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new string[]
                {
                    "Message:"+e.Message,
                    "Stacktrace:"+e.StackTrace
                });
        }
    }
}
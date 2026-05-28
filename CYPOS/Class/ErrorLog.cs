using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace cypos
{
    public class ErrorLog
    {
        public void Write(string Message, string Source,string Path)
        {
            string filename = "errlog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string filepath = Path + filename;
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine("-------------------START-----------------------");
                    writer.WriteLine("Date   : " + DateTime.Now); 
                    writer.WriteLine("Source : " + Source);
                    writer.WriteLine("Error  : " + Message);
                    writer.WriteLine("-------------------END-------------------------");
                }
            }
            else
            {
                StreamWriter writer = File.CreateText(filepath);
                writer.WriteLine("-------------------START-----------------------");
                writer.WriteLine("Date   : " + DateTime.Now);
                writer.WriteLine("Source : " + Source);
                writer.WriteLine("Error  : " + Message);
                writer.WriteLine("-------------------END-------------------------");
                writer.Close();
            }
        }
    }
}




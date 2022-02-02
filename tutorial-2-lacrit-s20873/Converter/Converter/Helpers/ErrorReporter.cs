using System;
using System.IO;

namespace Converter.Helpers
{
    //used for printing errors to log.txt
    public class ErrorReporter
    {
        public static void ReportOnError(Exception exception)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                string error = "\t *** Error report *** \n [" + DateTime.Now + "] " + exception.Message + "\n";
                sw.WriteLine(error);
            }
        }
    }
}

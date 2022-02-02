using Converter.Helpers;
using System.IO;
using System;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = IsEmpty(args, 0) ? args[0] : "./Data/dane.csv";
            string dataFormat = IsEmpty(args, 2) ? args[2] : "json";
            string destPath = IsEmpty(args, 1) ? args[1] : $"result.{dataFormat}";
            if (!File.Exists(path))
            {
                ErrorReporter.ReportOnError(new FileNotFoundException("File does not exist"));
                System.Environment.Exit(0);
            }
            FileInfo fi = new FileInfo(path);
            var university = UniversityCreator.CreateUniversity(fi);
            string jsonString = Serializer.SerializeToJson(university);
            File.WriteAllText(destPath, jsonString);
        }

        static bool IsEmpty(string [] args, int i)
        {
            return args.Length > i;
        }
    }
}

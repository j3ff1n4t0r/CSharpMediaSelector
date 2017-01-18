using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MediaSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = "test";
            var directory = ConfigurationManager.AppSettings["Directory"];
            var desiredFile = CalculateMostRelevantFile(GetFileNameList(directory), query);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = ConfigurationManager.AppSettings["VLCDirectory"];
            startInfo.Arguments = GenerateCommandLineString(desiredFile);
            process.StartInfo = startInfo;
            process.Start();
        }

        static List<string> GetFileNameList(string directory)
        {
            var d = new DirectoryInfo(directory);
            var files = d.GetFiles("*.mp4");
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                fileNames.Add(file.Name);
            }
            return fileNames;
        }

        static string CalculateMostRelevantFile(List<string> fileNames, string query)
        {
            return fileNames.First();
        }

        static string GenerateCommandLineString(string fileName)
        {
            return "vlc " + ConfigurationManager.AppSettings["Directory"] + fileName;
        }


    }
}

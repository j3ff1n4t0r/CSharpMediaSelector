using System.Diagnostics;

namespace MediaSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}

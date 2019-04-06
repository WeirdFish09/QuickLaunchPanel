using System.Diagnostics;
namespace QuickLaunchPanel
{
    public static class BashExtension
    {
        public static void Bash(this string command){
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName="/bin/bash";
            psi.Arguments=" -c " + command;
            process.StartInfo = psi;
            process.Start();
        }
    }
}
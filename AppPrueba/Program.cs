using System;

namespace AppPrueba
{
    class Program
    {
        static void ExecuteCommand(string _Command)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            procStartInfo.CreateNoWindow = true;

            //Initialize the process
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(result);
            proc.Close();
        }
        static void ResolutionQuality(string quality, string carpet,string name)
        {
            //Video Resolution Quality
            string command;
            switch (quality)
            {
                case "webm":
                    //Same Resolution
                    command = "ffmpeg -i " + carpet + "/" + name + ".webm" + " " + carpet + "/" + name + "W.webm";
                    break;
                case "high":
                    //Resolution of video XGA "1024x768"
                    //PixelesK "786 K"
                    command = "ffmpeg -i " + carpet + "/" + name + ".webm" + " -s 1024x768 " + carpet + "/" + name + "H.webm";
                    break;
                case "medium":
                    //Resolution of video SVGA "800x600"
                    //PixelesK "480 K"
                    command = "ffmpeg -i " + carpet + "/" + name + ".webm" + " -s 800x600 " + carpet + "/" + name + "M.webm";
                    break;
                case "low":
                    //Resolution of video MCGA o VGA "640x480"
                    //PixelesK "307 K"
                    command = "ffmpeg -i " + carpet + "/" + name + ".webm" + " -s 640x480 " + carpet + "/" + name + "L.webm";
                    break;
                default:
                    command = "";
                    break;
            }
            ExecuteCommand(command);
        }
        static void Main(string[] args)
        {
            //ResolutionQuality("webm", "videos", "vid");
            ResolutionQuality("low", "videos", "video");
            ResolutionQuality("medium", "videos", "video");
            ResolutionQuality("high", "videos", "video");
        }
    }
}

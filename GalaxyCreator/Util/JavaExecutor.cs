using System;
using System.Diagnostics;

namespace GalaxyCreator.Util
{
    class JavaExecutor
    {
        public static void execute(string jar, string filename)
        {
            string cmd = "-jar \"" + jar + "\" \"" + filename + "\"";
            var processInfo = new ProcessStartInfo("java.exe", cmd)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process proc;

            if ((proc = Process.Start(processInfo)) == null)
            {
                throw new InvalidOperationException("??");
            }

            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            proc.Close();
        }
    }
}

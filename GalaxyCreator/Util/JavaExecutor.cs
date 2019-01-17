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

            var result = proc = Process.Start(processInfo);

            if (result == null)
            {
                throw new InvalidOperationException("??");
            }

            if (result.ExitCode != 0)
            {
                throw new InvalidOperationException("Java Execution Failed");
            }


            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            proc.Close();
        }
    }
}

using System;
using System.Diagnostics;

namespace Bit.Helpers.Console
{
    public class RunHelpers
    {
        public void SyncProcess(string command)
        {
            var process = Process.Start("cmd.exe", String.Format("/C {0}", command));

            if (process != null)
            {
                process.WaitForExit();
            }
        }

        public Process AsyncProcess(string command)
        {
            return Process.Start("cmd.exe", String.Format("/C {0}", command));
        }
    }
}
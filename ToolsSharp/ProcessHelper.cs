using System.Diagnostics;
using System.Management;
using System.Runtime.Versioning;

namespace ToolsSharp
{
    /// <summary>
    /// A helper class to make it easier to work with windows process'
    /// </summary>
    /// <remarks>Windows Only</remarks>
    [SupportedOSPlatform("windows")]
    public static class ProcessHelper
    {
        public static void KillProcessAndChildrens(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            // We must kill child processes first!
            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillProcessAndChildrens(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
            }

            // Then kill parents.
            try
            {
                Process proc = Process.GetProcessById(pid);
                if (proc != null && !proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
    }
}
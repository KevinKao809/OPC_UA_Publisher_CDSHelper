using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpcPublisher
{
    // This Class be Added by Kevin Kao for CDS Integration
    public class PerformanceView
    {
        public static string cpuPerformance = "CPU_Usage";
        public static string memoryAvailable = "Memory_Usage";
        public static Process proc = Process.GetCurrentProcess();

        public static double GetCPUPerformance()
        {
            return Math.Round(proc.TotalProcessorTime.TotalSeconds, 2);
        }

        public static double GetMemeoryAvailable()
        {
            return Math.Round((double)(proc.WorkingSet64 / 1024 / 1024), 2);
        }
    }
}

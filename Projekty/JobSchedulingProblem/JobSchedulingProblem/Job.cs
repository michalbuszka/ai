using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public interface IJob
    {
        public double timeDuration { get; set; }
        public int k { get; set; } 
        public double startTime { get; set; }
        public double endTime { get; set; }
    }
    public class Job : IJob
    {
        public double timeDuration { get; set; }
        public int k { get; set; } //indeks procesora
        public double startTime { get; set; }
        public double endTime { get; set; }
        public Job (float timeDuration)
        {
            this.timeDuration = timeDuration;
        }
        public void DisplayInfo ()
        {
            Console.WriteLine("");
            Console.WriteLine($"Processor: {k}");
            Console.WriteLine($"Start time: {startTime}");
            Console.WriteLine($"End time: {endTime}");
            Console.WriteLine($"Duration: {timeDuration}");
        }
    }
}

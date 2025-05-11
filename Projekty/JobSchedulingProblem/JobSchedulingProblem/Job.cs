using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public class Job
    {
        public float timeDuration { get; set; }
        public int k { get; set; } //indeks procesora
        public float startTime { get; set; }
        public float endTime { get; set; }
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public class Job
    {
        public int timeDuration { get; set; }
        public int k { get; set; } //indeks procesora
        public float startTime { get; set; }
        public float endTime { get; set; }
    }
}

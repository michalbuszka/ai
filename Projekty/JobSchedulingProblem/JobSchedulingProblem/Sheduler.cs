using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public static class Sheduler
    {
        public static void Schedule (List<Job> jobs, IProcesor[] procesors)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                int index = new Random().Next(0, procesors.Length - 1);
                procesors[index].AddJob(jobs[i]);
            }
        }
    }
}

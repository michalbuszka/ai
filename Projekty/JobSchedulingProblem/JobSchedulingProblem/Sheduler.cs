using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public static class Sheduler
    {
        public static void Schedule (List<IJob> jobs, IProcesor[] procesors)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                int index = new Random().Next(0, procesors.Length - 1);
                procesors[index].AddJob(jobs[i]);
            }
        }
        public static void ReplaceJobs (List<IJob> jobs, IProcesor[] procesors, IJob job1, IJob job2)
        {
            procesors[job1.k].RemoveJob(job1);
            procesors[job2.k].RemoveJob(job2);
            procesors[job1.k].AddJob(job2);
            procesors[job2.k].AddJob(job1);
            procesors[job1.k].RecalculateJobs();
            procesors[job2.k].RecalculateJobs();
        }
    }
}

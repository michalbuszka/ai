using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public interface IProcesor
    {
        public void AddJob(IJob job);
        public void RemoveJob(IJob job);
        public double t { get; set; }
        public int index { get; set; }
        public void RecalculateJobs();
    }
    public class Procesor : IProcesor
    {
        public Procesor (int index)
        {
            this.index = index;
        }
        public int index { get; set; } 
        private List<IJob> jobs = new List<IJob>();
        public double t { get; set;  } //obecny czas
        public void AddJob(IJob job)
        {
            job.k = index;
            job.startTime = t;
            t += job.timeDuration;
            job.endTime = t;
            jobs.Add(job);
        }
        public void RemoveJob (IJob job)
        {
            if (jobs.Contains(job))
            {
                jobs.Remove(job);
                RecalculateJobs();
            }
        }
        public void RecalculateJobs ()
        {
            t = 0.0f;   
            foreach (var job in jobs)
            {
                job.startTime = t;
                t += job.timeDuration;
                job.endTime = t;
            }
        }
    }
}

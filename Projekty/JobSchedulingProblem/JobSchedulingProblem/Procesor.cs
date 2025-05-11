using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public interface IProcesor
    {
        public void AddJob(Job job);
    }
    public class Procesor : IProcesor
    {
        public Procesor (int index)
        {
            this.index = index;
        }
        private int index;
        private List<Job> jobs = new List<Job>();
        private float t; //obecny czas
        public void AddJob(Job job)
        {
            job.k = index;
            job.startTime = t;
            t += job.timeDuration;
            job.endTime = t;
            jobs.Add(job);
        }
    }
}

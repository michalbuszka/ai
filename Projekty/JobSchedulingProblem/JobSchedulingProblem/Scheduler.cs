using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public class Scheduler
    {
        private List<IJob> jobs;
        private IProcesor[] procesors;
        public Scheduler(List<IJob> jobs, IProcesor[] procesors) 
        {
            this.jobs = jobs;
            this.procesors = procesors;
        }
        public void Schedule ()
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                int index = new Random().Next(0, procesors.Length);
                procesors[index].AddJob(jobs[i]);
            }
        }
        public double f() //funkcja zwracająca czas wykonania wszystkich zadań na wszystkich procesorach
        {
            double maxTime = 0;
            foreach (IProcesor procesor in procesors)
            {
                if (procesor.t > maxTime)
                    maxTime = procesor.t;
            }
            return maxTime;
        }
        public double CheckReplaceTimeDifference (IJob job1, IJob job2) //funkcja W
        {
            double newk1Time = procesors[job1.k].t - job1.timeDuration + job2.timeDuration;
            double newk2Time = procesors[job2.k].t + job1.timeDuration - job2.timeDuration;
            double newMaxTime = 0;
            foreach (IProcesor procesor in procesors)
            {
                if (procesor == procesors[job1.k])
                {
                    if (newk1Time > newMaxTime)
                    {
                        newMaxTime = newk1Time;
                        continue;
                    }
                }
                if (procesor == procesors[job2.k])
                {
                    if (newk2Time > newMaxTime)
                    {
                        newMaxTime = newk2Time;
                        continue;
                    }
                }
                if (procesor.t > newMaxTime)
                    newMaxTime = procesor.t;
            }
            return newMaxTime - f();
        }
        public void DisplayThreadsTime ()
        {
            foreach (IProcesor procesor in procesors)
            {
                Console.WriteLine($"Procesor {procesor.index} Czas: {procesor.t}");
            }
        }
        public void ReplaceJobs (IJob job1, IJob job2)
        {
            //Console.WriteLine($"Zamieniam: {job1.k} {job1.timeDuration} z {job2.k} {job2.timeDuration}");
            //DisplayThreadsTime();
            int job1OldIndex = job1.k;
            int job2OldIndex = job2.k;
            procesors[job1OldIndex].RemoveJob(job1);
            procesors[job2OldIndex].RemoveJob(job2);
            procesors[job1OldIndex].AddJob(job2);
            procesors[job2OldIndex].AddJob(job1);
            procesors[job1.k].RecalculateJobs();
            procesors[job2.k].RecalculateJobs();
            //Console.WriteLine("PO ZAMIANIE: ");
            //DisplayThreadsTime();
        }
    }
}

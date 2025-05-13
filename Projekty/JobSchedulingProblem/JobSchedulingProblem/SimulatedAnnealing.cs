using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulingProblem
{
    public class SimulatedAnnealing
    {
        private List<IJob> jobs;
        private IJob[] bestSoluction;
        public double bestSolutionTime { get; set; }
        private Scheduler scheduler;
        private double t;
        private double coolingRate = 0.95;
        private double absoluteTemperature = 0.0001;
        private double tolerance;
        private double temperature = 100.0;
        private void SetBestSolution ()
        {
            bestSoluction = new IJob[jobs.Count];
            Array.Copy(jobs.ToArray(), bestSoluction, jobs.Count);
            t = scheduler.f();
            bestSolutionTime = t;
        }
        public SimulatedAnnealing(List<IJob> jobs, Scheduler scheduler)
        {
            this.jobs = jobs;
            this.scheduler = scheduler;     
        }
        public void SimulatedAnnealingMethod ()
        {
            scheduler.Schedule();
            Console.WriteLine($"Początkowy czas wykonania wszystkich zadań na wszystkich procesorach: {scheduler.f()}");
            SetBestSolution();
            while (temperature > absoluteTemperature)
            {
                tolerance = bestSolutionTime * 0.01f; //1%
                int random1 = new Random().Next(0, jobs.Count);
                int random2 = new Random().Next(0, jobs.Count);
                IJob job1;
                IJob job2;
                do
                {
                    random1 = new Random().Next(0, jobs.Count);
                    job1 = jobs.ToArray()[random1];
                    random2 = new Random().Next(0, jobs.Count);
                    job2 = jobs.ToArray()[random2];
                } while(job1.k == job2.k);
                double newDeltaTime = scheduler.CheckReplaceTimeDifference(job1, job2);
                if (t + newDeltaTime < bestSolutionTime)
                {
                    scheduler.ReplaceJobs(job1, job2);
                    //Console.WriteLine($"Zamieniam: {job1.k} z {job2.k}");
                    //scheduler.DisplayThreadsTime();
                    //Console.WriteLine($"NOWE NAJLEPSZE WYLICZONE: {t + newDeltaTime}");
                    SetBestSolution();
                    temperature *= coolingRate;
                    //scheduler.DisplayThreadsTime();
                    //Console.WriteLine($"NOWE NAJLEPSZE: {bestSolutionTime}");
                    continue;
                }
                if (newDeltaTime <= tolerance)
                {
                    scheduler.ReplaceJobs(job1, job2);
                    t = scheduler.f();
                    //Console.WriteLine($"AKCEPTOWALNE: {t + newDeltaTime}");
                }
                temperature *= coolingRate;
            }
            Console.WriteLine($"Końcowy czas wykonania wszystkich zadań na wszystkich procesorach: {bestSolutionTime}");
        }
    }
}

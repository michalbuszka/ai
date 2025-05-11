using JobSchedulingProblem;
using System;

namespace Program
{
    public static class Program 
    {
        private static List<Job> jobs = new List<Job>();
        private static IProcesor[] procesors;
        private static int k = 5; //liczba procesorów;
        private static int n = 100; //liczba zadań
        private static float tMax = 10000; //zadany maskymalny czas
        private static float maxJobTime = 100;
        private static void RandomizeJobs ()
        {
            for (int i = 0; i < n; i++)
                jobs.Add(new Job((float)new Random().NextDouble() * maxJobTime));
        }
        public static void Main(string[] args)
        {
            procesors = new Procesor[k];
            for (int i = 0; i < procesors.Length; i++)
            {
                procesors[i] = new Procesor(i);
            }
            RandomizeJobs();
            Sheduler.Schedule(jobs, procesors);
            foreach (Job job in jobs)
            {
                job.DisplayInfo();
            }
        }
    }
}
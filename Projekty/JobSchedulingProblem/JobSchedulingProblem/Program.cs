using JobSchedulingProblem;
using System;

namespace Program
{
    public static class Program 
    {
        private static List<IJob> jobs = new List<IJob>();
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
        public static float f () //funkcja zwracająca czas wykonania wszystkich zadań na wszystkich procesorach
        {
            float maxTime = 0;
            foreach(IProcesor procesor in procesors)
            {
                if (procesor.t > maxTime)
                    maxTime = procesor.t;
            }
            return maxTime;
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
            //foreach (Job job in jobs)
            //{
            //    job.DisplayInfo();
            //}
            Console.WriteLine($"Czas wykonania wszystkich zadań na wszystkich procesorach: {f()}" );
            int random = new Random().Next(0, jobs.Count);
            IJob job1 = jobs.ToArray()[random];
            random = new Random().Next(0, jobs.Count);
            IJob job2 = jobs.ToArray()[random];
            Sheduler.ReplaceJobs(jobs, procesors, job1, job2);
            Console.WriteLine($"Czas wykonania wszystkich zadań na wszystkich procesorach v2: {f()}");
        }
    }
}
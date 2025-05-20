using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Program
{
    public class Program
    {
        static int orły = 5;
        static int reszki = 17;
        static Random random = new Random();
        // Posterior 
        static double Posterior(double theta)
        {
            if (theta < 0 || theta > 1)
                return 0.0;

            return Math.Pow(theta, orły) * Math.Pow(1 - theta, reszki);
        }
        // Metropolis-Hastings
        static List<double> MetropolisHastings(double wartośćPoczątkowaParametru = 0.5, int liczbaIteracji = 5000, double proposalStd = 0.05)
        {
            List<double> samples = new List<double>();
            double current = wartośćPoczątkowaParametru;

            for (int i = 0; i < liczbaIteracji; i++)
            {
                double proposal = current + SampleNormal(0, proposalStd);
                double pCurrent = Posterior(current);
                double pProposal = Posterior(proposal);
                double acceptanceRatio = pCurrent == 0 ? 1.0 : Math.Min(1.0, pProposal / pCurrent);
                if (random.NextDouble() < acceptanceRatio)
                {
                    current = proposal;
                }
                samples.Add(current);
            }
            return samples;
        }
        // Próbkowanie z rozkładu normalnego (Box-Muller)
        static double SampleNormal(double mean, double stddev)
        {
            double u1 = 1.0 - random.NextDouble(); 
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stddev * randStdNormal;
        }
        static void PrintHistogram(List<double> samples, int binCount = 20)
        {
            var min = 0.0;
            var max = 1.0;
            var binWidth = (max - min) / binCount;
            int[] bins = new int[binCount];
            foreach (var sample in samples)
            {
                int binIndex = (int)((sample - min) / binWidth);
                if (binIndex >= 0 && binIndex < binCount)
                    bins[binIndex]++;
            }
            int maxHeight = bins.Max();
            for (int i = 0; i < binCount; i++)
            {
                double binStart = min + i * binWidth;
                string bar = new string('█', (int)(50.0 * bins[i] / maxHeight));
                Console.WriteLine($"{binStart:F2}-{(binStart + binWidth):F2}: {bar}");
            }
        }
        static void Main()
        {
            Console.WriteLine($"Dane Początkowe: liczba orłów:{orły} liczba reszek: {reszki}");
            var samples = MetropolisHastings();
            PrintHistogram(samples);
        }
    }
}
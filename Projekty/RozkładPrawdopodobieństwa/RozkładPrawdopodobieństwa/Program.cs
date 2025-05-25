using System;

namespace Program
{
    public class Program
    {
        public static double Beta (int alpha, int beta)
        {
            return GammaFunction.Gamma(Program.alpha) * GammaFunction.Gamma(beta) / GammaFunction.Gamma(alpha + beta);
        }
        public static double Beta(double theta, int alpha, int beta)
        {
            if (theta <= 0.0 || theta >= 1.0) return 0.0;
            return Math.Pow(theta, alpha - 1) * Math.Pow(1 - theta, beta - 1) / Beta(alpha, beta);
        }
        private const int alpha = 1;
        private const int beta = 1;
        private const int liczbaOrłów = 11;
        private const int liczbaResztek = 13;
        private static double CalcPd()
        {
            int alfaPrime = alpha + liczbaOrłów;
            int betaPrime = beta + liczbaResztek;
            return Beta(alfaPrime, betaPrime) / Beta(alpha, beta);
        }
        public static double CalcDOdTheta (double theta)
        {
            return Math.Pow(theta, liczbaOrłów) * Math.Pow(1 - theta, liczbaResztek - liczbaOrłów);
        }
        public static double calcTheta (double theta)
        {
            return CalcDOdTheta(theta) * Beta(theta, alpha, beta) / CalcPd();
        }
        public static void CalcRozkład()
        {
            List<(float theta, double value)> rawValues = new();
            double suma = 0;

            for (float theta = 0.05f; theta < 1.0f; theta += 0.05f)
            {
                double nieznormalizowane = CalcDOdTheta(theta) * Beta(theta, alpha, beta);
                rawValues.Add((theta, nieznormalizowane));
                suma += nieznormalizowane;
            }

            Console.WriteLine("Theta\tP(Theta | D)");
            foreach (var (theta, nieznormalizowane) in rawValues)
            {
                double normalized = nieznormalizowane / suma;
                Console.WriteLine($"{theta:F2}\t{normalized}");
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine($"Dla liczba orłów={liczbaOrłów}, liczba reszek={liczbaResztek}");
            CalcRozkład();
        }
    }
}
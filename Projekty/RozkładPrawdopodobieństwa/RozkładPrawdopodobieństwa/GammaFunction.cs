using System;

namespace Program
{
    public static class GammaFunction
    {
        // Stałe Lanczosa
        private static readonly double[] lanczosCoefficients = {
        676.5203681218851,
       -1259.1392167224028,
        771.32342877765313,
       -176.61502916214059,
        12.507343278686905,
       -0.13857109526572012,
        9.9843695780195716e-6,
        1.5056327351493116e-7
    };

        public static double Gamma(double z)
        {
            if (z < 0.5)
            {
                // Użyj refleksyjnej tożsamości gamma
                return Math.PI / (Math.Sin(Math.PI * z) * Gamma(1 - z));
            }
            else
            {
                z -= 1;
                double x = 0.99999999999980993;
                for (int i = 0; i < lanczosCoefficients.Length; i++)
                {
                    x += lanczosCoefficients[i] / (z + i + 1);
                }

                double t = z + lanczosCoefficients.Length - 0.5;
                return Math.Sqrt(2 * Math.PI) * Math.Pow(t, z + 0.5) * Math.Exp(-t) * x;
            }
        }
    }
}
using AlgorytmGenetyczny;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class Program
    {
        private const int RozmiarPopulacji = 100;
        private const int IlośćGenów = 50;
        private const float DoceloweDopasowanie = 0.9f;
        private const float SzansaMutacji = 0.05f;
        private static Solution[] populacja = new Solution[RozmiarPopulacji];
        private static Random random = new Random();

        private static void ZainicjujIGenerujPopulację()
        {
            for (int i = 0; i < RozmiarPopulacji; i++)
            {
                populacja[i] = new Solution(IlośćGenów);
                populacja[i].Random();
            }
        }

        private static Solution PorównanieGenów()
        {
            //losowanie dwóch kandydatów, wybieramy lepszego
            Solution s1 = populacja[random.Next(RozmiarPopulacji)];
            Solution s2 = populacja[random.Next(RozmiarPopulacji)];
            return s1.Fitness > s2.Fitness ? s1 : s2;
        }

        private static void Mutacja(Solution s)
        {
            for (int i = 0; i < IlośćGenów; i++)
            {
                if (random.NextDouble() < SzansaMutacji)
                {
                    s.Geny[i] = 1 - s.Geny[i]; 
                }
            }
        }
        public static void Main(string[] args)
        {
            ZainicjujIGenerujPopulację();
            int pokolenie = 0;
            while (true)
            {
                pokolenie++;
                Solution[] nowaPopulacja = new Solution[RozmiarPopulacji];
                for (int i = 0; i < RozmiarPopulacji; i++)
                {
                    Solution rodzic1 = PorównanieGenów();
                    Solution rodzic2 = PorównanieGenów();
                    Solution potomek = rodzic1.Crossover(rodzic2); // << użycie Twojej metody
                    Mutacja(potomek);
                    nowaPopulacja[i] = potomek;
                }
                populacja = nowaPopulacja;
                float najlepszeDopasowanie = populacja.Max(p => p.Fitness);
                Console.WriteLine($"Pokolenie {pokolenie}: Najlepsze dopasowanie = {najlepszeDopasowanie:F2}");
                if (najlepszeDopasowanie >= DoceloweDopasowanie)
                    break;
            }
            populacja.OrderByDescending(p => p.Fitness).First().Display();
        }
    }
}

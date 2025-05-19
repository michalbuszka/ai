using AlgorytmGenetyczny;
using System;
using System.Security.Cryptography;

namespace Program
{
    public class Program
    {
        private const int RozmiarPopulacji = 100;
        private const int IlośćGenów = 10;
        private const float DoceloweDopasowanie = 0.7f;
        private static Solutiuon[] populacja = new Solutiuon[RozmiarPopulacji];
        private static Dictionary<Solutiuon, float> populationFitness = new Dictionary<Solutiuon, float>();
        private static void GeneratePopulationFitness ()
        {
            foreach (Solutiuon s in populacja)
            {
                populationFitness[s] = s.Fitness;
            }
        }
        private static void ZainicjujIGenerujPopulację ()
        {
            for (int i = 0; i < RozmiarPopulacji; i++)
            {
                populacja[i] = new Solutiuon(IlośćGenów);
                populacja[i].Random();
            }
        }
        public static void Main(string[] args)
        {
            ZainicjujIGenerujPopulację();
            GeneratePopulationFitness();
            var sortedPopulation = populationFitness.OrderBy(para => para.Value);
            float najlepszeDopasowanie = populationFitness.Values.Max();
            //while (najlepszeDopasowanie >= DoceloweDopasowanie)
            //{

            //}
        }
    }
}
using AlgorytmGenetyczny;
using System;

namespace Program
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Solutiuon s1 = new Solutiuon(10);
            Solutiuon s2 = new Solutiuon(10);
            s1.Display();
            s2.Display();
            s1.Crossover(s2, 2, 2);
            s1.Display();
        }
    }
}
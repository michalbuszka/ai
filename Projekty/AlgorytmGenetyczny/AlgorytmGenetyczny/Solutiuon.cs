using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public class Solutiuon
    {
        private int IlośćGenów;
        private int[] Geny;
        public int[] GenySubstring (int start, int length)
        {
            if (start + length > Geny.Length)
                throw new Exception("Rozmiar tablicy został przekroczony");
            int[] returnArray = new int[Geny.Length];
            for (int i = 0; i < length; i++)
            {
                returnArray[i] = Geny[i + start];   
            }
            return returnArray;
        }
        private float getFitness ()
        {
            int counter = 0;
            foreach (int gen in Geny)
            {
                counter += gen;
            }
            return (float)counter / Geny.Length;
        }
        public float Fitness { 
            get 
            {
                return getFitness(); 
            }
        }    
        public void Crossover (Solutiuon s1, int start, int length)
        {
            for (int i = 0; i < length; i++)
                Geny[i + start] = Geny[i];
        }
        public void Random ()
        {
            Geny = new int[IlośćGenów];
            Random random = new Random();
            for (int i = 0; i < Geny.Length; i++ )
            {
                Geny[i] = random.Next(0, 2);
            }
        }
        public void Display ()
        {
            Console.WriteLine();
            foreach (int g in Geny)
            {
                Console.Write(g + " ");
            }
        }
        public Solutiuon(int ilośćGenów) 
        {
            this.IlośćGenów = ilośćGenów;
            Geny = new int[IlośćGenów];
            Random();
        }

    }
}

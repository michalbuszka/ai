using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public class Solution
    {
        private int IlośćGenów;
        public int[] Geny { get; private set; }
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
        public Solution Crossover(Solution other)
        {
            Solution child = new Solution(Geny.Length);
            Random random = new Random();
            int length = random.Next(1, Geny.Length); 
            int start = random.Next(0, Geny.Length - length + 1); 
            for (int i = 0; i < Geny.Length; i++)
            {
                child.Geny[i] = (i >= start && i < start + length) ? other.Geny[i] : this.Geny[i];
            }
            return child;
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
        public Solution(int ilośćGenów) 
        {
            this.IlośćGenów = ilośćGenów;
            Geny = new int[IlośćGenów];
            Random();
        }

    }
}

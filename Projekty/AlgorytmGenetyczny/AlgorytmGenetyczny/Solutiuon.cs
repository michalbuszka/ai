using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public class Solutiuon
    {
        private int[] Geny;
        public int getFitness ()
        {
            int counter = 0;
            foreach (int gen in Geny)
            {
                counter += gen;
            }
            return counter;
        }
        public int Fitness { 
            get 
            {
                return getFitness(); 
            }
        }    
        public Solutiuon(int ilośćGenów) 
        {
            Geny = new int[ilośćGenów];
        }

    }
}

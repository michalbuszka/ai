using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Math;
using Microsoft.ML.Probabilistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuchyBrowna
{
    public class BrownMotion
    {
        public double[] data { get; set; } = new double[100];
        //double zmienna = 0;

        public BrownMotion ()
        {
            procesMarcova();
        }
        public void procesMarcova ()
        {
            for (int i = 1; i < data.Length; i++)
            {
                var variable = Gaussian.FromMeanAndVariance(0.5, 0.0001);
                data[i] = data[i - 1] + variable.Sample() * 2 - 1;
            }
        }
        public void procesBrowna ()
        {
            for (int i = 1; i < data.Length; i++)
            {
                data[i] = data[i - 1] + Rand.Normal(0, 0.01);
            }
        }

    }
}

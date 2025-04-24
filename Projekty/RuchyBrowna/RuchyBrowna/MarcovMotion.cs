using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Math;

namespace RuchyBrowna
{
    public class MarcovMotion
    {
        public double[] MarcovData { get; private set; }
        public double[] dwoDMarcovDataX { get; private set; }
        public double[] dwoDMarcovDataY { get; private set; }
        public double[] BrownData { get; private set; }

        private int length;
        public MarcovMotion(int dataLength = 100)
        {
            length = dataLength;
            MarcovData = new double[length];
            BrownData = new double[length];
            dwoDMarcovDataX = new double[length]; 
            dwoDMarcovDataY = new double[length]; 
        }

        public void GenerateMarcov()
        {
            MarcovData[0] = 0;
            for (int i = 1; i < length; i++)
            {
                double noise = Rand.Normal(0, 0.01);
                MarcovData[i] = 0.5 * MarcovData[i - 1] + noise;
            }
        }
        public void Generate2DMarcov()
        {
            MarcovData[0] = 0;
            for (int i = 1; i < length; i++)
            {
                double noiseX = Rand.Normal(0, 0.01);
                double noiseY = Rand.Normal(0, 0.01);
                dwoDMarcovDataX[i] = 0.5 * dwoDMarcovDataX[i - 1] + noiseX;
                dwoDMarcovDataY[i] = 0.5 * dwoDMarcovDataY[i - 1] + noiseY;
            }
        }

        public void GenerateBrown()
        {
            BrownData[0] = 0;
            for (int i = 1; i < length; i++)
            {
                double step = Rand.Normal(0, 0.1); 
                BrownData[i] = BrownData[i - 1] + step;
            }
        }
    }
}
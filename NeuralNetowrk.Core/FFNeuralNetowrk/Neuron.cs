using MultiClassNNClassifier.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetowrk.Core.FFNeuralNetowrk
{
    public class Neuron
    {
        public double Input { get; set; }
        public double Threshold { get; set; }
        public double DeltaThresold { get; set; }
        public double ThresholdSign { get; set; }
        public double YActual { get; set; }
        public double YDesired { get; set; }
        public double Error { get; set; }
        public double GradientDecent { get; set; }
        public List<Link> Links { get; set; }

        public Neuron()
        {
            var random = new Random();
            Threshold = random.NextDouble();
            ThresholdSign = -1;
            Links = new List<Link>();
        }

    }
}

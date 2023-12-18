using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NeuralNetowrk.Core.FFNeuralNetowrk
{
    public class Link
    {
        public Neuron Source { get; set; }
        public Neuron Output {  get; set; }
        public double Weight { get; set; }
        public double DeltaWeight { get; set; }

        public Link(Neuron source, Neuron output, double weight)
        {
            Source = source;
            Output = output;
            Weight = weight;
        }
    }
}

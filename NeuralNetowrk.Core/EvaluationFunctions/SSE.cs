using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetowrk.Core.EvaluationFunctions
{
    public static class SSE
    {
        public static double Calculate(List<double> values)
        {
            return values.Sum(error => Math.Pow(error, 2));
        }
    }
}

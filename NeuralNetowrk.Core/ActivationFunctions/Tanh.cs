using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClassNNClassifier.ActivationFunctions
{
    public class Tanh: IActivationFunction
    {

        #region Activation Function

        public double Activate(double bigX, List<double> bigXs = default(List<double>))
        {
            return 2 / (1 + Math.Pow(Math.E, -2 * bigX)) -1;
        }

        public double CalculateDerivative(double yActual)
        {
            return 1 - Math.Pow(yActual, 2);
        }
        #endregion
    }
}

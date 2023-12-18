using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClassNNClassifier.ActivationFunctions
{
    public class Sigmoid: IActivationFunction
    {

        #region Public Methods

        public double Activate(double bigX, List<double> bigXs = default(List<double>))
        {
            return 1 / (1 + Math.Pow(Math.E, -bigX));
        }

        public double CalculateDerivative(double yActual)
        {
            return yActual * (1 - yActual);
        }
        #endregion
    }
}

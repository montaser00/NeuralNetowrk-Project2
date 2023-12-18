using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClassNNClassifier.ActivationFunctions
{
    public interface IActivationFunction
    {

        #region Interface Members

        public double Activate(double bigX, List<double> bigXs = default(List<double>));

        double CalculateDerivative(double yActual);
        #endregion
    }
}

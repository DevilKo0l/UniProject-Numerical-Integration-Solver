using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Integration_Solver
{
    interface IIntegrationMethod
    {        
        double TrapezodalMethod(double[] boundaries,int numberOfInterval);
        double SimpsonMethod(double[] boundaries, int numberOfInterval);
    }
}

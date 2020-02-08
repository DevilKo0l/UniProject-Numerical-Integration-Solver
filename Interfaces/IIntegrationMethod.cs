using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Integration_Solver
{
    interface IIntegrationMethod
    {        
        double TrapezodalMethod(int numberOfInterval);
        double SimpsonMethod(int numberOfInterval);
    }
}

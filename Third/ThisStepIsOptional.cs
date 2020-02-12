using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class ThisStepIsOptional : IPipelineStep<double, double>
    {
        public double Process(double input)
        {
            return input * 10;
        }
    }
}

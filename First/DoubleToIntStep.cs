using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class DoubleToIntStep : IPipelineStep<double, int>
    {
        public int Process(double input)
        {
            return Convert.ToInt32(input);
        }
    }
}

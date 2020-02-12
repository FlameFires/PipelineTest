using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public static class PipelineStepExtensions
    {
        public static OUTPUT Step<INPUT,OUTPUT>(this INPUT input, IPipelineStep<INPUT,OUTPUT> step)
        {
            return step.Process(input);
        }
    }
}

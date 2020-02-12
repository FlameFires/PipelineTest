using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public abstract class Pipelines<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public Func<INPUT,OUTPUT> PipelineSteps { get; protected set; }
        public OUTPUT Process(INPUT input)
        {
            return PipelineSteps(input);
        }
    }
}

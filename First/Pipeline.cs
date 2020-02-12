using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public abstract class Pipeline<INPUT,OUTPUT>
    {
        public Func<INPUT,OUTPUT> PipelineSetps { get; protected set; }
        public OUTPUT Process(INPUT input)
        {
            return PipelineSetps.Invoke(input);
        }
    }
}

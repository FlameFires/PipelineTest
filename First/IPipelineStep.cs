using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public interface IPipelineStep<INPUT,OUTPUT>
    {
        OUTPUT Process(INPUT input);
    }
}

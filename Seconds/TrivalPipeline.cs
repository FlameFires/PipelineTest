using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class TrivalPipeline : Pipeline<double, string>
    {
        public TrivalPipeline()
        {
            PipelineSetps = input => input.Step(new DoubleToIntStep())
                                      .Step(new IntToStringStep());
        }
    }
}

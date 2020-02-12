using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class PipelineWithOptionalStep : Pipelines<double,double>
    {
        public PipelineWithOptionalStep()
        {
            // 当输入参数大于 1024，执行 ThisStepIsOptional() 功能
            PipelineSteps = input => input.Step(new OptionalStep<double, double>(i => i > 1024, new ThisStepIsOptional()));
        }
    }
}

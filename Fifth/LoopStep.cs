using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class LoopStep<INPUT, OUTPUT> : IPipelineStep<IEnumerable<INPUT>, IEnumerable<OUTPUT>>
    {
        private readonly IPipelineStep<INPUT, OUTPUT> _internalStep;
        public LoopStep(IPipelineStep<INPUT, OUTPUT> internalStep)
        {
            _internalStep = internalStep;
        }

        public IEnumerable<OUTPUT> Process(IEnumerable<INPUT> input)
        {
            foreach (INPUT item in input)
            {
                yield return _internalStep.Process(item);
            }

            //等价于下述代码段
            //return from INPUT item in input
            //       select _internalStep.Process(item);
        }
    }

    public static class PipelineStepLoopExtensions
    {
        public static IEnumerable<OUTPUT> Steps<INPUT, OUTPUT>(this IEnumerable<INPUT> input, IPipelineStep<INPUT, OUTPUT> step)
        {
            LoopStep<INPUT, OUTPUT> loopDecorator = new LoopStep<INPUT, OUTPUT>(step);
            return loopDecorator.Process(input);
        }
    }
}

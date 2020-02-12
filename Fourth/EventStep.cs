using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    //事件监听#
    public class EventStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public event Action<INPUT> OnInput;
        public event Action<OUTPUT> OnOutput;

        private readonly IPipelineStep<INPUT, OUTPUT> _innerStep;
        public EventStep(IPipelineStep<INPUT, OUTPUT> innerStep)
        {
            _innerStep = innerStep;
        }

        public OUTPUT Process(INPUT input)
        {
            OnInput?.Invoke(input);

            var output = _innerStep.Process(input);

            OnOutput?.Invoke(output);

            return output;
        }
    }

    public static class PipelineStepEventExtensions
    {
        public static OUTPUT Step<INPUT, OUTPUT>(this INPUT input, IPipelineStep<INPUT, OUTPUT> step, Action<INPUT> inputEvent = null, Action<OUTPUT> outputEvent = null)
        {
            if (inputEvent != null || outputEvent != null)
            {
                var eventDecorator = new EventStep<INPUT, OUTPUT>(step);
                eventDecorator.OnInput += inputEvent;
                eventDecorator.OnOutput += outputEvent;

                return eventDecorator.Process(input);
            }
            return step.Process(input);
        }
    }

    public class DoubleStep : IPipelineStep<int, int>
    {
        public int Process(int input)
        {
            return input * input;
        }
    }
}

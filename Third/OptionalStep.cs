using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineTest
{
    public class OptionalStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT> where INPUT : OUTPUT
    {
        private readonly IPipelineStep<INPUT, OUTPUT> _step;
        private readonly Func<INPUT, bool> _choice;

        public OptionalStep(Func<INPUT, bool> choice, IPipelineStep<INPUT, OUTPUT> step)
        {
            _choice = choice;
            _step = step;
        }
        public OUTPUT Process(INPUT input)
        {
            return _choice(input) ? _step.Process(input) : input;
        }
    }
}

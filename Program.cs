using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PipelineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://www.cnblogs.com/hippieZhou/archive/2019/07/17/11174644.html
            FirstTest.Run();
            Console.WriteLine();

            SecondsTest.Run();
            Console.WriteLine();

            ThirdTest.Run();
            Console.WriteLine();

            FourthTest.Run();
            Console.WriteLine();

            FifthTest.Run();
            Console.WriteLine();


            Console.ReadLine();
        }
    }
    
    static class FirstTest
    {
        public static void Run()
        {
            typeof(FirstTest).Top();
            double input = 1024.1024;

            // 构建并使用管道
            string result = input.Step(new DoubleToIntStep())
                                 .Step(new IntToStringStep());
            Console.WriteLine(result);
        }
    }

    static class SecondsTest 
    {
        public static void Run()
        {
            typeof(SecondsTest).Top();
            double input = 1024.1024;

            // 需要安装 Microsoft.Extensions.DependencyInjection
            var services = new ServiceCollection();
            services.AddTransient<TrivalPipeline>();
            var provider = services.BuildServiceProvider();

            var trival = provider.GetService<TrivalPipeline>();
            string result = trival.Process(input);
            Console.WriteLine(result);
        }
    }

    static class ThirdTest
    {
        public static void Run()
        {
            typeof(ThirdTest).Top();

            PipelineWithOptionalStep step = new PipelineWithOptionalStep();
            Console.WriteLine(step.Process(1024.1024));  // 输出 10241.024
            Console.WriteLine(step.Process(520.520));    // 输出 520.520
        }
    }

    static class FourthTest
    {
        public static void Run()
        {
            typeof(FourthTest).Top();
            var input = 10;
            Console.WriteLine($"Input Value:{input}[{input.GetType()}]");
            var pipeline = new EventStep<int, int>(new DoubleStep());
            pipeline.OnInput += i => Console.WriteLine($"Input Value:{i}");
            pipeline.OnOutput += o => Console.WriteLine($"Output Value:{o}");
            var output = pipeline.Process(input);
            Console.WriteLine($"Output Value: {output} [{output.GetType()}]");
            Console.WriteLine("\r\n");

            //补充：使用扩展方法进行调用
            Console.WriteLine(10.Step(new DoubleStep(), i =>
            {
                Console.WriteLine($"Input Value:{i}");
            },
            o =>
            {
                Console.WriteLine($"Output Value:{o}");
            }));
        }
    }

    class FifthTest
    {
        public static void Run()
        {
            typeof(FourthTest).Top();
            var list = Enumerable.Range(0, 10);
            foreach (var item in list.Steps(new DoubleStep()))
            {
                Console.WriteLine(item);
            }
        }
    }

    static class BaseTest
    {
        public static void Top(this Type type)
        {
            string name = type.FullName;
            Console.WriteLine(string.Format("正在运行 {0}", name));
        }
    }
}

using System;

namespace Dotnet50Samples.SourceGeneratorSample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello world!");

            HelloWorldGenerated.HelloWorld.SayHello();
        }
    }
}

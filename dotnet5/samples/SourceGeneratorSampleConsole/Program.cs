using System;

namespace SourceGeneratorSampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HelloWorldGenerated.HelloWorld.SayHello();
        }
    }
}

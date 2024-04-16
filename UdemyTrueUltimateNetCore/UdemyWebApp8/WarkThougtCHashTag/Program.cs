using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WarkThougtCHashTag.Controller;
using WarkThougtCHashTag.Entity;
using entity = WarkThougtCHashTag.Entity;
using controller = WarkThougtCHashTag.Controller;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Validators;

namespace WarkThoughtCHashTag
{
    public class Program
    {

        public delegate int StrToInt(string s);
        public static int ConvertToNumber(string s)
        {
            if (int.TryParse(s, out int result))
                return result;
            return 0;
        }

        public static int GetLength(string text)
        {
            return text.Length + 10;
        }



        
            
        public static void CallBackTestFunction(Delegate callback)
        {
            Console.WriteLine("Go here first");
            var rdresult = callback.DynamicInvoke(12);
            Console.WriteLine(rdresult);
        }


        public static int FunctionReturn(int firstValue, int secondValue, double dummyValue)
        {
            return (int)((double)firstValue + (double)secondValue + dummyValue);
        }
        public static bool returnTrueValue()
        {
            Console.WriteLine("Go to True");
            return true;
        }

        public static bool returnFalseValue()
        {
            Console.WriteLine("Go to False");
            return false;
        }

        public void testFirst(StrToInt value)
        {
            value.Invoke("hello world");
        }

        public record class Bird
        {
            public string Type { get; init; }

            public string Name { get; set; }

            public string Age { get; set; }

            public Bird(string type,string name)
            {
                Type = type;
                Name = name;
            }
            public Bird() { }

            public void ChangeValue(ref int helloWorld)
            {
                helloWorld = 12;
            }

            public void ChangeThisShit(out int fullName)
            {
                //Console.WriteLine(fullName);
                fullName = 123;
            }
        }

        public struct Person
        {
            public string Name { get; }
            public int Age { get; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            (double, int) test = (1.2d,12);
        }

        public delegate void Notify();

        public class ProcessBussinessLogic
        {
            public string test { get; set; }
        }

        public static void Main(string[] args)
        {
                var config = new ManualConfig()
                            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                            .AddValidator(JitOptimizationsValidator.DontFailOnError)
                            .AddLogger(ConsoleLogger.Default)
                            .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run<MyBenchMark>(config);
        }
    }

    public class MyBenchMark
    {
        [Benchmark]
        public List<string> ReadFileNatureWay()
        {
            var returnList = new List<string>();

            for(var i = 0; i < 100; i++)
            {
                returnList.Add(i + "");
            }
            return returnList;
        }

        [Benchmark]
        public IEnumerable<string> ReadFileUsingYield()
        {
            for(var i = 0; i < 100; i++)
            {
                yield return i + "";
            }
        }
    }
}

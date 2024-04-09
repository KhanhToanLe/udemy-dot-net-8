using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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



        static void Main(string[] args)
        {
            //StrToInt myAction = ConvertToNumber;
            //StrToInt otherAction = GetLength;
            //myAction.Invoke("some text here");
            ////Person a = new Person("Hello World", 12, new Bird() { Type = "White Bird", Name = "Black" });
            ////Bird newBird = a.Pet;
            ////newBird.Name = "name changed";
            ////Console.WriteLine(a.Pet.Name);

            //Bird test = new Bird()
            //{
            //    Type = "Hello World",
            //    Name = "123"
            //};
            //int testValue = 1;
            ////Console.WriteLine(testValue);
            //test.ChangeValue(ref testValue);
            ////Console.WriteLine(testValue);

            //string a = "hello world";
            //if(a is Bird)
            //{
            //    Console.WriteLine("hello World");
            //}

            //var firstTestBird = new Bird()
            //{
            //    Name = "Hello World",
            //    Type = "Bird Song"
            //};
            //var newFirstTestBird = firstTestBird with { Age = "12" };

            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            System.Console.WriteLine(dyn.GetType());
            System.Console.WriteLine(obj.GetType());
            var test123 = 2;
            switch (test123)
            {
                case 1:
                    {
                        Console.WriteLine("1");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("2");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("3");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("4");
                        break;
                    }
            }
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
    }
}

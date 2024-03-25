namespace MvcWebApp.Models
{
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public override string ToString()
        {
            string returnValue = $"{Name} {Age} {DateOfBirth.Day}/{DateOfBirth.Month}/{DateOfBirth.Year}";
            Console.WriteLine(returnValue);
            return returnValue;
        }

    }
}

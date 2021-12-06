using System;

namespace DateTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime testDateTime = DateTime.Now;

            Console.WriteLine($"Today's date/time is: {testDateTime}");

            DateTime dueDateTime = testDateTime.AddDays(14);

            Console.WriteLine($"Your book is due at the following date/time: {dueDateTime}");
        }
    }
}

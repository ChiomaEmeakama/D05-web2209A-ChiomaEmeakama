namespace Chapter1
{
    internal class Program
    {
        static void Main(string[] args)
        ///// READING TEXTS /////

        // -------First Example---
        //      {
        //          //Console.WriteLine("Hello, World!");
        //          Console.Write("Please enter your First Name: ");
        //          string firstName = Console.ReadLine();
        //          Console.Write("Please enter your Last Name: ");
        //          string lastName = Console.ReadLine();
        //          Console.WriteLine("Hello, {0} {1}!", firstName, lastName);
        //      }
        //   }


        //----------Second Example--------

        // {
        //     Console.WriteLine("Course: ");
        //     string course = Console.ReadLine();
        //     if (course != "")
        //     {
        //         Console.WriteLine("Your Course: {0", course);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Nothing entered");
        //     }
        // }


        ///// READING NUMBERS /////

        //  {
        //      Console.Write("a = ");
        //      int a = int.Parse(Console.ReadLine());
        //      Console.Write("b = ");
        //      int b = int.Parse(Console.ReadLine());
        //      Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        //      Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
        //      Console.Write("f = ");
        //      double f = double.Parse(Console.ReadLine());
        //      Console.WriteLine("{0} * {1} / {2} = {3}", a, b, f, a * b / f);
        //          
        //  }

        {
            //Exercise 1:
            //Write a program that reads from the console the radius
            //"r" of a circle and prints its perimeter and area.

            {
                Console.WriteLine("Input the radius (r) of the circle: ");
                    int a = int.Parse(Console.ReadLine());
                Console.WriteLine("The Perimeter of the circle with radius r = {0} is: ", 2 * Math.PI * a );
            }
           
        }
    }
}
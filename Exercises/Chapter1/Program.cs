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
            //Exercise 1.1:-------------------------------------------------------
            //Write a program that reads from the console the radius
            //"r" of a circle and prints its perimeter and area.

            {
                Console.WriteLine("Input the radius (r) of the circle: ");
                    int a = int.Parse(Console.ReadLine());
                Console.WriteLine("The Perimeter of the circle with radius r = {0} is: ", 2 * Math.PI * a );
            }

            //Exercise 1.2:-------------------------------------------------------
            //  A given company has name, address, phone number, fax
            //  number, web site and manager. The manager has name,
            //  surname and phone number. Write a program that reads
            //  information about the company and its manager and then
            //  prints it on the console.

            {
                Console.WriteLine("Input Name of Company: ");
                string companyName = Console.ReadLine();
                Console.WriteLine("Input Company's Address: ");
                string companyAddress = Console.ReadLine();
                Console.WriteLine("Input Company's Phone Number: ");
                string companyPhoneNumber = Console.ReadLine();
                Console.WriteLine("Input Manager's First Name: ");
                string managerFirstName = Console.ReadLine();
                Console.WriteLine("Input Namager's Last Name: ");
                string managerLastName = Console.ReadLine();
                Console.WriteLine("Input Manager's Phone number: ");
                string managerPhoneNumber = Console.ReadLine();
                Console.WriteLine("Details of Your COmpany and it's Manager: ");
                Console.WriteLine("Company Name: {0}", companyName);
                Console.WriteLine("  Company Address: {1}", companyAddress);
                Console.WriteLine("Company Phone Number: {2}", companyPhoneNumber);
                Console.WriteLine("Manager's First Name: {3}", managerFirstName);
                Console.WriteLine("Manager's Last Name: {4}", managerLastName);
                Console.WriteLine("Manager's Phone Number: {5}", managerPhoneNumber) ;
            }
        }
    }
}
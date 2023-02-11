
//foreach (char c in "Jordan")
//{
//    Console.WriteLine(c);
//}

using System;
public class CSharpApp
{
    static void Main()
    {
        string[] planets = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Uranus", "Neptune" };
        foreach (string planet in planets)
        {
            Console.WriteLine(planet);
        }

        Console.WriteLine("Hello WOrld!");
    }
}
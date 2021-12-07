using CaseStudy.Model.Models;
using System;

namespace CaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Plateau plateau = new Plateau();

                Rover roverAlpha = new Rover("1 2 N");
                string result1 = roverAlpha.Explore("LMLMLMLMM", plateau);
                
                Rover roverBeta = new Rover("3 3 E");
                string result2 = roverBeta.Explore("MMRMMRMRRM", plateau);

                Console.WriteLine(result1);
                Console.WriteLine(result2);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

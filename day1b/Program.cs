using System;
using System.IO;

namespace day1b
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int sum = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    int fuel = CalculateFuel(int.Parse(line));
                    //Console.WriteLine(fuel);
                    sum += fuel;
                }

                Console.WriteLine(sum);
            }
        }

        static int CalculateFuel(int mass)
        {
            int fuel = (int) Math.Floor((decimal) mass / 3) - 2;
            if (fuel > 0)
            {
                fuel += CalculateFuel(fuel);
            }

            if (fuel < 0)
                fuel = 0;
            //Console.Write(fuel);
            //Console.ReadKey();
            return fuel;
        }
    }
}

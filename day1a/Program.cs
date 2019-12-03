using System;
using System.IO;

namespace day1a
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
                    sum += CalculateFuel(int.Parse(line));
                }

                Console.WriteLine(sum);
            }
        }

        static int CalculateFuel(int mass)
        {
            int fuel = (int) Math.Floor((decimal) mass / 3) - 2;
            //Console.Write(fuel);
            //Console.ReadKey();
            return fuel;
        }
    }
}

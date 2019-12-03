using System;
using System.Collections.Generic;
using System.IO;

namespace day2a
{
    class Program
    {
        private static int[] Intcode;

        static void Main(string[] args)
        {
            string input = "";

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    input = sr.ReadToEnd();
                }
            }

            var split = input.Split(',');
            Intcode = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                Intcode[i] = int.Parse(split[i]);
            }

            PrepInput();
            ProcessInput();
            DisplayIntcode();
        }

        private static void PrepInput()
        {
            Intcode[1] = 12;
            Intcode[2] = 2;
        }

        private static void ProcessInput()
        {
            int opcode, op1, op2;

            for(int i = 0 ; i < Intcode.Length; i=i+4)
            {
                opcode = Intcode[i];
                
                switch(opcode)
                {
                    case 1:
                        op1 = Intcode[Intcode[i+1]];
                        op2 = Intcode[Intcode[i+2]];
                        Intcode[Intcode[i+3]] = op1 + op2;
                        break;
                    case 2:
                        op1 = Intcode[Intcode[i+1]];
                        op2 = Intcode[Intcode[i+2]];
                        Intcode[Intcode[i+3]] = op1 * op2;
                        break;
                    case 99:
                        return;
                    default:
                        Console.Write("Unexpected opcode!");
                        break;
                }
            }
        }

        private static void DisplayIntcode()
        {
            foreach(var v in Intcode)
            {
                Console.Write($"{v},");
            }

            Console.WriteLine("");
            Console.WriteLine(Intcode[0]);
        }
    }
}

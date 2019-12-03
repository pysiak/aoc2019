using System;
using System.Collections.Generic;
using System.IO;

namespace day2b
{
    class Program
    {
        private static int[] Intcode;
        private static int[] OrigIntcode;

        static void Main(string[] args)
        {
            ReadInput();

            for (int i = 0; i<=99;i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    Intcode = (int []) OrigIntcode.Clone();
                    Intcode[1] = i;
                    Intcode[2] = j;
                    ProcessInput();
                    int result = ReturnResult();
                    if (result == 19690720)
                    {
                        Console.WriteLine($"Win: {100 * i + j}");
                    }
                }
            }
            
        }

        private static void ReadInput()
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
            OrigIntcode = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                OrigIntcode[i] = int.Parse(split[i]);
            }
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

        private static int ReturnResult()
        {
            //Console.WriteLine(Intcode[0]);
            return Intcode[0];
        }
    }
}

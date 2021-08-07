using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Enter input file path:");
            string inputPath = Console.ReadLine();
            Console.WriteLine("Enter output file path:");
            string outputPath = Console.ReadLine();
            DeutschDictionary dictionary = new DeutschDictionary();
            Decomposer decomposer = new Decomposer(inputPath, outputPath);

            decomposer.ListDecompose(dictionary.Dictionary);
        }
    }
}

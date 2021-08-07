using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Enter input file path (Dictioinary):");
            string dictionaryPath = Console.ReadLine();
            Console.WriteLine("Enter input file path (Words for decomposing):");
            string inputPath = Console.ReadLine();
            Console.WriteLine("Enter output file path:");
            string outputPath = Console.ReadLine();

            DeutschDictionary dictionary = new DeutschDictionary(dictionaryPath);
            Decomposer decomposer = new Decomposer(inputPath, outputPath);

            decomposer.ListDecompose(dictionary.Dictionary);
        }
    }
}

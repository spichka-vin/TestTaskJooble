using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            DeutschDictionary dictionary = new DeutschDictionary();
        }
    }
}

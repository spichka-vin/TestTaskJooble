using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestTask
{
    public class DeutschDictionary
    {
        public Dictionary<char, List<string>> Dictionary { get; set; }
        private readonly string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\");
        private const string path = @"Data\de-dictionary.tsv";
        public DeutschDictionary()
        {
            string fullPath = Path.Combine(baseDirectory, path);
            if (File.Exists(fullPath))
            {
                Dictionary = new Dictionary<char, List<string>>();
                foreach (string line in File.ReadAllLines(fullPath))
                {
                    AddWord(line);                
                }
            }
            else
            {
                Console.WriteLine("File doesn`t exist!");
            }
        }
        private void AddWord(string word)
        {
            string lowercaseWord = word.ToLower();
            char key = lowercaseWord[0];
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key].Add(lowercaseWord);
            }
            else
            {
                Dictionary.Add(key, new List<string>());
                Dictionary[key].Add(lowercaseWord);
            }
        }



    }
}

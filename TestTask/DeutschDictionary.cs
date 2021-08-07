using System;
using System.Collections.Generic;
using System.IO;

namespace TestTask
{
    public class DeutschDictionary
    {
        public Dictionary<char, List<string>> Dictionary { get; set; }
        public DeutschDictionary(string inputFullPath)
        {
            if (File.Exists(inputFullPath))
            {
                Dictionary = new Dictionary<char, List<string>>();
                foreach (string line in File.ReadAllLines(inputFullPath))
                {
                    AddWord(line);                
                }
            }
            else
            {
                Console.WriteLine("File doesn`t exist!");
                throw new FileLoadException();
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

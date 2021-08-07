using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 
using System.IO;

namespace TestTask
{
    public class Decomposer
    {
        public List<string> WordsList { get; set; }
        private readonly string OutputFullPath;

        public Decomposer(string inputFullPath, string outputFullPath)
        {
            if (File.Exists(inputFullPath))
            {
                WordsList = new List<string>();
                foreach (string line in File.ReadAllLines(inputFullPath))
                {
                    WordsList.Add(line.ToLower());
                }
                OutputFullPath = outputFullPath;
            }
            else
            {
                Console.WriteLine("File doesn`t exist!");
                throw new FileLoadException();
            }
        }

        public void ListDecompose(Dictionary<char, List<string>> dictionary)
        {
            List<string> answer = new List<string>();
            foreach(string word in WordsList)
            {
                answer.Add(WordDecompose(word, dictionary));
            }
            File.WriteAllLines(OutputFullPath, answer);
        }

        private string WordDecompose(string word, Dictionary<char, List<string>> dictionary)
        {
            DecompositionItem currentItem = new DecompositionItem("", word, null);
            currentItem.Decompose(dictionary);
            currentItem.RemoveWordFromNextWords(word);

            while (true)
            {
                if (currentItem.IsNull())
                {
                    return ComposeAnswer(word, null);
                }
                currentItem = currentItem.NextWords.First();
                if(currentItem.RemainingPart.Length == 0)
                {
                    return ComposeAnswer(word, currentItem);
                }
                currentItem.Decompose(dictionary);
                currentItem = DeleteDecompositionItem(currentItem);
            }
        }

        private DecompositionItem DeleteDecompositionItem(DecompositionItem item)
        {
            while (true)
            {
                if(item.NextWords.Count == 0)
                {
                    if (item.IsNull())
                        return item;
                    item = item.DeleteItem();
                }
                else
                {
                    return item;
                }
            }
        }
        private string ComposeAnswer(string word, DecompositionItem item)
        {
            StringBuilder answer = new StringBuilder();
            string arrow = " -> ";

            if (item is null)
            {
                answer.Insert(0, word);
            }
            else
            {
                while(item.CurrentWord.Length != 0)
                {
                    answer.Insert(0, item.CurrentWord);
                    item = item.ParrentItem;    
                    if(item.CurrentWord.Length != 0)
                    {
                        answer.Insert(0, ", ");
                    }
                }
            }
            answer.Insert(0, arrow);
            answer.Insert(0, word);
            return answer.ToString();
        }

    }
}

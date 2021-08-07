using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public class DecompositionItem
    {
        public string CurrentWord { get; set; }
        public List<DecompositionItem> NextWords { get; set; }
        public string RemainingPart { get; set; }
        public DecompositionItem ParrentItem { get; set; }
        public DecompositionItem(string currentWord, string fullWord, DecompositionItem parrentItem)
        {
            CurrentWord = currentWord;
            RemainingPart = fullWord.Remove(0, currentWord.Length);
            ParrentItem = parrentItem;
        }
        public void Decompose(Dictionary<char, List<string>> dictionary)
        {
            NextWords = new List<DecompositionItem>();
            char key = RemainingPart[0];
            foreach(string item in dictionary[key])
            {
                if (RemainingPart.StartsWith(item))
                {
                    NextWords.Add(new DecompositionItem(item, RemainingPart, this));
                }
            }
            NextWords = NextWords.OrderByDescending(x => x.CurrentWord.Length).ToList();
        }
        public bool IsNull()
        {
            if (NextWords.Count == 0)
                return true;
            return false;
        }
    }
}

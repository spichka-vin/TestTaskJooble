using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace TestTask.Tests
{
    public class DecompositionItemTests
    {
        Dictionary<char, List<string>> dictionary;
        [SetUp]
        public void Setup()
        {
            dictionary = new Dictionary<char, List<string>>();
            List<string> aList = new List<string>();
            aList.Add("arbeit");
            dictionary.Add('a', aList);
        }

        [Test]
        public void IsNullReturnTrue()
        {
            DecompositionItem item = new DecompositionItem("fern", "fernsehen", null);
            item.NextWords = new List<DecompositionItem>();

            bool isNull = item.IsNull();

            Assert.IsTrue(isNull);
        }
        [Test]
        public void IsNullReturnFalse()
        {
            DecompositionItem item = new DecompositionItem("fern", "fernsehen", null);
            item.NextWords = new List<DecompositionItem>();
            item.NextWords.Add(new DecompositionItem("sehen", "sehen", item));

            bool isNull = item.IsNull();

            Assert.IsTrue(!isNull);
        }
        [Test]
        public void DecomposeResultIsEmpty()
        {
            DecompositionItem item = new DecompositionItem("", "srb", null);
            item.Decompose(dictionary);

            Assert.AreEqual(0, item.NextWords.Count);
        }
        [Test]
        public void DecomposeResultIsNotEmpty()
        {
            DecompositionItem item = new DecompositionItem("", "arbeiten", null);
            item.Decompose(dictionary);

            Assert.IsTrue(0 != item.NextWords.Count);
        }
        [Test]
        public void DeleteItemWithNullParrentItem()
        {
            DecompositionItem item = new DecompositionItem("", "arbeiten", null);
            DecompositionItem parrentItem = item.DeleteItem();

            Assert.IsNull(parrentItem);
        }
        [Test]
        public void DeleteItemWithNotNullParrentItem()
        {
            DecompositionItem parrentItem = new DecompositionItem("", "arbeiten", null);
            parrentItem.NextWords = new List<DecompositionItem>();
            DecompositionItem childItem1 = new DecompositionItem("arbeit", "arbeiten", parrentItem);
            parrentItem.NextWords.Add(childItem1);
            DecompositionItem childItem2 = new DecompositionItem("arbeiten", "arbeiten", parrentItem);
            parrentItem.NextWords.Add(childItem2);

            DecompositionItem deleteResult = childItem1.DeleteItem();

            Assert.IsNotNull(deleteResult);
            Assert.IsFalse(deleteResult.NextWords.Count == 0);
            Assert.IsEmpty(deleteResult.NextWords.Where(x => x.CurrentWord == childItem1.CurrentWord));
        }

        [TestCase ("arbeit", 1)]
        [TestCase("arbeitet", 2)]
        public void RemoveWordFromNextWordsTests(string word, int nextWordsCount)
        {
            DecompositionItem parrentItem = new DecompositionItem("", "arbeiten", null);
            parrentItem.NextWords = new List<DecompositionItem>();
            DecompositionItem childItem1 = new DecompositionItem("arbeit", "arbeiten", parrentItem);
            parrentItem.NextWords.Add(childItem1);
            DecompositionItem childItem2 = new DecompositionItem("arbeiten", "arbeiten", parrentItem);
            parrentItem.NextWords.Add(childItem2);

            parrentItem.RemoveWordFromNextWords(word);

            Assert.AreEqual(parrentItem.NextWords.Count, nextWordsCount);
        }
    }
}

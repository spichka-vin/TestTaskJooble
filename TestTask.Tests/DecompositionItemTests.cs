using System.Collections.Generic;
using NUnit.Framework;

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
    }
}

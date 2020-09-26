using Dictionary.Dictionary;
using NUnit.Framework;

namespace Test.Dictionary
{
    public class DictionaryTest
    {
        TxtDictionary dictionary;
        TxtDictionary lowerCaseDictionary, mixedCaseDictionary;

        [SetUp]
        public void SetUp()
        {
            dictionary = new TxtDictionary();
            lowerCaseDictionary = new TxtDictionary("../../../lowercase.txt", new TurkishWordComparator());
            mixedCaseDictionary = new TxtDictionary("../../../mixedcase.txt", new TurkishIgnoreCaseWordComparator());
        }

        [Test]
        public void TestGetWordIndex()
        {
            Assert.AreEqual(0, lowerCaseDictionary.GetWordIndex("a"));
            Assert.AreEqual(3, lowerCaseDictionary.GetWordIndex("ç"));
            Assert.AreEqual(8, lowerCaseDictionary.GetWordIndex("ğ"));
            Assert.AreEqual(10, lowerCaseDictionary.GetWordIndex("ı"));
            Assert.AreEqual(18, lowerCaseDictionary.GetWordIndex("ö"));
            Assert.AreEqual(22, lowerCaseDictionary.GetWordIndex("ş"));
            Assert.AreEqual(25, lowerCaseDictionary.GetWordIndex("ü"));
            Assert.AreEqual(28, lowerCaseDictionary.GetWordIndex("z"));
            Assert.True(mixedCaseDictionary.GetWordIndex("A") == 0 || mixedCaseDictionary.GetWordIndex("A") == 1);
            Assert.True(mixedCaseDictionary.GetWordIndex("Ç") == 6 || mixedCaseDictionary.GetWordIndex("Ç") == 7);
            Assert.True(mixedCaseDictionary.GetWordIndex("Ğ") == 16 || mixedCaseDictionary.GetWordIndex("Ğ") == 17);
            Assert.True(mixedCaseDictionary.GetWordIndex("I") == 20 || mixedCaseDictionary.GetWordIndex("I") == 21);
            Assert.True(mixedCaseDictionary.GetWordIndex("İ") == 22 || mixedCaseDictionary.GetWordIndex("İ") == 23);
            Assert.True(mixedCaseDictionary.GetWordIndex("Ş") == 44 || mixedCaseDictionary.GetWordIndex("Ş") == 45);
            Assert.True(mixedCaseDictionary.GetWordIndex("Ü") == 50 || mixedCaseDictionary.GetWordIndex("Ü") == 51);
            Assert.True(mixedCaseDictionary.GetWordIndex("Z") == 56 || mixedCaseDictionary.GetWordIndex("Z") == 57);
        }

        [Test]
        public void TestSize()
        {
            Assert.AreEqual(29, lowerCaseDictionary.Size());
            Assert.AreEqual(58, mixedCaseDictionary.Size());
            Assert.AreEqual(62112, dictionary.Size());
        }

        [Test]
        public void TestGetWord()
        {
            Assert.AreEqual("a", lowerCaseDictionary.GetWord(0).GetName());
            Assert.AreEqual("ç", lowerCaseDictionary.GetWord(3).GetName());
            Assert.AreEqual("ğ", lowerCaseDictionary.GetWord(8).GetName());
            Assert.AreEqual("ı", lowerCaseDictionary.GetWord(10).GetName());
            Assert.AreEqual("ö", lowerCaseDictionary.GetWord(18).GetName());
            Assert.AreEqual("ş", lowerCaseDictionary.GetWord(22).GetName());
            Assert.AreEqual("ü", lowerCaseDictionary.GetWord(25).GetName());
            Assert.AreEqual("z", lowerCaseDictionary.GetWord(28).GetName());
            for (int i = 0; i < dictionary.Size(); i++)
            {
                Assert.NotNull(dictionary.GetWord(i));
            }
        }

        [Test]
        public void TestLongestWordSize()
        {
            Assert.AreEqual(1, lowerCaseDictionary.LongestWordSize());
            Assert.AreEqual(1, mixedCaseDictionary.LongestWordSize());
            Assert.AreEqual(21, dictionary.LongestWordSize());
        }

        [Test]
        public void TestGetWordStartingWith()
        {
            Assert.AreEqual(20, lowerCaseDictionary.GetWordStartingWith("q"));
            Assert.AreEqual(27, lowerCaseDictionary.GetWordStartingWith("w"));
            Assert.AreEqual(27, lowerCaseDictionary.GetWordStartingWith("x"));
            Assert.AreEqual(40, mixedCaseDictionary.GetWordStartingWith("Q"));
            Assert.AreEqual(54, mixedCaseDictionary.GetWordStartingWith("W"));
            Assert.AreEqual(54, mixedCaseDictionary.GetWordStartingWith("X"));
        }
    }
}
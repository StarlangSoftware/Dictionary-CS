using System.Collections.Generic;
using Dictionary.Syllibification;
using NUnit.Framework;

namespace Test.Syllibification
{
    public class SyllableListTest
    {
        [Test]
        public void TestSyllableList()
        {
            SyllableList syllableList;
            syllableList = new SyllableList("başöğretmen");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"ba", "şöğ", "ret", "men"});
            syllableList = new SyllableList("fransa");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"fran", "sa"});
            syllableList = new SyllableList("traktör");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"trak", "tör"});
            syllableList = new SyllableList("kraker");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"kra", "ker"});
            syllableList = new SyllableList("trake");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"tra", "ke"});
            syllableList = new SyllableList("ilköğretim");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"il", "köğ", "re", "tim"});
            syllableList = new SyllableList("semizotu");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"se", "mi", "zo", "tu"});
            syllableList = new SyllableList("ali");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"a", "li"});
            syllableList = new SyllableList("türk");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"türk"});
            syllableList = new SyllableList("kırktürk");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"kırk", "türk"});
            syllableList = new SyllableList("kardanadam");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"kar", "da", "na", "dam"});
            syllableList = new SyllableList("çöpadam");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"çö", "pa", "dam"});
            syllableList = new SyllableList("faal");
            Assert.AreEqual(syllableList.GetSyllables(), new List<string> {"fa", "al"});
        }
    }
}
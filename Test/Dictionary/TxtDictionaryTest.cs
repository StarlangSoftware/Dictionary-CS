using Dictionary.Dictionary;
using NUnit.Framework;

namespace Test.Dictionary
{
    public class TxtDictionaryTest
    {
        TxtDictionary dictionary;

        [SetUp]
        public void SetUp()
        {
            dictionary = new TxtDictionary();
        }

        [Test]
        public void TestGetCorrectForm()
        {
            for (var i = 0; i < dictionary.Size(); i++)
            {
                Assert.IsNull(dictionary.GetCorrectForm(dictionary.GetWord(i).GetName()));
            }
        }

        [Test]
        public void TestPrepareTrie()
        {
            var trie = dictionary.PrepareTrie();
            Assert.True(trie.GetWordsWithPrefix("bana").Contains(new Word("ben")));
            Assert.True(trie.GetWordsWithPrefix("metni").Contains(new Word("metin")));
            Assert.True(trie.GetWordsWithPrefix("ağzı").Contains(new Word("ağız")));
            Assert.True(trie.GetWordsWithPrefix("ayrıldı").Contains(new Word("ayır")));
            Assert.True(trie.GetWordsWithPrefix("buyruldu").Contains(new Word("buyur")));
            Assert.True(trie.GetWordsWithPrefix("ahdi").Contains(new Word("ahit")));
            Assert.True(trie.GetWordsWithPrefix("kaybı").Contains(new Word("kayıp")));
            Assert.True(trie.GetWordsWithPrefix("kutbu").Contains(new Word("kutup")));
            Assert.True(trie.GetWordsWithPrefix("ademelmaları").Contains(new Word("ademelması")));
            Assert.True(trie.GetWordsWithPrefix("ağaçküpeleri").Contains(new Word("ağaçküpesi")));
            Assert.True(trie.GetWordsWithPrefix("ağaçlığı").Contains(new Word("ağaçlık")));
            Assert.True(trie.GetWordsWithPrefix("sumağı").Contains(new Word("sumak")));
            Assert.True(trie.GetWordsWithPrefix("deveboyunları").Contains(new Word("deveboynu")));
            Assert.True(trie.GetWordsWithPrefix("gökcisimleri").Contains(new Word("gökcismi")));
            Assert.True(trie.GetWordsWithPrefix("gökkuşakları").Contains(new Word("gökkuşağı")));
            Assert.True(trie.GetWordsWithPrefix("hintarmutları").Contains(new Word("hintarmudu")));
            Assert.True(trie.GetWordsWithPrefix("hintpirinçleri").Contains(new Word("hintpirinci")));
            Assert.True(trie.GetWordsWithPrefix("sudolapları").Contains(new Word("sudolabı")));
            Assert.True(trie.GetWordsWithPrefix("yiyor").Contains(new Word("ye")));
            Assert.True(trie.GetWordsWithPrefix("diyor").Contains(new Word("de")));
            Assert.True(trie.GetWordsWithPrefix("depoluyor").Contains(new Word("depola")));
            Assert.True(trie.GetWordsWithPrefix("dışlıyor").Contains(new Word("dışla")));
            Assert.True(trie.GetWordsWithPrefix("fiyongu").Contains(new Word("fiyonk")));
            Assert.True(trie.GetWordsWithPrefix("gongu").Contains(new Word("gonk")));
        }
    }
}
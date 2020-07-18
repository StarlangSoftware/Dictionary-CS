using System.Linq;
using Dictionary.Dictionary;
using Dictionary.Dictionary.Trie;
using NUnit.Framework;

namespace Test
{
    public class TrieTest
    {
        Trie simpleTrie, complexTrie;

        [SetUp]
        public void Setup()
        {
            simpleTrie = new Trie();
            simpleTrie.AddWord("azı", new Word("azı"));
            simpleTrie.AddWord("az", new Word("az"));
            simpleTrie.AddWord("ad", new Word("ad"));
            simpleTrie.AddWord("adi", new Word("adi"));
            simpleTrie.AddWord("adil", new Word("adil"));
            simpleTrie.AddWord("a", new Word("a"));
            simpleTrie.AddWord("adilane", new Word("adilane"));
            simpleTrie.AddWord("ısı", new Word("ısı"));
            simpleTrie.AddWord("ısıtıcı", new Word("ısıtıcı"));
            simpleTrie.AddWord("ölü", new Word("ölü"));
            simpleTrie.AddWord("ölüm", new Word("ölüm"));
            simpleTrie.AddWord("ören", new Word("ören"));
            simpleTrie.AddWord("örgü", new Word("örgü"));
            complexTrie = new Trie();
            var dictionary = new TxtDictionary();
            for (var i = 0; i < dictionary.Size(); i++)
            {
                complexTrie.AddWord(dictionary.GetWord(i).GetName(), dictionary.GetWord(i));
            }
        }

        [Test]
        public void TestGetWordsWithPrefixSimple()
        {
            Assert.AreEqual(new Word[]{new Word("a")}, simpleTrie.GetWordsWithPrefix("a").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad")}, simpleTrie.GetWordsWithPrefix("ad").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi")}, simpleTrie.GetWordsWithPrefix("adi").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi"), new Word("adil")}, simpleTrie.GetWordsWithPrefix("adil").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi"), new Word("adil"), new Word("adilane")}, simpleTrie.GetWordsWithPrefix("adilane").ToArray());
            Assert.AreEqual(new Word[]{new Word("ölü")}, simpleTrie.GetWordsWithPrefix("ölü").ToArray());
            Assert.AreEqual(new Word[]{new Word("ölü"), new Word("ölüm")}, simpleTrie.GetWordsWithPrefix("ölüm").ToArray());
            Assert.AreEqual(new Word[]{new Word("ısı")}, simpleTrie.GetWordsWithPrefix("ısı").ToArray());
            Assert.AreEqual(new Word[]{new Word("ısı"), new Word("ısıtıcı")}, simpleTrie.GetWordsWithPrefix("ısıtıcı").ToArray());
        }

        [Test]
        public void TestGetWordsWithPrefixComplex()
        {
            Assert.AreEqual(new Word[]{new Word("a")}, complexTrie.GetWordsWithPrefix("a").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad")}, complexTrie.GetWordsWithPrefix("ad").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi")}, complexTrie.GetWordsWithPrefix("adi").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi"), new Word("adil")}, complexTrie.GetWordsWithPrefix("adil").ToArray());
            Assert.AreEqual(new Word[]{new Word("a"), new Word("ad"), new Word("adi"), new Word("adil"), new Word("adilane")}, complexTrie.GetWordsWithPrefix("adilane").ToArray());
            Assert.AreEqual(new Word[]{new Word("öl"), new Word("ölü")}, complexTrie.GetWordsWithPrefix("ölü").ToArray());
            Assert.AreEqual(new Word[]{new Word("öl"), new Word("ölü"), new Word("ölüm")}, complexTrie.GetWordsWithPrefix("ölüm").ToArray());
            Assert.AreEqual(new Word[]{new Word("ı"), new Word("ısı")}, complexTrie.GetWordsWithPrefix("ısı").ToArray());
            Assert.AreEqual(new Word[]{new Word("ı"), new Word("ısı"), new Word("ısıt"), new Word("ısıtıcı")}, complexTrie.GetWordsWithPrefix("ısıtıcı").ToArray());
        }
    }
}
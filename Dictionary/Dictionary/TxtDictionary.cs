using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Dictionary.Dictionary
{
    public class TxtDictionary : Dictionary, ICloneable
    {
        private readonly Dictionary<string, string> _misspelledWords = new Dictionary<string, string>();

        /**
         * <summary>A constructor of {@link TxtDictionary} class which takes a {@link WordComparator} as an input and calls its super
         * class {@link Dictionary} with given {@link WordComparator}.</summary>
         *
         * <param name="comparator">{@link WordComparator} type input.</param>
         */
        public TxtDictionary(IComparer<Word> comparator) : base(comparator)
        {
        }

        public TxtDictionary() : base(new TurkishWordComparator())
        {
            this.filename = "turkish_dictionary.txt";
            var assembly = typeof(Dictionary).Assembly;
            var dictionaryStream = assembly.GetManifestResourceStream("Dictionary.turkish_dictionary.txt");
            LoadFromText(dictionaryStream);
            var misspellingsStream = assembly.GetManifestResourceStream("Dictionary.turkish_misspellings.txt");
            LoadMisspelledWords(misspellingsStream);
            var morphologicalLexiconStream = assembly.GetManifestResourceStream("Dictionary.turkish_morphological_lexicon.txt");
            LoadMorphologicalLexicon(morphologicalLexiconStream);
        }

        /**
         * <summary>Another constructor of {@link TxtDictionary} class which takes a String filename and a {@link WordComparator} as inputs.
         * And calls its super class {@link Dictionary} with given {@link WordComparator}, assigns given filename input to the
         * filename variable. Then, it calls loadFromText method with given filename.</summary>
         *
         * <param name="filename">  String input.</param>
         * <param name="comparator">{@link WordComparator} input.</param>
         */
        public TxtDictionary(string filename, IComparer<Word> comparator) : base(comparator)
        {
            this.filename = filename;
            LoadFromText(new FileStream(filename, FileMode.Open));
        }

        /**
         * <summary>Another constructor of {@link TxtDictionary} class which takes a String filename, a {@link WordComparator} and
         * a misspelled word dictionary file as inputs. And calls its super class {@link Dictionary} with given
         * {@link WordComparator}, assigns given filename input to the filename variable. Then, it calls loadFromText
         * method with given filename. It also loads the misspelling file.</summary>
         *
         * <param name="fileName">  String input.</param>
         * <param name="comparator">{@link WordComparator} input.</param>
         * <param name="misspelledFileName">String input.</param>
         */
        public TxtDictionary(string fileName, IComparer<Word> comparator, string misspelledFileName) : base(comparator)
        {
            this.filename = fileName;
            LoadFromText(new FileStream(filename, FileMode.Open));
            LoadMisspelledWords(new FileStream(misspelledFileName, FileMode.Open));
        }

        /**
         * <summary>The clone method which creates new {@link TxtDictionary} object with filename and comparator variables.</summary>
         *
         * <returns>new {@link TxtDictionary} object.</returns>
         */
        public object Clone()
        {
            return new TxtDictionary(filename, comparator);
        }

        /**
         * <summary>The addNumber method takes a String name and calls addWithFlag method with given name and IS_SAYI flag.</summary>
         *
         * <param name="name">String input.</param>
         */
        public void AddNumber(string name)
        {
            AddWithFlag(name, "IS_SAYI");
        }

        /**
         * <summary>The addRealNumber method takes a String name and calls addWithFlag method with given name and IS_REELSAYI flag.</summary>
         *
         * <param name="name">String input.</param>
         */
        public void AddRealNumber(string name)
        {
            AddWithFlag(name, "IS_REELSAYI");
        }

        /**
         * <summary>The addFraction method takes a String name and calls addWithFlag method with given name and IS_KESIR flag.</summary>
         *
         * <param name="name">String input.</param>
         */
        public void AddFraction(string name)
        {
            AddWithFlag(name, "IS_KESIR");
        }

        /**
         * <summary>The addTime method takes a String name and calls addWithFlag method with given name and IS_ZAMAN flag.</summary>
         *
         * <param name="name">String input.</param>
         */
        public void AddTime(string name)
        {
            AddWithFlag(name, "IS_ZAMAN");
        }

        /**
         * <summary>The addProperNoun method takes a String name and calls addWithFlag method with given name and IS_OA flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddProperNoun(string name)
        {
            return AddWithFlag(name, "IS_OA");
        }

        /**
         * <summary>The addNoun method takes a String name and calls addWithFlag method with given name and CL_ISIM flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddNoun(string name)
        {
            return AddWithFlag(name, "CL_ISIM");
        }

        /**
         * <summary>The addVerb method takes a String name and calls addWithFlag method with given name and CL_FIIL flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddVerb(string name)
        {
            return AddWithFlag(name, "CL_FIIL");
        }

        /**
         * <summary>The addAdjective method takes a String name and calls addWithFlag method with given name and IS_ADJ flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddAdjective(string name)
        {
            return AddWithFlag(name, "IS_ADJ");
        }

        /**
         * <summary>The addAdverb method takes a String name and calls addWithFlag method with given name and IS_ADVERB flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddAdverb(string name)
        {
            return AddWithFlag(name, "IS_ADVERB");
        }

        /**
         * <summary>The addPronoun method takes a String name and calls addWithFlag method with given name and IS_ZM flag.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddPronoun(string name)
        {
            return AddWithFlag(name, "IS_ZM");
        }

        /**
         * <summary>The addWithFlag method takes a String name and a flag as inputs. First it creates a {@link TxtWord} word, then if
         * given name is not in words {@link java.util.ArrayList} it creates new {@link TxtWord} with given name and assigns it to
         * the word and adds given flag to the word, it also add newly created word to the words {@link java.util.ArrayList}'s index
         * found by performing a binary search and return true at the end. If given name is in words {@link java.util.ArrayList},
         * it adds it the given flag to the word.</summary>
         *
         * <param name="name">String input.</param>
         * <param name="flag">String flag.</param>
         * <returns>true if given name is in words {@link java.util.ArrayList}, false otherwise.</returns>
         */
        public bool AddWithFlag(string name, string flag)
        {
            TxtWord word;
            if (GetWord(name.ToLower(new CultureInfo("tr"))) == null)
            {
                word = new TxtWord(name.ToLower(new CultureInfo("tr")));
                word.AddFlag(flag);
                var insertIndex = words.BinarySearch(word, comparator);
                if (insertIndex >= 0)
                {
                    words.Insert(insertIndex, word);
                }

                return true;
            }

            word = (TxtWord) GetWord(name.ToLower(new CultureInfo("tr")));
            if (!word.ContainsFlag(flag))
            {
                word.AddFlag(flag);
            }

            return false;
        }

        /**
         * <summary>The loadFromText method takes a String filename as an input. It reads given file line by line and splits according to space
         * and assigns each word to the String array. Then, adds these word with their flags to the words {@link java.util.ArrayList}.
         * At the end it sorts the words {@link java.util.ArrayList}.</summary>
         *
         * <param name="stream">File stream input.</param>
         */
        private void LoadFromText(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var list = line.Split(" ");
                if (list.Length > 0)
                {
                    var currentWord = new TxtWord(list[0]);
                    int i;
                    for (i = 1; i < list.Length; i++)
                    {
                        currentWord.AddFlag(list[i]);
                    }

                    words.Add(currentWord);
                }

                line = streamReader.ReadLine();
            }

            words.Sort(comparator);
        }

        /**
         * <summary>The loadMisspellWords method takes a String filename as an input. It reads given file line by line and splits
         * according to space and assigns each word with its misspelled form to the the misspelledWords hashMap.</summary>
         *
         * <param name="stream">File stream input.</param>
         */
        private void LoadMisspelledWords(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var list = line.Split(" ");
                if (list.Length == 2)
                {
                    _misspelledWords[list[0]] = list[1];
                }

                line = streamReader.ReadLine();
            }
        }

        private void LoadMorphologicalLexicon(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var list = line.Split(" ");
                if (list.Length == 2)
                {
                    var word = (TxtWord) GetWord(list[0]);
                    if (word != null){
                        word.SetMorphology(list[1]);
                    }
                }

                line = streamReader.ReadLine();
            }
        }

        /**
         * <summary>The getCorrectForm returns the correct form of a misspelled word.</summary>
         * <param name="misspelledWord">Misspelled form.</param>
         * <returns>Correct form.</returns>
         */
        public string GetCorrectForm(string misspelledWord)
        {
            if (_misspelledWords.ContainsKey(misspelledWord))
            {
                return _misspelledWords[misspelledWord];
            }

            return null;
        }

        /**
         * <summary>The saveAsTxt method takes a filename as an input and prints out the items of words {@link java.util.ArrayList}.</summary>
         *
         * <param name="fileName">String input.</param>
         */
        public void SaveAsTxt(string fileName)
        {
            var outFile = new StreamWriter(fileName);
            foreach (var t in words)
            {
                outFile.WriteLine(t.ToString());
            }

            outFile.Close();
        }

        /**
         * <summary>The addWordWhenRootSoften is used to add word to Trie whose last consonant will be soften.
         * For instance, in the case of Dative Case Suffix, the word is 'müzik' when '-e' is added to the word, the last
         * char is drooped and root became 'müzi' and by changing 'k' into 'ğ' the word transformed into 'müziğe' as in the
         * example of 'Herkes müziğe doğru geldi'.
         * In the case of accusative, possessive of third person and a derivative suffix, the word is 'kanat' when '-i' is
         * added to word, last char is dropped, root became 'kana' then 't' transformed into 'd' and added to Trie. The word is
         * changed into 'kanadı' as in the case of 'Kuşun kırık kanadı'.</summary>
         *
         * <param name="trie">the name of the Trie to add the word.</param>
         * <param name="last">the last char of the word to be soften.</param>
         * <param name="root">the substring of the word whose last one or two chars are omitted from the word to bo softed.</param>
         * <param name="word">the original word.</param>
         */
        private void AddWordWhenRootSoften(Trie.Trie trie, char last, string root, TxtWord word)
        {
            switch (last)
            {
                case 'p':
                    trie.AddWord(root + 'b', word);
                    break;
                case '\u00e7': //ç
                    trie.AddWord(root + 'c', word);
                    break;
                case 't':
                    trie.AddWord(root + 'd', word);
                    break;
                case 'k':
                case 'g':
                    trie.AddWord(root + '\u011f', word); //ğ
                    break;
            }
        }

        /**
         * <summary>The prepareTrie method is used to create a Trie with the given dictionary. First, it gets the word from dictionary,
         * then checks some exceptions like 'ben' which does not fit in the consonant softening rule and transforms into 'bana',
         * and later on it generates a root by removing the last char from the word however if the length of the word is greater
         * than 1, it also generates the root by removing the last two chars from the word.
         * Then, it gets the last char of the root and adds root and word to the result Trie. There are also special cases such as;
         * lastIdropsDuringSuffixation condition, if it is true then addWordWhenRootSoften method will be used rather than addWord.
         * Ex : metin + i = metni
         * isPortmanteauEndingWithSI condition, if it is true then addWord method with rootWithoutLastTwo will be used.
         * Ex : ademelması + lar = ademelmaları
         * isPortmanteau condition, if it is true then addWord method with rootWithoutLast will be used.
         * Ex : mısıryağı + lar = mısıryağları
         * vowelEChangesToIDuringYSuffixation condition, if it is then addWord method with rootWithoutLast will be used
         * depending on the last char whether it is 'e' or 'a'.
         * Ex : ye + iniz - yiyiniz
         * endingKChangesIntoG condition, if it is true then addWord method with rootWithoutLast will be used with added 'g'.
         * Ex : ahenk + i = ahengi</summary>
         *
         * <returns>the resulting Trie.</returns>
         */
        public Trie.Trie PrepareTrie()
        {
            Trie.Trie result = new Trie.Trie();
            String root, rootWithoutLast, rootWithoutLastTwo;
            char last, lastBefore = ' ';
            int length;
            for (int i = 0; i < Size(); i++)
            {
                TxtWord word = (TxtWord) GetWord(i);
                root = word.GetName();
                length = root.Length;
                if (root == "ben")
                {
                    result.AddWord("bana", word);
                }

                if (root == "sen")
                {
                    result.AddWord("sana", word);
                }

                rootWithoutLast = root.Substring(0, length - 1);
                if (length > 1)
                {
                    rootWithoutLastTwo = root.Substring(0, length - 2);
                }
                else
                {
                    rootWithoutLastTwo = "";
                }

                if (length > 1)
                {
                    lastBefore = root[length - 2];
                }

                last = root[length - 1];
                result.AddWord(root, word);
                if (word.LastIdropsDuringSuffixation() || word.LastIdropsDuringPassiveSuffixation())
                {
                    if (word.RootSoftenDuringSuffixation())
                    {
                        AddWordWhenRootSoften(result, last, rootWithoutLastTwo, word);
                    }
                    else
                    {
                        result.AddWord(rootWithoutLastTwo + last, word);
                    }
                }

                // NominalRootNoPossessive
                if (word.IsPortmanteauEndingWithSI())
                {
                    result.AddWord(rootWithoutLastTwo, word);
                }

                if (word.RootSoftenDuringSuffixation())
                {
                    AddWordWhenRootSoften(result, last, rootWithoutLast, word);
                }

                if (word.IsPortmanteau())
                {
                    if (word.IsPortmanteauFacedVowelEllipsis())
                    {
                        result.AddWord(rootWithoutLastTwo + last + lastBefore, word);
                    }
                    else
                    {
                        if (word.IsPortmanteauFacedSoftening())
                        {
                            switch (lastBefore)
                            {
                                case 'b':
                                    result.AddWord(rootWithoutLastTwo + 'p', word);
                                    break;
                                case 'c':
                                    result.AddWord(rootWithoutLastTwo + 'ç', word);
                                    break;
                                case 'd':
                                    result.AddWord(rootWithoutLastTwo + 't', word);
                                    break;
                                case 'ğ':
                                    result.AddWord(rootWithoutLastTwo + 'k', word);
                                    break;
                            }
                        }
                        else
                        {
                            result.AddWord(rootWithoutLast, word);
                        }
                    }
                }

                if (word.VowelEChangesToIDuringYSuffixation() || word.VowelAChangesToIDuringYSuffixation())
                {
                    switch (last)
                    {
                        case 'e':
                            result.AddWord(rootWithoutLast, word);
                            break;
                        case 'a':
                            result.AddWord(rootWithoutLast, word);
                            break;
                    }
                }

                if (word.EndingKChangesIntoG())
                {
                    result.AddWord(rootWithoutLast + 'g', word);
                }
            }

            return result;
        }
    }
}
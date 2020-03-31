using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Dictionary.Dictionary
{
    public class TxtDictionary : Dictionary, ICloneable
    {
        private Dictionary<string, string> misspelledWords = new Dictionary<string, string>();

        /**
         * A constructor of {@link TxtDictionary} class which takes a {@link WordComparator} as an input and calls its super
         * class {@link Dictionary} with given {@link WordComparator}.
         *
         * @param comparator {@link WordComparator} type input.
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
        }

        /**
         * Another constructor of {@link TxtDictionary} class which takes a String filename and a {@link WordComparator} as inputs.
         * And calls its super class {@link Dictionary} with given {@link WordComparator}, assigns given filename input to the
         * filename variable. Then, it calls loadFromText method with given filename.
         *
         * @param filename   String input.
         * @param comparator {@link WordComparator} input.
         */
        public TxtDictionary(string filename, IComparer<Word> comparator) : base(comparator)
        {
            this.filename = filename;
            LoadFromText(new FileStream(filename, FileMode.Open));
        }

        /**
         * Another constructor of {@link TxtDictionary} class which takes a String filename, a {@link WordComparator} and
         * a misspelled word dictionary file as inputs. And calls its super class {@link Dictionary} with given
         * {@link WordComparator}, assigns given filename input to the filename variable. Then, it calls loadFromText
         * method with given filename. It also loads the misspelling file.
         *
         * @param fileName   String input.
         * @param comparator {@link WordComparator} input.
         * @param misspelledFileName String input.
         */
        public TxtDictionary(string fileName, IComparer<Word> comparator, string misspelledFileName) : base(comparator)
        {
            this.filename = fileName;
            LoadFromText(new FileStream(filename, FileMode.Open));
            LoadMisspelledWords(new FileStream(misspelledFileName, FileMode.Open));
        }

        /**
         * The clone method which creates new {@link TxtDictionary} object with filename and comparator variables.
         *
         * @return new {@link TxtDictionary} object.
         */
        public object Clone()
        {
            return new TxtDictionary(filename, comparator);
        }

        /**
         * The addNumber method takes a String name and calls addWithFlag method with given name and IS_SAYI flag.
         *
         * @param name String input.
         */
        public void AddNumber(string name)
        {
            AddWithFlag(name, "IS_SAYI");
        }

        /**
         * The addRealNumber method takes a String name and calls addWithFlag method with given name and IS_REELSAYI flag.
         *
         * @param name String input.
         */
        public void AddRealNumber(string name)
        {
            AddWithFlag(name, "IS_REELSAYI");
        }

        /**
         * The addFraction method takes a String name and calls addWithFlag method with given name and IS_KESIR flag.
         *
         * @param name String input.
         */
        public void AddFraction(string name)
        {
            AddWithFlag(name, "IS_KESIR");
        }

        /**
         * The addTime method takes a String name and calls addWithFlag method with given name and IS_ZAMAN flag.
         *
         * @param name String input.
         */
        public void AddTime(string name)
        {
            AddWithFlag(name, "IS_ZAMAN");
        }

        /**
         * The addProperNoun method takes a String name and calls addWithFlag method with given name and IS_OA flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddProperNoun(string name)
        {
            return AddWithFlag(name, "IS_OA");
        }

        /**
         * The addNoun method takes a String name and calls addWithFlag method with given name and CL_ISIM flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddNoun(string name)
        {
            return AddWithFlag(name, "CL_ISIM");
        }

        /**
         * The addVerb method takes a String name and calls addWithFlag method with given name and CL_FIIL flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddVerb(string name)
        {
            return AddWithFlag(name, "CL_FIIL");
        }

        /**
         * The addAdjective method takes a String name and calls addWithFlag method with given name and IS_ADJ flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddAdjective(string name)
        {
            return AddWithFlag(name, "IS_ADJ");
        }

        /**
         * The addAdverb method takes a String name and calls addWithFlag method with given name and IS_ADVERB flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddAdverb(string name)
        {
            return AddWithFlag(name, "IS_ADVERB");
        }

        /**
         * The addPronoun method takes a String name and calls addWithFlag method with given name and IS_ZM flag.
         *
         * @param name String input.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
         */
        public bool AddPronoun(string name)
        {
            return AddWithFlag(name, "IS_ZM");
        }

        /**
         * The addWithFlag method takes a String name and a flag as inputs. First it creates a {@link TxtWord} word, then if
         * given name is not in words {@link java.util.ArrayList} it creates new {@link TxtWord} with given name and assigns it to
         * the word and adds given flag to the word, it also add newly created word to the words {@link java.util.ArrayList}'s index
         * found by performing a binary search and return true at the end. If given name is in words {@link java.util.ArrayList},
         * it adds it the given flag to the word.
         *
         * @param name String input.
         * @param flag String flag.
         * @return true if given name is in words {@link java.util.ArrayList}, false otherwise.
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
         * The loadFromText method takes a String filename as an input. It reads given file line by line and splits according to space
         * and assigns each word to the String array. Then, adds these word with their flags to the words {@link java.util.ArrayList}.
         * At the end it sorts the words {@link java.util.ArrayList}.
         *
         * @param fileInputStream File stream input.
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
         * The loadMisspellWords method takes a String filename as an input. It reads given file line by line and splits
         * according to space and assigns each word with its misspelled form to the the misspelledWords hashMap.
         *
         * @param fileInputStream File stream input.
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
                    misspelledWords[list[0]] = list[1];
                }

                line = streamReader.ReadLine();
            }
        }
    }
}
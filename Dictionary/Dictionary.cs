using System.Collections.Generic;

namespace Dictionary.Dictionary
{
    public class Dictionary
    {
        protected List<Word> words;
        protected string filename;
        protected IComparer<Word> comparator;

        /**
         * <summary>An empty constructor of {@link Dictionary} class.</summary>
         */
        public Dictionary()
        {
        }
        
        /**
         * <summary>Another constructor of {@link Dictionary} class which takes a {@link WordComparator} as an input and initializes
         * comparator variable with given input and also creates a new words {@link ArrayList}.</summary>
         *
         * <param name="comparator">{@link WordComparator} type input.</param>
         */
        public Dictionary(IComparer<Word> comparator) {
            this.comparator = comparator;
            words = new List<Word>();
        }

        /**
         * <summary>The getWord method takes a String name as an input and performs binary search within words {@link ArrayList} and assigns the result
         * to integer variable middle. If the middle is greater than 0, it returns the item at index middle of words {@link ArrayList}, null otherwise.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>the item at found index of words {@link ArrayList}, null if cannot be found.</returns>
         */
        public Word GetWord(string name) {
            var middle = words.BinarySearch(new Word(name), comparator);
            if (middle >= 0) {
                return words[middle];
            }
            return null;
        }
        
        /**
         * <summary>RemoveWord removes a word with the given name</summary>
         * <param name="name">Name of the word to be removed.</param>
         */
        public void RemoveWord(string name){
            var middle = words.BinarySearch(new Word(name), comparator);
            if (middle >= 0){
                words.Remove(words[middle]);
            }
        }

        /**
         * <summary>The getWordIndex method takes a String name as an input and performs binary search within words {@link ArrayList} and assigns the result
         * to integer variable middle. If the middle is greater than 0, it returns the index middle, -1 otherwise.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>found index of words {@link ArrayList}, -1 if cannot be found.</returns>
         */
        public int GetWordIndex(string name) {
            var middle = words.BinarySearch(new Word(name), comparator);
            if (middle >= 0) {
                return middle;
            }
            return -1;
        }

        /**
         * <summary>The size method returns the size of the words {@link ArrayList}.</summary>
         *
         * <returns>the size of the words {@link ArrayList}.</returns>
         */
        public int Size() {
            return words.Count;
        }

        /**
         * <summary>The getWord method which takes an index as an input and returns the value at given index of words {@link ArrayList}.</summary>
         *
         * <param name="index">to get the value.</param>
         * <returns>the value at given index of words {@link ArrayList}.</returns>
         */
        public Word GetWord(int index) {
            return words[index];
        }

        /**
         * <summary>The longestWordSize method loops through the words {@link ArrayList} and returns the item with the maximum word length.</summary>
         *
         * <returns>the item with the maximum word length.</returns>
         */
        public int LongestWordSize() {
            var max = 0;
            foreach (var word in words) {
                if (word.GetName().Length > max) {
                    max = word.GetName().Length;
                }
            }
            return max;
        }

        /**
         * <summary>The getWordStartingWith method takes a String hash as an input and performs binary search within words {@link ArrayList} and assigns the result
         * to integer variable middle. If the middle is greater than 0, it returns the index middle, -middle-1 otherwise.</summary>
         *
         * <param name="hash">String input.</param>
         * <returns>found index of words {@link ArrayList}, -middle-1 if cannot be found.</returns>
         */
        public int GetWordStartingWith(string hash)
        {
            var middle = words.BinarySearch(new Word(hash), comparator);
            if (middle >= 0) {
                return middle;
            }

            return ~middle;
        }

    }
}
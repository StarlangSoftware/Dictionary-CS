using System.Collections.Generic;

namespace Dictionary.Dictionary.Trie
{
    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _children;
        private HashSet<Word> _words;

        /**
         * <summary>A constructor of {@link TrieNode} class which creates a new children {@link HashMap}.</summary>
         */
        public TrieNode()
        {
            _children = new Dictionary<char, TrieNode>();
        }

        /**
         * <summary>The addWord method takes a String word, an index, and a {@link Word} root as inputs. First it creates a {@link TrieNode} child
         * and if words {@link HashSet} is null it creates a new {@link HashSet} and add the given root word to this {@link HashSet}, if it
         * is not null, it directly adds it to the {@link HashSet} when the given index is equal to the length of given word.
         * Then, it extracts the character at given index of given word and if children {@link HashMap} contains a mapping for the
         * extracted character, it assigns it to the {@link TrieNode} child, else it creates a new {@link TrieNode} and assigns it to the
         * child. At the end, it recursively calls the addWord method with the next index of child and puts the character with
         * the child into the children {@link HashMap}.</summary>
         *
         * <param name="word"> String input.</param>
         * <param name="index">Integer index.</param>
         * <param name="root"> {@link Word} input to add.</param>
         */
        private void AddWord(string word, int index, Word root)
        {
            TrieNode child;
            if (index == word.Length)
            {
                if (_words == null)
                {
                    _words = new HashSet<Word> {root};
                }
                else
                {
                    _words.Add(root);
                }

                return;
            }

            char ch = word[index];
            if (_children.ContainsKey(ch))
            {
                child = _children[ch];
            }
            else
            {
                child = new TrieNode();
            }

            child.AddWord(word, index + 1, root);
            _children[ch] = child;
        }

        /**
         * <summary>The addWord method takes a String word and a {@link Word} type root as inputs. It calls addWord method with index 0.</summary>
         *
         * <param name="word">String input.</param>
         * <param name="root">{@link Word} type input.</param>
         */
        public void AddWord(string word, Word root)
        {
            AddWord(word, 0, root);
        }

        /**
         * <summary>The getChild method takes a {@link Character} and gets its corresponding value from children {@link HashMap}.</summary>
         *
         * <param name="ch">{@link Character} input.</param>
         * <returns>the value from children {@link HashMap}.</returns>
         */
        public TrieNode GetChild(char ch)
        {
            if (_children.ContainsKey(ch))
            {
                return _children[ch];
            }

            return null;
        }

        /**
         * <summary>The getWords method returns the words {@link HashSet}.</summary>
         *
         * <returns>the words {@link HashSet}.</returns>
         */
        public HashSet<Word> GetWords()
        {
            return _words;
        }
    }
}
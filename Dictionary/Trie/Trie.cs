using System.Collections.Generic;

namespace Dictionary.Dictionary.Trie
{
    public class Trie
    {
        private readonly TrieNode _rootNode;

        /**
         * <summary>A constructor of {@link Trie} class which creates a new {@link TrieNode} as rootNode.</summary>
         */
        public Trie()
        {
            _rootNode = new TrieNode();
        }

        /**
         * <summary>The addWord method which takes a String word and a {@link Word} root as inputs and adds given word and root to the rootNode.</summary>
         *
         * <param name="word">String input.</param>
         * <param name="root">{@link Word} input.</param>
         */
        public void AddWord(string word, Word root)
        {
            _rootNode.AddWord(word, root);
        }

        /**
         * <summary>The getWordsWithPrefix method which takes a String surfaceForm as an input. First it creates a {@link TrieNode} current and assigns
         * the rootNode to it, then it creates a new {@link HashSet} words. It loops i times where i ranges from 0 to length of surfaceForm
         * and assigns current's child that corresponds to the surfaceForm's char at index i and assigns it as {@link TrieNode} current.
         * If current is not null, it adds all words of current to the words {@link HashSet}.</summary>
         *
         * <param name="surfaceForm">String input.</param>
         * <returns>words {@link HashSet}.</returns>
         */
        public HashSet<Word> GetWordsWithPrefix(string surfaceForm)
        {
            var current = _rootNode;
            var words = new HashSet<Word>();
            foreach (var t in surfaceForm)
            {
                current = current.GetChild(t);
                if (current != null)
                {
                    if (current.GetWords() != null)
                    {
                        words.UnionWith(current.GetWords());
                    }
                }
                else
                {
                    break;
                }
            }

            return words;
        }

        /**
         * <summary>The getCompoundWordStartingWith method takes a String hash. First it creates a {@link TrieNode} current and assigns
         * the rootNode to it. Then it loops i times where i ranges from 0 to length of given hash and assigns current's child that
         * corresponds to the hash's char at index i and assigns it as current. If current is null, it returns null.
         * If current is not null,  it loops through the words of current {@link TrieNode} and if it is a Portmanteau word, it
         * directly returns the word.</summary>
         *
         * <param name="hash">String input.</param>
         * <returns>null if {@link TrieNode} is null, otherwise portmanteau word.</returns>
         */
        public TxtWord GetCompoundWordStartingWith(string hash)
        {
            var current = _rootNode;
            foreach (var t in hash)
            {
                current = current.GetChild(t);
                if (current == null)
                {
                    return null;
                }
            }

            if (current?.GetWords() != null)
            {
                foreach (var word in current.GetWords())
                {
                    if (((TxtWord) word).IsPortmanteau())
                    {
                        return (TxtWord) word;
                    }
                }
            }

            return null;
        }
    }
}
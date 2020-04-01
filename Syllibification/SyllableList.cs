using System.Collections.Generic;
using Dictionary.Language;

namespace Dictionary.Syllibification
{
    public class SyllableList
    {
        private readonly List<Syllable> _syllables;

        /**
         * <summary>A constructor of {@link SyllableList} class which takes a String word as an input. First it creates a syllable {@link ArrayList}
         * and a {@link StringBuilder} sbSyllable. Then it loops i times, where i ranges from 0 to length of given word, first
         * it gets the ith character of given word and checks whether it is a vowel and the last character of the word.
         * If it is a vowel it appends it to the sbSyllable and if it is the last vowel it also appends the next character to the sbSyllable.
         * Then, it adds the sbSyllable tot he syllables {@link ArrayList}.
         * If it is not a vowel, and the sbSyllable's length is 1 also the previous character is a consonant it gets the last item of
         * syllables {@link ArrayList} since there cannot be a Turkish word which starts with two consonants. However, if it is
         * two last characters of word, then it adds it to the syllable {@link ArrayList}. At the end, it updates the syllables {@link ArrayList}.</summary>
         *
         * <param name="word">String input.</param>
         */
        public SyllableList(string word)
        {
            _syllables = new List<Syllable>();

            string sbSyllable = "";
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                bool isVowel = TurkishLanguage.IsVowel(c);
                bool isLastChar = i == word.Length - 1;
                if (isVowel)
                {
                    sbSyllable += c;
                    // If it is the last vowel.
                    if (i == word.Length - 2)
                    {
                        sbSyllable += word[i + 1];
                        i++;
                    }

                    _syllables.Add(new Syllable(sbSyllable));
                    sbSyllable = "";
                }
                else
                {
                    // A syllable should not start with two consonants.
                    var tempSyl = sbSyllable;
                    if (tempSyl.Length == 1)
                    {
                        // The previous character was also a consonant.
                        if (!TurkishLanguage.IsVowel(tempSyl[0]))
                        {
                            var lastPos = _syllables.Count - 1;
                            var str = _syllables[lastPos].GetText();
                            str += tempSyl;
                            if (isLastChar)
                            {
                                // If the last char is also a consonant, add it to latest syllable. Ex: 'park'.
                                str += c;
                            }

                            // Update previous syllable.
                            _syllables[lastPos] =  new Syllable(str);
                            sbSyllable = "" + c;
                        }
                    }

                    sbSyllable += c;
                }
            }
        }
        
        /**
         * <summary>The getSyllables method creates a new {@link ArrayList} syllables and loops through the globally defined syllables
         * {@link ArrayList} and adds each item to the newly created syllables {@link ArrayList}.</summary>
         *
         * <returns>ArrayList syllables.</returns>
         */
        public List<string> GetSyllables() {
            var resultSyllables = new List<string>();
            foreach (var syllable in _syllables) {
                resultSyllables.Add(syllable.GetText());
            }
            return resultSyllables;
        }

    }
}
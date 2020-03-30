using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Dictionary.Language;

namespace Dictionary.Dictionary
{
    public class Word : ICloneable
    {
        protected string name;

        /**
         * <summary>An empty constructor of {@link Word} class.</summary>
         */
        public Word()
        {
        }

        /**
         * <summary>A constructor of {@link Word} class which gets a String name as an input and assigns to the name variable.</summary>
         *
         * <param name="name">String input.</param>
         */
        public Word(string name)
        {
            this.name = name;
        }

        /**
         * <summary>The overridden hashCode method returns the hash code for the name.</summary>
         *
         * <returns>the hash code for the name.</returns>
         */
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        /**
         * <summary>The overridden equals method takes an {@link Object} as an input and returns the result of comparison of name variable
         * and name of given {@link Object}.</summary>
         *
         * <param name="aThat">{@link Object} input.</param>
         * <returns>the result of comparison of name variable and name of given {@link Object}.</returns>
         */
        public override bool Equals(object aThat)
        {
            if (this == aThat)
            {
                return true;
            }

            if (!(aThat is Word))
            {
                return false;
            }

            var that = (Word) aThat;
            return that.name == name;
        }

        /**
         * <summary>The overridden toString method returns the name variable.</summary>
         *
         * <returns>the name variable.</returns>
         */
        public override string ToString()
        {
            return name;
        }
        
        /**
         * <summary>The charCount method returns the length of name variable.</summary>
         *
         * <returns>the length of name variable.</returns>
         */
        public int CharCount() {
            return name.Length;
        }

        /**
         * <summary>The overridden clone method returns new {@link Word} as name.</summary>
         *
         * <returns>new {@link Word} as name.</returns>
         */
        public object Clone()
        {
            return new Word(name);
        }

        /**
         * <summary>Getter for the name variable.</summary>
         *
         * <returns>name variable.</returns>
         */
        public string GetName() {
            return name;
        }

        /**
         * <summary>Setter for the name variable.</summary>
         *
         * <param name="name">String input.</param>
         */
        public void SetName(string name) {
            this.name = name;
        }

        /**
         * <summary>The isCapital method takes a String surfaceForm as an input and returns true if the character at first index of surfaceForm
         * is a capital letter, false otherwise.</summary>
         *
         * <param name="surfaceForm">String input to check the first character.</param>
         * <returns>true if the character at first index of surfaceForm is a capital letter, false otherwise.</returns>
         */
        public static bool IsCapital(string surfaceForm) {
            return TurkishLanguage.UPPERCASE_LETTERS.IndexOf(surfaceForm[0]) != -1;
        }

        /**
         * <summary>The isPunctuation method takes a String surfaceForm as an input and returns true if it is a punctuation, false otherwise.
         * Grave accent : \u0060
         * Left quotation mark : \u201C
         * Right quotation mark : \u201D
         * Left single quotation mark : \u2018
         * Horizontal ellipsis : \u2026</summary>
         *
         * <param name="surfaceForm">String input to check.</param>
         * <returns>true if it is a punctuation, false otherwise.</returns>
         */
        public static bool IsPunctuation(string surfaceForm) {
            return surfaceForm == "." ||  surfaceForm == "..." ||  surfaceForm == "[" ||  surfaceForm == "]" ||  surfaceForm == "\u2026" ||  surfaceForm == "%" ||  surfaceForm == "&" ||  surfaceForm == "=" ||  surfaceForm == "\u0060\u0060" ||  surfaceForm == "\u0060" ||  surfaceForm == "''" ||  surfaceForm == "$" ||  surfaceForm == "!" ||  surfaceForm == "?" ||  surfaceForm == "," ||  surfaceForm == ":" ||  surfaceForm == "--" ||  surfaceForm == ";" ||  surfaceForm == "(" ||  surfaceForm == ")" ||  surfaceForm == "'" ||  surfaceForm == "\"" ||  surfaceForm == "\u201C" ||  surfaceForm == "\u2018" ||  surfaceForm == "\u201D" ||  surfaceForm == "…" ||  surfaceForm == "\u25CF" ||  surfaceForm == "/" ||  surfaceForm == "-" ||  surfaceForm == "+" ||  surfaceForm == "-LRB-" ||  surfaceForm == "-RRB-" ||  surfaceForm == "-LCB-" ||  surfaceForm == "-RCB-" ||  surfaceForm == "-LSB-" ||  surfaceForm == "-RSB-";
        }

        /**
         * <summary>The isHonorific method takes a String surfaceForm as an input and after converting it to lower case it returns true
         * if it equals to "bay" or "bayan", false otherwise.</summary>
         *
         * <param name="surfaceForm">String input to check.</param>
         * <returns>true if it equals to "bay" or "bayan", false otherwise.</returns>
         */
        public static bool IsHonorific(string surfaceForm) {
            var lowerCase = surfaceForm.ToLower(new CultureInfo("tr"));
            return lowerCase == "bay" || lowerCase == "bayan";
        }

        /**
         * <summary>The isOrganization method takes a String surfaceForm as an input and after converting it to lower case it returns true
         * if it equals to "şirket", "corp", "inc.", or "co.", and false otherwise.</summary>
         *
         * <param name="surfaceForm">String input to check.</param>
         * <returns>true if it equals to "şirket", "corp", "inc.", or "co.", and false otherwise.</returns>
         */
        public static bool IsOrganization(string surfaceForm) {
            var lowerCase = surfaceForm.ToLower(new CultureInfo("tr"));
            return lowerCase == "corp" || lowerCase == "inc." || lowerCase == "co.";
        }

        /**
         * <summary>The isMoney method takes a String surfaceForm as an input and after converting it to lower case it returns true
         * if it equals to one of the dolar, sterlin, paunt, ons, ruble, mark, frank, yan, sent, yen' or $, and false otherwise.</summary>
         *
         * <param name="surfaceForm">String input to check.</param>
         * <returns>true if it equals to one of the dolar, sterlin, paunt, ons, ruble, mark, frank, yan, sent, yen' or $, and false otherwise.</returns>
         */
        public static bool IsMoney(string surfaceForm) {
            var lowerCase = surfaceForm.ToLower(new CultureInfo("tr"));
            return lowerCase.StartsWith("dolar") || lowerCase.StartsWith("sterlin") || lowerCase.StartsWith("paunt") || lowerCase.StartsWith("ons") || lowerCase.StartsWith("ruble") || lowerCase.StartsWith("mark") || lowerCase.StartsWith("frank") || lowerCase == "yen" || lowerCase.StartsWith("sent") || lowerCase.StartsWith("cent") || lowerCase.StartsWith("yen'") || lowerCase.Contains("$");
        }

        /**
         * <summary>The isPunctuation method without any argument, it checks name variable whether it is a punctuation or not and
         * returns true if so.</summary>
         *
         * <returns>true if name is a punctuation.</returns>
         */
        public bool IsPunctuation() {
            return name == "," || name == "." || name == "!" || name == "?" || name == ":"
                   || name == ";" || name == "\"" || name == "''" || name == "'" || name == "`"
                   || name == "``" || name == "..." || name == "-" || name == "--";
        }

        /**
         * <summary>he isTime method takes a String surfaceForm as an input and after converting it to lower case it checks some cases.
         * If it is in the form of 12:23:34 or 12:23 it returns true.
         * If it starts with name of months; ocak, şubat, mart, nisan, mayıs, haziran, temmuz, ağustos, eylül, ekim, kasım, aralık it returns true.
         * If it equals to the name of days; pazar, pazartesi, salı, çarşamba, perşembe, cuma, cumartesi it returns true.</summary>
         *
         * <param name="surfaceForm">String input to check.</param>
         * <returns>true if it presents time, and false otherwise.</returns>
         */
        public static bool IsTime(string surfaceForm) {
            var lowerCase = surfaceForm.ToLower(new CultureInfo("tr"));
            if (new Regex( "(\\d\\d|\\d):(\\d\\d|\\d):(\\d\\d|\\d)").IsMatch(lowerCase) || new Regex("(\\d\\d|\\d):(\\d\\d|\\d)").IsMatch(lowerCase)) {
                return true;
            }
            if (lowerCase.StartsWith("ocak") || lowerCase.StartsWith("şubat") || lowerCase.StartsWith("mart") || lowerCase.StartsWith("nisan") || lowerCase.StartsWith("mayıs") || lowerCase.StartsWith("haziran") || lowerCase.StartsWith("temmuz") || lowerCase.StartsWith("ağustos") || lowerCase.StartsWith("eylül") || lowerCase.StartsWith("ekim") || lowerCase.StartsWith("kasım") || lowerCase == "aralık") {
                return true;
            }
            if (lowerCase == "pazar" || lowerCase == "salı" || lowerCase.StartsWith("çarşamba") || lowerCase.StartsWith("perşembe") || lowerCase == "cuma" || lowerCase.StartsWith("cumartesi") || lowerCase.StartsWith("pazartesi")) {
                return true;
            }
            if (lowerCase.Contains("'")) {
                lowerCase = lowerCase.Substring(0, lowerCase.IndexOf("'"));
            }
            try {
                var time = int.Parse(lowerCase);
                if (time > 1900 && time < 2200) {
                    return true;
                }
            } catch (ArgumentException nfe) {
            }
            return false;
        }

        /**
         * <summary>The toWordArray method takes a String {@link java.lang.reflect.Array} sourceArray as an input. First it creates
         * a {@link Word} type result array and puts items of input sourceArray to this result {@link java.lang.reflect.Array}.</summary>
         *
         * <param name="sourceArray">String {@link java.lang.reflect.Array}.</param>
         * <returns>Word type {@link java.lang.reflect.Array}.</returns>
         */
        public static Word[] ToWordArray(string[] sourceArray) {
            var result = new Word[sourceArray.Length];
            for (var i = 0; i < sourceArray.Length; i++) {
                result[i] = new Word(sourceArray[i]);
            }
            return result;
        }

        /**
         * <summary>The toCharacters method creates a {@link Word} type characters {@link ArrayList} and adds characters of name variable
         * to newly created {@link ArrayList}.</summary>
         *
         * <returns>Word type {@link ArrayList}.</returns>
         */
        public List<Word> ToCharacters() {
            var characters = new List<Word>();
            foreach (var t in name)
                characters.Add(new Word("" + t));
            return characters;
        }

    }
}
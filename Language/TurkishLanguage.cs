namespace Dictionary.Language
{
    public class TurkishLanguage : Language
    {
        public static string VOWELS = "aeıioöuüâî";
        public static string BACK_VOWELS = "aıouâ";
        public static string FRONT_VOWELS = "eiöüî";
        public static string BACK_ROUNDED_VOWELS = "ou";
        public static string BACK_UNROUNDED_VOWELS = "aıâ";
        public static string FRONT_ROUNDED_VOWELS = "öü";
        public static string FRONT_UNROUNDED_VOWELS = "eiî";
        public static string CONSONANT_DROPS = "nsy";
        public static string CONSONANTS = "bcçdfgğhjklmnprsştvyzxqw";
        public static string SERT_SESSIZ = "çfhkpsşt";
        public static string LOWERCASE_LETTERS = "abcçdefgğhıijklmnoöprsştuüvyz";
        public static string UPPERCASE_LETTERS = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
        public static string LETTERS = LOWERCASE_LETTERS + UPPERCASE_LETTERS;

        /**
         * The isVowel method takes a character as an input and returns true if given character is a vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a vowel.
         */
        public static bool IsVowel(char ch)
        {
            return VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isBackVowel method takes a character as an input and returns true if given character is a back vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a back vowel.
         */
        public static bool IsBackVowel(char ch)
        {
            return BACK_VOWELS.IndexOf(ch) != -1;
        }
        
        /**
         * The isFrontVowel method takes a character as an input and returns true if given character is a front vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a front vowel.
         */
        public static bool IsFrontVowel(char ch) {
            return FRONT_VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isBackRoundedVowel method takes a character as an input and returns true if given character is a back rounded vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a back rounded vowel.
         */
        public static bool IsBackRoundedVowel(char ch) {
            return BACK_ROUNDED_VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isFrontRoundedVowel method takes a character as an input and returns true if given character is a front rounded vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a front rounded vowel.
         */
        public static bool IsFrontRoundedVowel(char ch) {
            return FRONT_ROUNDED_VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isBackUnroundedVowel method takes a character as an input and returns true if given character is a back unrounded vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a back unrounded vowel.
         */
        public static bool IsBackUnroundedVowel(char ch) {
            return BACK_UNROUNDED_VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isFrontUnroundedVowel method takes a character as an input and returns true if given character is a front unrounded vowel.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a front unrounded vowel.
         */
        public static bool IsFrontUnroundedVowel(char ch) {
            return FRONT_UNROUNDED_VOWELS.IndexOf(ch) != -1;
        }

        /**
         * The isConsonantDrop method takes a character as an input and returns true if given character is a dropping consonant.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a dropping consonant.
        */
        public static bool IsConsonantDrop(char ch) {
            return CONSONANT_DROPS.IndexOf(ch) != -1;
        }

        /**
         * The isConsonant method takes a character as an input and returns true if given character is a consonant.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a consonant.
         */
        public static bool IsConsonant(char ch) {
            return CONSONANTS.IndexOf(ch) != -1;
        }

        /**
         * The isSertSessiz method takes a character as an input and returns true if given character is a sert sessiz.
         *
         * @param ch {@link Character} input to check.
         * @return true if given character is a sert sessiz.
         */
        public static bool IsSertSessiz(char ch) {
            return SERT_SESSIZ.IndexOf(ch) != -1;
        }

    }
}
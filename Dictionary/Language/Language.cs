namespace Dictionary.Language
{
    public abstract class Language
    {
        /**
         * Digits : 0123456789
         * Arithmetic Characters : +-/=\*
         * Extended Language Characters
         * Black dot : \u25CF
         */
        public static string DIGITS = "0123456789";
        public static string ARITHMETIC_CHARACTERS = "+-*/=";
        public static string EXTENDED_LANGUAGE_CHARACTERS = "âàáäãèéêëíîòóôûúqwxÂÈÉÊËÌÒÛQWX\u25CF";
        
    }
}
namespace Dictionary.Syllibification
{
    public class Syllable
    {
        private readonly string _syllable;

        /**
         * <summary>A constructor of {@link Syllable} class which takes a String as an input and initializes syllable variable with given input.</summary>
         *
         * <param name="syllable">String input.</param>
         */
        public Syllable(string syllable) {
            this._syllable = syllable;
        }

        /**
         * <summary>Getter for the syllable variable.</summary>
         *
         * <returns>the syllable variable.</returns>
         */
        public string GetText() {
            return _syllable;
        }

    }
}
namespace Dictionary.Dictionary
{
    public class ExceptionalWord : Word
    {
        private readonly string _root;
        private readonly Pos _pos;

        /**
         * <summary>A constructor of {@link ExceptionalWord} class which takes a {@link Pos} as a  part of speech and two Strings; name
         * and root as inputs. Then, calls its super class {@link Word} with given name and initialises root and pos variables
         * with given inputs.</summary>
         *
         * <param name="name">String input.</param>
         * <param name="root">String input.</param>
         * <param name="pos"> {@link Pos} type input.</param>
         */
        public ExceptionalWord(string name, string root, Pos pos) : base(name)
        {
            this._root = root;
            this._pos = pos;
        }

        /**
         * <summary>Getter for the root variable.</summary>
         *
         * <returns>root variable.</returns>
         */
        public string GetRoot()
        {
            return _root;
        }

        /**
         * <summary>Getter for the pos variable.</summary>
         *
         * <returns>pos variable.</returns>
         */
        public Pos GetPos()
        {
            return _pos;
        }
    }
}
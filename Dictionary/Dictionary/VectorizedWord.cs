using Math;

namespace Dictionary.Dictionary
{
    public class VectorizedWord : Word
    {
        private readonly Vector _vector;
        
        /**
         * <summary>A constructor of {@link VectorizedWord} class which takes a String and a {@link Vector} as inputs and calls its
         * super class {@link Word} with name and also initializes vector variable with given input.</summary>
         *
         * <returns>name</returns>
         * <returns>vector</returns>
         */
        public VectorizedWord(string name, Vector vector) : base(name){
            this._vector = vector;
        }

        /**
         * <summary>Getter for the vector variable.</summary>
         *
         * <returns>the vector variable.</returns>
         */
        public Vector GetVector() {
            return _vector;
        }

    }
}
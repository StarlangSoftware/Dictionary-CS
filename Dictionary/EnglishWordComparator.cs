using System;
using System.Collections.Generic;

namespace Dictionary.Dictionary
{
    public class EnglishWordComparator : IComparer<Word>
    {
        /**
         * <summary>The compare method takes two {@link Word}s as inputs; wordA and wordB and compares their names. Returns the result of this comparison.</summary>
         *
         * <param name="x">Word type input.</param>
         * <param name="y">Word type input.</param>
         * <returns>the value {@code 0} if the wordA is equal to the wordB; a value less than {@code 0} if this wordA is
         * lexicographically less than wordB; and a value greater than {@code 0} if this wordA is lexicographically greater
         * than wordB.</returns>
         */
        public int Compare(Word x, Word y)
        {
            return string.CompareOrdinal(x.GetName(), y.GetName());
        }
    }
}
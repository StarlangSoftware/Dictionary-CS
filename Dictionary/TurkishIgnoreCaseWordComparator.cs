using System.Collections.Generic;
using System.Globalization;

namespace Dictionary.Dictionary
{
    public class TurkishIgnoreCaseWordComparator : IComparer<Word>
    {
        /**
         * <summary>The compare method takes two {@link Word}s as inputs; wordA and wordB and compares their names. First it creates
         * a {@link Locale} object which represents a specific geographical, political, or cultural region  and an instance of
         * {@link Collator} which performs locale-sensitive String comparison. Then, it returns the result of this comparison.</summary>
         *
         * <param name="x">Word type input.</param>
         * <param name="y">Word type input.</param>
         * <returns>the value {@code 0} if the wordA is equal to the wordB; a value less than {@code 0} if this wordA is
         * lexicographically less than wordB; and a value greater than {@code 0} if this wordA is lexicographically greater
         * than wordB.</returns>
     */
        public int Compare(Word x, Word y)
        {
            return string.Compare(x.GetName(), y.GetName(), true, new CultureInfo("tr-TR"));
        }
    }
}
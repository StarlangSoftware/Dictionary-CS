using System.Collections.Generic;
using Dictionary.Dictionary;
using NUnit.Framework;

namespace Test.Dictionary
{
    public class TxtWordTest
    {
        TxtDictionary dictionary;

        [SetUp]
        public void SetUp()
        {
            dictionary = new TxtDictionary();
        }

        [Test]
        public void TestVerbType()
        {
            var verbs = new Dictionary<string, int>();
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                var verbType = word.VerbType();
                if (verbs.ContainsKey(verbType))
                {
                    verbs[verbType] = verbs[verbType] + 1;
                }
                else
                {
                    verbs.Add(verbType, 1);
                }
            }

            Assert.AreEqual(5, verbs["F2P1-NO-REF"]);
            Assert.AreEqual(1, verbs["F3P1-NO-REF"]);
            Assert.AreEqual(1, verbs["F4P1-NO-REF"]);
            Assert.AreEqual(14, verbs["F4PR-NO-REF"]);
            Assert.AreEqual(2, verbs["F4PL-NO-REF"]);
            Assert.AreEqual(67, verbs["F4PW-NO-REF"]);
            Assert.AreEqual(10, verbs["F5PL-NO-REF"]);
            Assert.AreEqual(111, verbs["F5PR-NO-REF"]);
            Assert.AreEqual(1, verbs["F5PW-NO-REF"]);
            Assert.AreEqual(2, verbs["F1P1"]);
            Assert.AreEqual(11, verbs["F2P1"]);
            Assert.AreEqual(4, verbs["F3P1"]);
            Assert.AreEqual(1, verbs["F4P1"]);
            Assert.AreEqual(1, verbs["F5P1"]);
            Assert.AreEqual(7, verbs["F6P1"]);
            Assert.AreEqual(2, verbs["F2PL"]);
            Assert.AreEqual(49, verbs["F4PL"]);
            Assert.AreEqual(18, verbs["F5PL"]);
            Assert.AreEqual(173, verbs["F4PR"]);
            Assert.AreEqual(808, verbs["F5PR"]);
            Assert.AreEqual(1396, verbs["F4PW"]);
            Assert.AreEqual(13, verbs["F5PW"]);
        }

        [Test]
        public void TestIsNominal()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsNominal())
                {
                    count++;
                }
            }

            Assert.AreEqual(30601, count);
        }

        [Test]
        public void TestIsPassive()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPassive())
                {
                    count++;
                }
            }

            Assert.AreEqual(10, count);
        }

        [Test]
        public void TestIsAbbreviation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsAbbreviation())
                {
                    count++;
                }
            }

            Assert.AreEqual(102, count);
        }

        [Test]
        public void TestIsInterjection()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsInterjection())
                {
                    count++;
                }
            }

            Assert.AreEqual(104, count);
        }

        [Test]
        public void TestIsDuplicate()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsInterjection())
                {
                    count++;
                }
            }

            Assert.AreEqual(104, count);
        }

        [Test]
        public void TestIsAdjective()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsAdjective())
                {
                    count++;
                }
            }

            Assert.AreEqual(9679, count);
        }

        [Test]
        public void TestIsPronoun()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPronoun())
                {
                    count++;
                }
            }

            Assert.AreEqual(49, count);
        }

        [Test]
        public void TestIsQuestion()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsQuestion())
                {
                    count++;
                }
            }

            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestIsVerb()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsVerb())
                {
                    count++;
                }
            }

            Assert.AreEqual(5042, count);
        }

        [Test]
        public void TestIsPortmanteau()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPortmanteau())
                {
                    count++;
                }
            }

            Assert.AreEqual(1294, count);
        }

        [Test]
        public void TestIsDeterminer()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsDeterminer())
                {
                    count++;
                }
            }

            Assert.AreEqual(13, count);
        }

        [Test]
        public void TestIsConjunction()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsConjunction())
                {
                    count++;
                }
            }

            Assert.AreEqual(51, count);
        }

        [Test]
        public void TestIsAdverb()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsAdverb())
                {
                    count++;
                }
            }

            Assert.AreEqual(1849, count);
        }

        [Test]
        public void TestIsPostP()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPostP())
                {
                    count++;
                }
            }

            Assert.AreEqual(49, count);
        }

        [Test]
        public void TestIsPortmanteauEndingWithSI()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPortmanteauEndingWithSI())
                {
                    count++;
                }
            }

            Assert.AreEqual(178, count);
        }

        [Test]
        public void TestIsPortmanteauFacedVowelEllipsis()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPortmanteauFacedVowelEllipsis())
                {
                    count++;
                }
            }

            Assert.AreEqual(25, count);
        }

        [Test]
        public void TestIsPortmanteauFacedSoftening()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPortmanteauFacedSoftening())
                {
                    count++;
                }
            }

            Assert.AreEqual(348, count);
        }

        [Test]
        public void TestIsSuffix()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsSuffix())
                {
                    count++;
                }
            }

            Assert.AreEqual(3, count);
        }

        [Test]
        public void TestIsProperNoun()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsProperNoun())
                {
                    count++;
                }
            }

            Assert.AreEqual(19012, count);
        }

        [Test]
        public void TestIsPlural()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsPlural())
                {
                    count++;
                }
            }

            Assert.AreEqual(398, count);
        }

        [Test]
        public void TestIsNumeral()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsNumeral())
                {
                    count++;
                }
            }

            Assert.AreEqual(33, count);
        }

        [Test]
        public void TestNotObeysVowelHarmonyDuringAgglutination()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.NotObeysVowelHarmonyDuringAgglutination())
                {
                    count++;
                }
            }

            Assert.AreEqual(315, count);
        }

        [Test]
        public void TestObeysAndNotObeysVowelHarmonyDuringAgglutination()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.ObeysAndNotObeysVowelHarmonyDuringAgglutination())
                {
                    count++;
                }
            }

            Assert.AreEqual(5, count);
        }

        [Test]
        public void TestRootSoftenDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.RootSoftenDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(5529, count);
        }

        [Test]
        public void TestRootSoftenAndNotSoftenDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.RootSoftenAndNotSoftenDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(14, count);
        }

        [Test]
        public void TestVerbSoftenDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.VerbSoftenDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(87, count);
        }

        [Test]
        public void TestNounSoftenDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.NounSoftenDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(5443, count);
        }

        [Test]
        public void TestEndingKChangesIntoG()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.EndingKChangesIntoG())
                {
                    count++;
                }
            }

            Assert.AreEqual(26, count);
        }

        [Test]
        public void TestIsExceptional()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.IsExceptional())
                {
                    count++;
                }
            }

            Assert.AreEqual(31, count);
        }

        [Test]
        public void TestDuplicatesDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.DuplicatesDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(36, count);
        }

        [Test]
        public void TestDuplicatesAndNotDuplicatesDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.DuplicatesAndNotDuplicatesDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestLastIdropsDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.LastIdropsDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(167, count);
        }

        [Test]
        public void TestLastIDropsAndNotDropDuringSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.LastIDropsAndNotDropDuringSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestTakesRelativeSuffixKi()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.TakesRelativeSuffixKi())
                {
                    count++;
                }
            }

            Assert.AreEqual(16, count);
        }

        [Test]
        public void TestTakesRelativeSuffixKu()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.TakesRelativeSuffixKu())
                {
                    count++;
                }
            }

            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestLastIdropsDuringPassiveSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.LastIdropsDuringPassiveSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(11, count);
        }

        [Test]
        public void TestVowelAChangesToIDuringYSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.VowelAChangesToIDuringYSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(1300, count);
        }

        [Test]
        public void TestVowelEChangesToIDuringYSuffixation()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.VowelEChangesToIDuringYSuffixation())
                {
                    count++;
                }
            }

            Assert.AreEqual(2, count);
        }

        [Test]
        public void TestTakesSuffixIRAsAorist()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (!word.TakesSuffixIRAsAorist())
                {
                    count++;
                }
            }

            Assert.AreEqual(51, count);
        }

        [Test]
        public void TestTakesSuffixDIRAsFactitive()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (!word.TakesSuffixDIRAsFactitive())
                {
                    count++;
                }
            }

            Assert.AreEqual(197, count);
        }

        [Test]
        public void TestShowsSuRegularities()
        {
            var count = 0;
            for (var i = 0; i < dictionary.Size(); i++)
            {
                var word = (TxtWord) dictionary.GetWord(i);
                if (word.ShowsSuRegularities())
                {
                    count++;
                }
            }

            Assert.AreEqual(5, count);
        }
    }
}
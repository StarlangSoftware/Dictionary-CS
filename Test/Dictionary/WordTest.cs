using Dictionary.Dictionary;
using NUnit.Framework;

namespace Test.Dictionary
{
    public class WordTest
    {
        [Test]

        public void TestCharCount()
        {
            Word word = new Word("ali");
            Assert.AreEqual(3, word.CharCount());
            word = new Word("Veli");
            Assert.AreEqual(4, word.CharCount());
            word = new Word("ahmet");
            Assert.AreEqual(5, word.CharCount());
            word = new Word("çöğüşı");
            Assert.AreEqual(6, word.CharCount());
        }

        [Test]

        public void TestIsCapital()
        {
            Assert.False(Word.IsCapital("ali"));
            Assert.True(Word.IsCapital("Ali"));
            Assert.False(Word.IsCapital("ısı"));
            Assert.True(Word.IsCapital("Isıtıcı"));
            Assert.False(Word.IsCapital("çin"));
            Assert.True(Word.IsCapital("Çin"));
            Assert.False(Word.IsCapital("ödül"));
            Assert.True(Word.IsCapital("Ödül"));
            Assert.False(Word.IsCapital("şişe"));
            Assert.True(Word.IsCapital("Şişe"));
            Assert.False(Word.IsCapital("üretici"));
            Assert.True(Word.IsCapital("Üretici"));
        }

        [Test]

        public void TestIsPunctuation()
        {
            Assert.True(Word.IsPunctuation("."));
            Assert.True(Word.IsPunctuation("..."));
            Assert.True(Word.IsPunctuation("["));
            Assert.True(Word.IsPunctuation("]"));
            Assert.True(Word.IsPunctuation("\u2026"));
            Assert.True(Word.IsPunctuation("%"));
            Assert.True(Word.IsPunctuation("&"));
            Assert.True(Word.IsPunctuation("="));
            Assert.True(Word.IsPunctuation("\u0060\u0060"));
            Assert.True(Word.IsPunctuation("\u0060"));
            Assert.True(Word.IsPunctuation("''"));
            Assert.True(Word.IsPunctuation("$"));
            Assert.True(Word.IsPunctuation("!"));
            Assert.True(Word.IsPunctuation("?"));
            Assert.True(Word.IsPunctuation(","));
            Assert.True(Word.IsPunctuation(":"));
            Assert.True(Word.IsPunctuation("--"));
            Assert.True(Word.IsPunctuation(";"));
            Assert.True(Word.IsPunctuation("("));
            Assert.True(Word.IsPunctuation(")"));
            Assert.True(Word.IsPunctuation("'"));
            Assert.True(Word.IsPunctuation("\""));
            Assert.True(Word.IsPunctuation("\u201C"));
            Assert.True(Word.IsPunctuation("\u2018"));
            Assert.True(Word.IsPunctuation("\u201D"));
            Assert.True(Word.IsPunctuation("…"));
            Assert.True(Word.IsPunctuation("\u25CF"));
            Assert.True(Word.IsPunctuation("/"));
            Assert.True(Word.IsPunctuation("-"));
            Assert.True(Word.IsPunctuation("+"));
            Assert.True(Word.IsPunctuation("-LRB-"));
            Assert.True(Word.IsPunctuation("-RRB-"));
            Assert.True(Word.IsPunctuation("-LCB-"));
            Assert.True(Word.IsPunctuation("-RCB-"));
            Assert.True(Word.IsPunctuation("-LSB-"));
            Assert.True(Word.IsPunctuation("-RSB-"));
        }

        [Test]

        public void TestIsHonorific()
        {
            Assert.True(Word.IsHonorific("bay"));
            Assert.True(Word.IsHonorific("Bay"));
            Assert.True(Word.IsHonorific("BAY"));
            Assert.True(Word.IsHonorific("bayan"));
            Assert.True(Word.IsHonorific("Bayan"));
            Assert.True(Word.IsHonorific("BAYAN"));
        }

        [Test]

        public void TestIsOrganization()
        {
            Assert.True(Word.IsOrganization("corp"));
            Assert.True(Word.IsOrganization("Corp"));
            Assert.True(Word.IsOrganization("inc."));
            Assert.True(Word.IsOrganization("co."));
            Assert.True(Word.IsOrganization("Co."));
        }

        [Test]

        public void TestIsMoney()
        {
            Assert.True(Word.IsMoney("dolar"));
            Assert.True(Word.IsMoney("sterlin"));
            Assert.True(Word.IsMoney("paunt"));
            Assert.True(Word.IsMoney("ons"));
            Assert.True(Word.IsMoney("ruble"));
            Assert.True(Word.IsMoney("mark"));
            Assert.True(Word.IsMoney("frank"));
            Assert.True(Word.IsMoney("sent"));
            Assert.True(Word.IsMoney("cent"));
            Assert.True(Word.IsMoney("yen"));
            Assert.True(Word.IsMoney("Dolar"));
            Assert.True(Word.IsMoney("Sterlin"));
            Assert.True(Word.IsMoney("Paunt"));
            Assert.True(Word.IsMoney("Ons"));
            Assert.True(Word.IsMoney("Ruble"));
            Assert.True(Word.IsMoney("Mark"));
            Assert.True(Word.IsMoney("Frank"));
            Assert.True(Word.IsMoney("Sent"));
            Assert.True(Word.IsMoney("Cent"));
            Assert.True(Word.IsMoney("Yen"));
            Assert.True(Word.IsMoney("3000$"));
            Assert.False(Word.IsMoney("3000"));
        }

        [Test]

        public void TestIsTime()
        {
            Assert.True(Word.IsTime("9:1"));
            Assert.True(Word.IsTime("9:12"));
            Assert.True(Word.IsTime("12:1"));
            Assert.True(Word.IsTime("12:13"));
            Assert.True(Word.IsTime("1:9:1"));
            Assert.True(Word.IsTime("1:9:12"));
            Assert.True(Word.IsTime("1:12:1"));
            Assert.True(Word.IsTime("2:13:14"));
            Assert.True(Word.IsTime("12:9:1"));
            Assert.True(Word.IsTime("11:9:12"));
            Assert.True(Word.IsTime("10:12:1"));
            Assert.True(Word.IsTime("21:13:14"));
            Assert.False(Word.IsTime("12"));
            Assert.True(Word.IsTime("ocak"));
            Assert.True(Word.IsTime("şubat"));
            Assert.True(Word.IsTime("mart"));
            Assert.True(Word.IsTime("nisan"));
            Assert.True(Word.IsTime("mayıs"));
            Assert.True(Word.IsTime("haziran"));
            Assert.True(Word.IsTime("temmuz"));
            Assert.True(Word.IsTime("ağustos"));
            Assert.True(Word.IsTime("eylül"));
            Assert.True(Word.IsTime("ekim"));
            Assert.True(Word.IsTime("kasım"));
            Assert.True(Word.IsTime("aralık"));
            Assert.True(Word.IsTime("Ocak"));
            Assert.True(Word.IsTime("Şubat"));
            Assert.True(Word.IsTime("Mart"));
            Assert.True(Word.IsTime("Nisan"));
            Assert.True(Word.IsTime("Mayıs"));
            Assert.True(Word.IsTime("Haziran"));
            Assert.True(Word.IsTime("Temmuz"));
            Assert.True(Word.IsTime("Ağustos"));
            Assert.True(Word.IsTime("Eylül"));
            Assert.True(Word.IsTime("Ekim"));
            Assert.True(Word.IsTime("Kasım"));
            Assert.True(Word.IsTime("Aralık"));
            Assert.True(Word.IsTime("pazartesi"));
            Assert.True(Word.IsTime("salı"));
            Assert.True(Word.IsTime("çarşamba"));
            Assert.True(Word.IsTime("perşembe"));
            Assert.True(Word.IsTime("cuma"));
            Assert.True(Word.IsTime("cumartesi"));
            Assert.True(Word.IsTime("pazar"));
            Assert.True(Word.IsTime("Pazartesi"));
            Assert.True(Word.IsTime("Salı"));
            Assert.True(Word.IsTime("Çarşamba"));
            Assert.True(Word.IsTime("Perşembe"));
            Assert.True(Word.IsTime("Cuma"));
            Assert.True(Word.IsTime("Cumartesi"));
            Assert.True(Word.IsTime("Pazar"));
            Assert.False(Word.IsTime("1234567"));
            Assert.False(Word.IsTime("-1234"));
            Assert.False(Word.IsTime("1834"));
            Assert.False(Word.IsTime("2201"));
            Assert.True(Word.IsTime("1934"));
            Assert.False(Word.IsTime("devasa"));
        }
    }
}
using System;
using System.Collections.Generic;

namespace Dictionary.Dictionary
{
    public class TxtWord : Word, ICloneable
    {
        private List<string> flags;
        private string morphology;

        /**
         * <summary>A constructor of {@link TxtWord} class which takes a String name as an input and calls its super class {@link Word}
         * with given name. Then, creates a new {@link ArrayList} as flags.</summary>
         *
         * <param name="name">String name.</param>
         */
        public TxtWord(string name) : base(name)
        {
            flags = new List<string>();
        }

        /**
         * <summary>Another constructor of {@link TxtWord} class which takes a String name and a flag as inputs and calls its super class {@link Word}
         * with given name. Then, creates a new {@link ArrayList} as flags and calls addFlag method with given flag.</summary>
         *
         * <param name="name">String input.</param>
         * <param name="flag">String input.</param>
         */
        public TxtWord(string name, string flag) : base(name)
        {
            flags = new List<string>();
            AddFlag(flag);
        }

        /**
         * <summary>The clone method creates {@link TxtWord} type copy with name and add items of flags {@link ArrayList}  to the copy.</summary>
         *
         * <returns>TxtWord type copy.</returns>
         */
        public new TxtWord Clone()
        {
            var copy = new TxtWord(name);
            foreach (var t in flags)
            {
                copy.AddFlag(t);
            }

            return copy;
        }

        /**
         * <summary>The addFlag method takes a String flag as an input and adds given flag to the flags {@link ArrayList}.</summary>
         *
         * <param name="flag">String input to add.</param>
         */
        public void AddFlag(string flag)
        {
            flags.Add(flag);
        }

        /**
         * <summary>The removeFlag method takes a String flag as an input and removes given flag from the flags {@link ArrayList}.</summary>
         *
         * <param name="flag">String input to remove.</param>
         */
        public void RemoveFlag(string flag)
        {
            flags.Remove(flag);
        }

        public void SetMorphology(string morphology){
            this.morphology = morphology;
        }

        public string GetMorphology(){
            return morphology;
        }

        /**
         * <summary>The verbType method checks flags {@link ArrayList} and returns the corresponding cases.</summary>
         *
         * <returns>the corresponding cases.</returns>
         */
        public string VerbType()
        {
            if (flags.Contains("F1P1-NO-REF"))
            {
                /*
                 There is no example in the Turkish dictionary.
                 */
                return "F1P1-NO-REF";
            }

            if (flags.Contains("F2P1-NO-REF"))
            {
                /*
                 F2P1-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 can take CausativeT suffix. e.g. Doğ, göç, için
                 */
                return "F2P1-NO-REF";
            }

            if (flags.Contains("F3P1-NO-REF"))
            {
                /*
                 *F3P1-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take Passive Hl suffix,
                 *can take CausativeT suffix. e.g. Ak
                 */
                return "F3P1-NO-REF";
            }

            if (flags.Contains("F4P1-NO-REF"))
            {
                /*
                 *F4P1-NO-REF: The bare-form is a verb and depending on this attribute, the verb can't take PassiveHn suffix, can take CausativeT suffix.
                 *e.g. Aksa
                 */
                return "F4P1-NO-REF";
            }

            if (flags.Contains("F4PR-NO-REF"))
            {
                /*
                 *F4PR-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeT suffix. e.g. Çevir, göster
                 */
                return "F4PR-NO-REF";
            }

            if (flags.Contains("F4PL-NO-REF"))
            {
                /*
                 *F4PL-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix,
                 *can take CausativeT suffix. e.g. Azal, çoğal
                 */
                return "F4PL-NO-REF";
            }

            if (flags.Contains("F4PW-NO-REF"))
            {
                /*
                 *F4PW-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveN suffix,
                 *can take CausativeT suffix. e.g. Birle, boya
                 */
                return "F4PW-NO-REF";
            }

            if (flags.Contains("F5PL-NO-REF"))
            {
                /*
                 *F5PL-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix,
                 *can take CausativeDHr suffix. e.g. Çal, kal
                 */
                return "F5PL-NO-REF";
            }

            if (flags.Contains("F5PR-NO-REF"))
            {
                /*
                 *F5PR-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeDHr suffix. e.g. Birleş, çöz
                 */
                return "F5PR-NO-REF";
            }

            if (flags.Contains("F5PW-NO-REF"))
            {
                /*
                 *F5PW-NO-REF: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeDHr suffix. e.g. Ye
                 */
                return "F5PW-NO-REF";
            }

            if (flags.Contains("F1P1"))
            {
                /*
                 *F1P1: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeAr suffix, can take ReciprocalHs suffix. e.g. Çık, kop
                 */
                return "F1P1";
            }

            if (flags.Contains("F2P1"))
            {
                /*
                 *F2P1: The bare-form is a verb and depending on this attribute, the verb can can not PassiveHn suffix, can take CausativeHr suffix,
                 *can take CausativeDHr suffix, can take ReciprocalHs suffix. e.g. Bit, doy, düş
                 */
                return "F2P1";
            }

            if (flags.Contains("F2PL"))
            {
                /*
                 *F2PL: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take CausativeHr suffix,
                 *can take CausativeDHr suffix, can take ReciprocalHs suffix. e.g. Art, çök
                 */
                return "F2PL";
            }

            if (flags.Contains("F3P1"))
            {
                /*
                 *F3P1: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeHl suffix, can take ReciprocalHs suffix. e.g. Kok, sark
                 */
                return "F3P1";
            }

            if (flags.Contains("F4P1"))
            {
                /*
                 *F4P1: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix,
                 *can take CausativeT suffix, can take ReciprocalHs suffix. e.g. Anla
                 */
                return "F4P1";
            }

            if (flags.Contains("F4PR"))
            {
                /*
                 *F4PR: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeT suffix, can take ReciprocalHs suffix. e.g. Bitir, çağır
                 */
                return "F4PR";
            }

            if (flags.Contains("F4PL"))
            {
                /*
                 *F4PL: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveN suffix,
                 *can take CausativeT suffix, can take ReciprocalHs suffix. e.g. Bolal, çömel
                 */
                return "F4PL";
            }

            if (flags.Contains("F4PW"))
            {
                /*
                 *F4PW: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveN suffix,
                 *can take CausativeT suffix, can take ReciprocalHs suffix. e.g. Boyla, çağla
                 */
                return "F4PW";
            }

            if (flags.Contains("F5P1"))
            {
                /*
                 *F5P1: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeDHr suffix, can take ReciprocalHs suffix, can take ReflexiveHn suffix. e.g. Giy
                 */
                return "F5P1";
            }

            if (flags.Contains("F5PL"))
            {
                /*
                 *F5PL: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveHl suffix,
                 *can take CausativeDHr suffix, can take ReciprocalHs suffix. e.g. Böl, dal
                 */
                return "F5PL";
            }

            if (flags.Contains("F5PR"))
            {
                /*
                 *F5PR: The bare-form is a verb and depending on this attribute, the verb can take NominalVerb suffixes "-sHm, -SHn, -yHz, SHnHz, -lAr",
                 *can take NominalVerb1 suffixes, "-yDH, -ysA
                 ", can take NominalVerb2 suffix, "-ymHs", can take AdjectiveRoot suffix, "-SH",
                 *can take Adjective suffix, "-ŞAr" e.g. Bilin, çalış
                 */
                return "F5PR";
            }

            if (flags.Contains("F5PW"))
            {
                /*
                 *F5PW: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix,
                 *can take CausativeDHr suffix, can take ReciprocalHs suffix. e.g. Boşver, cezbet
                 */
                return "F5PW";
            }

            if (flags.Contains("F6P1"))
            {
                /*
                 *F6P1: The bare-form is a verb and depending on this attribute, the verb can not take PassiveHn suffix, can take PassiveN suffix,
                 *can take ReciprocalHs suffix, can take ReflexiveHn suffix. e.g. Gizle, hazırla, kaşı
                 */
                return "F6P1";
            }

            return "";
        }

        /**
         * <summary>The samePos method takes {@link TxtWord} as input and returns true if;
         * flags {@link ArrayList} contains CL_ISIM
         * CL_ISIM: The bare-form of the word is a noun. e.g. Abla
         * flags {@link ArrayList} contains CL_FIIL
         * CL_FIIL: The bare-form of the word is a verb. e.g. Affet
         * flags {@link ArrayList} contains IS_ADJ
         * IS_ADJ: The bare-form of the word is a adjective. e.g. Acayip
         * flags {@link ArrayList} contains IS_ZM
         * IS_ZM: The bare-form of the word is a pronoun. e.g. Başkası
         * flags {@link ArrayList} contains IS_ADVERB
         * IS_ADVERB: The bare-form of the word is a adverb. e.g. Tekrar, açıktan, adeta</summary>
         *
         * <param name="word">{@link TxtWord} type input.</param>
         * <returns>true if given word is nominal, verb, adjective, pronoun or adverb, false otherwise.</returns>
         */
        public bool SamePos(TxtWord word)
        {
            if (IsNominal() && word.IsNominal())
            {
                return true;
            }

            if (IsVerb() && word.IsVerb())
            {
                return true;
            }

            if (IsAdjective() && word.IsAdjective())
            {
                return true;
            }

            if (IsPronoun() && word.IsPronoun())
            {
                return true;
            }

            if (IsAdverb() && word.IsAdverb())
            {
                return true;
            }

            return false;
        }

        /**
         * <summary>The isNominal method returns true if flags {@link ArrayList} contains CL_ISIM.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains CL_ISIM.</returns>
         */
        public bool IsNominal()
        {
            return flags.Contains("CL_ISIM");
        }

        /**
         * <summary>The isPassive method returns true if flags {@link ArrayList} contains PASSIVE-HN.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains PASSIVE-HN.</returns>
         */
        public bool IsPassive()
        {
            return flags.Contains("PASSIVE-HN");
        }

        /**
         * <summary>The isAbbreviation method returns true if flags {@link ArrayList} contains IS_KIS.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_KIS.</returns>
         */
        public bool IsAbbreviation()
        {
            /*
             IS_KIS: The bare-form of the word is an abbrevation which does not obey
             vowel harmony while taking suffixes. Örn. Ab
             */
            return flags.Contains("IS_KIS");
        }

        /**
         * <summary>The isInterjection method returns true if flags {@link ArrayList} contains IS_INTERJ.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_INTERJ.</returns>
         */
        public bool IsInterjection()
        {
            /*
             *IS_INTERJ: An interjection is a part of speech that shows the emotion or feeling. e.g. Ah, aferin
             */
            return flags.Contains("IS_INTERJ");
        }

        /**
         * <summary>The isDuplicate method returns true if flags {@link ArrayList} contains IS_DUP.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_DUP.</returns>
         */
        public bool IsDuplicate()
        {
            /*
             *IS_DUP: The bare-form is part of a duplicate form. e.g. Abuk
             */
            return flags.Contains("IS_DUP");
        }

        /**
         * <summary>The isHeader method returns true if flags {@link ArrayList} contains IS_HEADER.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_HEADER.</returns>
         */
        public bool IsHeader()
        {
            return flags.Contains("IS_HEADER");
        }

        /**
         * <summary>The isAdjective method returns true if flags {@link ArrayList} contains IS_ADJ.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ADJ.</returns>
         */
        public bool IsAdjective()
        {
            return flags.Contains("IS_ADJ");
        }

        /**
         * <summary>The isPureAdjective method returns true if flags {@link ArrayList} contains IS_PUREADJ.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_PUREADJ.</returns>
         */
        public bool IsPureAdjective()
        {
            return flags.Contains("IS_PUREADJ");
        }

        /**
         * <summary>The isPronoun method returns true if flags {@link ArrayList} contains IS_ZM.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ZM.</returns>
         */
        public bool IsPronoun()
        {
            /*
             *IS_ZM: The bare-form of the word is a pronoun. e.g. Hangi, hep, hiçbiri
             */
            return flags.Contains("IS_ZM");
        }

        /**
         * <summary>The isQuestion method returns true if flags {@link ArrayList} contains IS_QUES.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_QUES.</returns>
         */
        public bool IsQuestion()
        {
            /*The bare-form of the word is a question. e.g. Mi, mu, mü
             */
            return flags.Contains("IS_QUES");
        }

        /**
         * <summary>The isVerb method returns true if flags {@link ArrayList} contains CL_FIIL.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains CL_FIIL.</returns>
         */
        public bool IsVerb()
        {
            return flags.Contains("CL_FIIL");
        }

        /**
         * <summary>The isPortmanteau method returns true if flags {@link ArrayList} contains IS_BILEŞ.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_BILEŞ.</returns>
         */
        public bool IsPortmanteau()
        {
            /*
             *IS_BILEŞ: The bare-form is a portmanteau word in affixed form. e.g. gelinçiçeği
             */
            return flags.Contains("IS_BILEŞ");
        }

        /**
         * <summary>The isDeterminer method returns true if flags {@link ArrayList} contains IS_DET.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_DET.</returns>
         */
        public bool IsDeterminer()
        {
            /*
             *IS_DET: The bare-form of the word is a determiner. e.g. Bazı, bir
             */
            return flags.Contains("IS_DET");
        }

        /**
         * <summary>The isConjunction method returns true if flags {@link ArrayList} contains IS_CONJ.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_CONJ.</returns>
         */
        public bool IsConjunction()
        {
            /*
             *IS_CONJ: The bare-form of the word is a conjunction. e.g. Gerek, halbuki
             */
            return flags.Contains("IS_CONJ");
        }

        /**
         * <summary>The isAdverb method returns true if flags {@link ArrayList} contains IS_ADVERB.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ADVERB.</returns>
         */
        public bool IsAdverb()
        {
            return flags.Contains("IS_ADVERB");
        }

        /**
         * <summary>The isPostP method returns true if flags {@link ArrayList} contains IS_POSTP.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_POSTP.</returns>
         */
        public bool IsPostP()
        {
            /*
             *The bare-form of the word is a postposition. e.g. Önce, takdirde, üzere
             */
            return flags.Contains("IS_POSTP");
        }

        /**
         * <summary>The isPortmanteauEndingWithSI method returns true if flags {@link ArrayList} contains IS_B_SI.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_B_SI.</returns>
         */
        public bool IsPortmanteauEndingWithSI()
        {
            /*
             *IS_B_SI: The bare-form is a portmanteau word ending with "sı". e.g. Giritlalesi
             */
            return flags.Contains("IS_B_SI");
        }

        /**
         * <summary>The isPortmanteauFacedVowelEllipsis method returns true if flags {@link ArrayList} contains IS_B_UD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_B_UD.</returns>
         */
        public bool IsPortmanteauFacedVowelEllipsis()
        {
            /*
             *IS_B_UD: The bare-form of the word includes vowel epenthesis,
             *therefore the last inserted vowel drops during suffixation. e.g. İnsanoğlu
             */
            return flags.Contains("IS_B_UD");
        }

        /**
         * <summary>The isPortmanteauFacedSoftening method returns true if flags {@link ArrayList} contains IS_B_UD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_B_SD.</returns>
         */
        public bool IsPortmanteauFacedSoftening()
        {
            /*
             *IS_B_SD: The bare-form of the word includes softening. e.g. Çançiçeği
             */
            return flags.Contains("IS_B_SD");
        }

        /**
         * <summary>The isSuffix method returns true if flags {@link ArrayList} contains EK.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains EK.</returns>
         */
        public bool IsSuffix()
        {
            /*
             * EK: This tag indicates complementary verbs. e.g. İdi, iken, imiş.
             */
            return flags.Contains("EK");
        }

        /**
         * <summary>The isProperNoun method returns true if flags {@link ArrayList} contains IS_OA.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_OA.</returns>
         */
        public bool IsProperNoun()
        {
            /*
             *IS_OA: The bare-form of the word is a proper noun. e.g. Abant, Beşiktaş
             */
            return flags.Contains("IS_OA");
        }

        /**
         * <summary>The isPlural method returns true if flags {@link ArrayList} contains IS_CA.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_CA.</returns>
         */
        public bool IsPlural()
        {
            /*
             *IS_CA: The bare-form of the word is already in a plural form,
             *therefore can not take plural suffixes such as "ler" or "lar". e.g. Buğdaygiller
             */
            return flags.Contains("IS_CA");
        }

        /**
         * <summary>The isNumeral method returns true if flags {@link ArrayList} contains IS_SAYI.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SAYI.</returns>
         */
        public bool IsNumeral()
        {
            /*
             *IS_SAYI: The word is a number. e.g. Dört
             */
            return flags.Contains("IS_SAYI");
        }

        /**
         * <summary>The isReal method returns true if flags {@link ArrayList} contains IS_REELSAYI.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_REELSAYI.</returns>
         */
        public bool IsReal()
        {
            return flags.Contains("IS_REELSAYI");
        }

        /**
         * <summary>The isFraction method returns true if flags {@link ArrayList} contains IS_KESIR.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_KESIR.</returns>
         */
        public bool IsFraction()
        {
            return flags.Contains("IS_KESIR");
        }

        /**
         * <summary>The isTime method returns true if flags {@link ArrayList} contains IS_ZAMAN.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ZAMAN.</returns>
         */
        public bool IsTime()
        {
            return flags.Contains("IS_ZAMAN");
        }

        /**
         * <summary>The isDate method returns true if flags {@link ArrayList} contains IS_DATE.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_DATE.</returns>
         */
        public bool IsDate()
        {
            return flags.Contains("IS_DATE");
        }

        /**
         * <summary>The isPercent method returns true if flags {@link ArrayList} contains IS_PERCENT.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_PERCENT.</returns>
         */
        public bool IsPercent()
        {
            return flags.Contains("IS_PERCENT");
        }

        /**
         * <summary>The isRange method returns true if flags {@link ArrayList} contains IS_RANGE.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_RANGE.</returns>
         */
        public bool IsRange()
        {
            return flags.Contains("IS_RANGE");
        }

        /**
         * <summary>The isOrdinal method returns true if flags {@link ArrayList} contains IS_ORD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ORD.</returns>
         */
        public bool IsOrdinal()
        {
            /*
             *IS_ORD: The bare-form of the word can take suffixes and these suffixes define a ranking. e.g. Birinci
             */
            return flags.Contains("IS_ORD");
        }

        /**
         * <summary>The notObeysVowelHarmonyDuringAgglutination method returns true if flags {@link ArrayList} contains IS_UU.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_UU.</returns>
         */
        public bool NotObeysVowelHarmonyDuringAgglutination()
        {
            /*
             *IS_UU: The bare-form does not obey vowel harmony while taking suffixes. e.g. Dikkat
             */
            return flags.Contains("IS_UU");
        }

        /**
         * <summary>The obeysAndNotObeysVowelHarmonyDuringAgglutination method returns true if flags {@link ArrayList} contain IS_UUU.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_UUU.</returns>
         */
        public bool ObeysAndNotObeysVowelHarmonyDuringAgglutination()
        {
            /*
             *IS_UUU: The bare-form does not obey vowel harmony while taking suffixes. e.g. Bol, kalp
             */
            return flags.Contains("IS_UUU");
        }

        /**
         * <summary>The rootSoftenDuringSuffixation method returns true if flags {@link ArrayList} contains IS_SD, F_SD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SD, F_SD.</returns>
         */
        public bool RootSoftenDuringSuffixation()
        {
            return flags.Contains("IS_SD") || flags.Contains("F_SD");
        }

        /**
         * <summary>The rootSoftenAndNotSoftenDuringSuffixation method returns true if flags {@link ArrayList} contains IS_SDD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SDD.</returns>
         */
        public bool RootSoftenAndNotSoftenDuringSuffixation()
        {
            /*
             *The bare-form final consonant can (or can not) get devoiced during vowel-initial suffixation. e.g. Kalp
             */
            return flags.Contains("IS_SDD");
        }

        /**
         * <summary>The verbSoftenDuringSuffixation method returns true if flags {@link ArrayList} contains F_SD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_SD.</returns>
         */
        public bool VerbSoftenDuringSuffixation()
        {
            /*
             * F_SD: The bare-form final consonant gets devoiced during vowel-initial suffixation. e.g. Cezbet
             */
            return flags.Contains("F_SD");
        }

        /**
         * <summary>The nounSoftenDuringSuffixation method returns true if flags {@link ArrayList} contains IS_SD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SD.</returns>
         */
        public bool NounSoftenDuringSuffixation()
        {
            /*
             *IS_SD: The bare-form final consonant already has an accusative suffix. e.g. Kabağı
             */
            return flags.Contains("IS_SD");
        }

        /**
         * <summary>The endingKChangesIntoG method returns true if flags {@link ArrayList} contains IS_KG.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_KG.</returns>
         */
        public bool EndingKChangesIntoG()
        {
            /*
             *IS_KG: The bare-form includes vowel epenthesis, therefore the last inserted vowel drope
             *during suffixation. e.g. Çelenk
             */
            return flags.Contains("IS_KG");
        }

        /**
         * <summary>The isExceptional method returns true if flags {@link ArrayList} contains IS_EX.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_EX.</returns>
         */
        public bool IsExceptional()
        {
            /*
             *IS_EX: This tag defines exception words. e.g. Delikanlı
             */
            return flags.Contains("IS_EX");
        }

        /**
         * <summary>The duplicatesDuringSuffixation method returns true if flags {@link ArrayList} contains IS_ST.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_ST.</returns>
         */
        public bool DuplicatesDuringSuffixation()
        {
            /*
             *IS_ST: The second consonant of the bare-form undergoes a resyllabification. e.g. His
             */
            return flags.Contains("IS_ST");
        }

        /**
         * <summary>The duplicatesAndNotDuplicatesDuringSuffixation method returns true if flags {@link ArrayList} contains IS_STT.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_STT.</returns>
         */
        public bool DuplicatesAndNotDuplicatesDuringSuffixation()
        {
            /*
             *IS_STT: The second consonant of the bare-form undergoes a resyllabification. e.g. His
             */
            return flags.Contains("IS_STT");
        }

        /**
         * <summary>The lastIdropsDuringSuffixation method returns true if flags {@link ArrayList} contains IS_UD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_UD.</returns>
         */
        public bool LastIdropsDuringSuffixation()
        {
            /*
             *IS_UD: The bare-form includes vowel epenthesis, therefore the last inserted vowel drops during suffixation.
             *e.g. Boyun
             */
            return flags.Contains("IS_UD");
        }

        /**
         * <summary>The lastIDropsAndNotDropDuringSuffixation method returns true if flags {@link ArrayList} contains IS_UDD</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_UDD.</returns>
         */
        public bool LastIDropsAndNotDropDuringSuffixation()
        {
            /*
             *The bare-form includes vowel epenthesis, therefore the last inserted vowel can (or can not) drop during suffixation. e.g. Kadir
             */
            return flags.Contains("IS_UDD");
        }

        /**
         * <summary>The takesRelativeSuffixKi method returns true if flags {@link ArrayList} contains IS_KI.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_KI.</returns>
         */
        public bool TakesRelativeSuffixKi()
        {
            /*
             *IS_KI: The word can take a suffix such as "ki". e.g. Önce
             */
            return flags.Contains("IS_KI");
        }

        /**
         * <summary>The takesRelativeSuffixKu method returns true if flags {@link ArrayList} contains IS_KU.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_KU.</returns>
         */
        public bool TakesRelativeSuffixKu()
        {
            /*
             *IS_KU: The word can take a suffix such as "kü". e.g. Bugün
             */
            return flags.Contains("IS_KU");
        }

        /**
         * <summary>The consonantSMayInsertedDuringPossesiveSuffixation method returns true if flags {@link ArrayList} contains IS_SII.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SII.</returns>
         */
        public bool ConsonantSMayInsertedDuringPossesiveSuffixation()
        {
            return flags.Contains("IS_SII");
        }

        /**
         * <summary>The lastIdropsDuringPassiveSuffixation method returns true if flags {@link ArrayList} contains F_UD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_UD.</returns>
         */
        public bool LastIdropsDuringPassiveSuffixation()
        {
            /*
             *F_UD: The bare-form includes vowel epenthesis, therefore the last "ı"
             *drops during passive suffixation. e.g. Çağır
             */
            return flags.Contains("F_UD");
        }

        /**
         * <summary>The vowelAChangesToIDuringYSuffixation method returns true if flags {@link ArrayList} contains F_GUD.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_GUD.</returns>
         */
        public bool VowelAChangesToIDuringYSuffixation()
        {
            /*
             *F_GUD: The verb bare-form includes vowel reduction, the last vowel "a" of the bare-form is replaced with "ı"
             *e.g. Buzağıla
             */
            return flags.Contains("F_GUD");
        }

        /**
         * <summary>The vowelEChangesToIDuringYSuffixation method returns true if flags {@link ArrayList} contains F_GUDO.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_GUDO.</returns>
         */
        public bool VowelEChangesToIDuringYSuffixation()
        {
            /*
             *F_GUDO: The verb bare-form includes viwel reduction, the last vowel "e" of the
             *bare-form is replaced with "i". e.g. Ye
             */
            return flags.Contains("F_GUDO");
        }

        /**
         * <summary>The takesSuffixIRAsAorist method returns true if flags {@link ArrayList} contains F_GIR.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_GIR.</returns>
         */
        public bool TakesSuffixIRAsAorist()
        {
            /*
             *F_GIR: The bare-form of the word takes "ir" suffix. e.g. Geç
             */
            return !flags.Contains("F_GIR");
        }

        /**
         * <summary>The takesSuffixDIRAsFactitive method returns true if flags {@link ArrayList} contains F_DIR.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains F_DIR.</returns>
         */
        public bool TakesSuffixDIRAsFactitive()
        {
            /*
             *F_DIR: The bare-form of the word takes "tır" suffix. e.g. Daral
             */
            return !flags.Contains("F_DIR");
        }

        /**
         * <summary>The showsSuRegularities method returns true if flags {@link ArrayList} contains IS_SU.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains IS_SU.</returns>
         */
        public bool ShowsSuRegularities()
        {
            return flags.Contains("IS_SU");
        }

        /**
         * <summary>The containsFlag method returns true if flags {@link ArrayList} contains flag.</summary>
         *
         * <returns>true if flags {@link ArrayList} contains flag.</returns>
         */
        public bool ContainsFlag(String flag)
        {
            return flags.Contains(flag);
        }

        public new string ToString()
        {
            var result = base.ToString();
            foreach (var flag in flags)
            {
                result += " " + flag;
            }

            return result;
        }
    }
}
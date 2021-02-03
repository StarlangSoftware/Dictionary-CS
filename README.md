For Developers
============

You can also see [Java](https://github.com/starlangsoftware/Dictionary), [Python](https://github.com/starlangsoftware/Dictionary-Py), [Swift](https://github.com/starlangsoftware/Dictionary-Swift), or [C++](https://github.com/starlangsoftware/Dictionary-CPP) repository.

Detailed Description
============

+ [TxtDictionary](#txtdictionary)
+ [TxtWord](#txtword)
+ [SyllableList](#syllablelist)

## TxtDictionary

Dictionary is used in order to load Turkish dictionary or a domain specific dictionary. In addition, misspelled words and the true forms of the misspelled words can also be loaded.

To load the Turkish dictionary and the misspelled words dictionary,

	a = TxtDictionary()
	
To load the domain specific dictionary and the misspelled words dictionary,

	TxtDictionary(String fileName, WordComparator comparator, String misspelledFileName)

And to see if the dictionary involves a specific word, getWord is used.

	Word getWord(String name)

## TxtWord

The word features: To see whether the TxtWord class of the dictionary is a noun or not,


	boolean isNominal()

To see whether it is an adjective,

	boolean isAdjective()

To see whether it is a portmanteau word,

	boolean isPortmanteau()

To see whether it obeys vowel harmony,

	notObeysVowelHarmonyDuringAgglutination

And, to see whether it softens when it get affixes, the following is used.

	boolean rootSoftenDuringSuffixation()

## SyllableList

To syllabify the word, SyllableList class is used.

	SyllableList(String word)

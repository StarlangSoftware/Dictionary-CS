# Dictionary-CS

This resource is a dictionary of Modern Turkish, comprised of the definitions of over 50.000 individual entries. Each entry is matched with its corresponding synset (set of synonymous words and expressions) in the Turkish WordNet, KeNet.

For Developers
============
You can also see [Java](https://github.com/olcaytaner/Dictionary), [Python](https://github.com/olcaytaner/Dictionary-Py), or [C++](https://github.com/olcaytaner/Dictionary-CPP) repository.

Detailed Description
============
+ [TxtDictionary](#txtdictionary)
+ [TxtWord](#txtword)
+ [SyllableList](#syllablelist)

## TxtDictionary

Bir alana özgü veya Türkçe sözlüğü yüklemek için kullanılır. Ayrıca yanlış yazılmış
kelimeler ve yanlış yazılmış kelimelerin doğru formları da yüklenebilir.

Türkçe sözlüğü ve yazım yanlışları sözlüğünü yüklemek için

	a = TxtDictionary()
	
Alana özgü sözlüğü ve yazım yanlışı sözlüğünü yüklemek için

	TxtDictionary(String fileName, WordComparator comparator, String misspelledFileName)

Belirli bir sözcüğün sözlükte olup olmadığı,

	Word getWord(String name)

## TxtWord

Sözlükteki kelimelerin özellikleri TxtWord sınıfının, isim olup olmadıkları

	boolean isNominal()

sıfat olup olmadıkları,

	boolean isAdjective()

bileşik isim olup olmadıkları

	boolean isPortmanteau()

ünlü uyumuna uyup uymadıkları

	notObeysVowelHarmonyDuringAgglutination

ek aldıklarında yumuşayıp yumuşamadıkları

	boolean rootSoftenDuringSuffixation()

## SyllableList

Kelimeyi hecelerine ayırmak için de SyllableList sınıfı kullanılır.

	SyllableList(String word)

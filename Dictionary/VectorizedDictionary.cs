using System.Collections.Generic;
using Math;

namespace Dictionary.Dictionary
{
    public class VectorizedDictionary : Dictionary
    {
        /**
         * <summary>A constructor of {@link VectorizedDictionary} class which takes a {@link WordComparator} as an input and calls its
         * super class {@link Dictionary} with {@link WordComparator} input.</summary>
         *
         * <param name="comparator">{@link WordComparator} type input.</param>
         */
        public VectorizedDictionary(IComparer<Word> comparator) : base(comparator)
        {
        }

        /**
         * <summary>The addWord method takes a {@link VectorizedWord} as an input and adds it to the words {@link ArrayList}.</summary>
         *
         * <param name="word">{@link VectorizedWord} input.</param>
         */
        public void AddWord(VectorizedWord word)
        {
            words.Add(word);
        }

        /**
         * <summary>The mostSimilarWord method takes a String name as an input, declares a maxDistance as -MAX_VALUE and creates a
         * {@link VectorizedWord} word by getting the given name from words {@link ArrayList}. Then, it loops through the
         * words {@link ArrayList} and if the current word is not equal to given input it calculates the distance between current
         * word and given word by using dot product and updates the maximum distance. It then returns the result {@link VectorizedWord}
         * which holds the most similar word to the given word.</summary>
         *
         * <param name="name">String input.</param>
         * <returns>VectorizedWord type result which holds the most similar word to the given word.</returns>
         */
        public VectorizedWord MostSimilarWord(string name)
        {
            var maxDistance = double.MinValue;
            VectorizedWord result = null;
            var word = (VectorizedWord) GetWord(name);
            if (word == null)
            {
                return null;
            }

            foreach (var currentWord in words)
            {
                var current = (VectorizedWord) currentWord;
                if (!current.Equals(word))
                {
                    var distance = word.GetVector().DotProduct(current.GetVector());

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        result = current;
                    }
                }
            }

            return result;
        }

        /**
         * <summary>The kMeansClustering method takes an integer iteration and k as inputs. K-means clustering aims to partition n observations
         * into k clusters in which each observation belongs to the cluster with the nearest mean.</summary>
         *
         * <param name="iteration">Integer input.</param>
         * <param name="k">        Integer input.</param>
         * <returns>ArrayList result which holds the k-means clustered words.</returns>
         */
        public List<Word>[] KMeansClustering(int iteration, int k)
        {
            var result = new List<Word>[k];
            var means = new Vector[k];
            var vectorSize = ((VectorizedWord) words[0]).GetVector().Size();
            for (var i = 0; i < k; i++)
            {
                result[i] = new List<Word>();
                means[i] = new Vector(vectorSize, 0);
            }

            for (var i = 0; i < words.Count; i++)
            {
                result[i % k].Add(words[i]);
                means[i % k].Add(((VectorizedWord) words[i]).GetVector());
            }

            for (var i = 0; i < k; i++)
            {
                means[i].Divide(result[i].Count);
                means[i].Divide(System.Math.Sqrt(means[i].DotProduct()));
            }

            for (var i = 0; i < iteration; i++)
            {
                for (var j = 0; j < k; j++)
                {
                    result[j].Clear();
                }

                foreach (var word in words)
                {
                    var vectorizedWord = (VectorizedWord) word;
                    var maxClusterDistance = means[0].DotProduct(vectorizedWord.GetVector());

                    var maxClusterIndex = 0;
                    for (var j = 1; j < k; j++)
                    {
                        var clusterDistance = means[j].DotProduct(vectorizedWord.GetVector());

                        if (clusterDistance > maxClusterDistance)
                        {
                            maxClusterDistance = clusterDistance;
                            maxClusterIndex = j;
                        }
                    }

                    result[maxClusterIndex].Add(word);
                }

                for (var j = 0; j < k; j++)
                {
                    means[j].Clear();
                    foreach (var word in result[j])
                    {
                        means[j].Add(((VectorizedWord) word).GetVector());
                    }

                    means[j].Divide(result[j].Count);
                    means[j].Divide(System.Math.Sqrt(means[j].DotProduct()));
                }
            }

            return result;
        }
    }
}
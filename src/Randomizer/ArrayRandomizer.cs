using System;

namespace hk.Randomizer
{
    public sealed class ArrayRandomizer
    {
        //Should include a seed
        private static readonly Random Rand = new Random();

        public static int[] GetRandomizedArray(int start, int size)
        {
            var returnVal = new int[size];
            for (var i = 0; i < returnVal.Length; i++)
            {
                returnVal[i] = i + start;
            }

            ShuffleArray(ref returnVal);

            return returnVal;
        }

        /// <summary>
        ///     Shuffle an existing array of any type according to Knuth shuffle algorithm
        /// </summary>
        /// <param name="array"></param>
        public static void ShuffleArray<T>(ref T[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                var r = Rand.Next(0, i + 1);

                var tmp = array[i];
                array[i] = array[r];
                array[r] = tmp;
            }
        }
    }
}
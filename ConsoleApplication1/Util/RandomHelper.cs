using System;
using System.Globalization;

namespace PoemMaster.Util
{
    /// <summary>
    /// Static random class provide nearly random in this programe. Could be improved as Jon Skeet said in his blog using thread.
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// Should only be initialised once and called multiple times.
        /// </summary>
        public static Random irandom = new Random();

        /// <summary>
        /// Generate a random numebr less than upperbound
        /// </summary>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int upperBound)
        {
            int index = irandom.Next(maxValue: upperBound);

            return index;
        }
    }
}

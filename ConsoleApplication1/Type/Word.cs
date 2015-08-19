using System;

namespace ParseMaster
{
    /// <summary>
    /// Discribe a word in string
    /// </summary>
    public class Word
    {
        public string Value { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content"></param>
        public Word(string content)
        {
            Value = content;
        }

        /// <summary>
        /// Display word
        /// </summary>
        public void Display()
        {
            Console.Write("{0} ", Value);
        }
    }
}
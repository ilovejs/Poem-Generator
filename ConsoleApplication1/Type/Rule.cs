using System;
using System.Collections.Generic;
using ParseMaster;
using PoemMaster.Type;
using PoemMaster.Util;

namespace PoemMaster
{
    /// <summary>
    /// Class map to line record in the input txt file
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Name of rule
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Word candidate
        /// </summary>
        public List<Word> Words { get; set; }
        
        /// <summary>
        /// Reference to other rules
        /// </summary>
        public List<string> Reference { get; set; }

        /// <summary>
        /// Keyword has only 2 case $LINEBREAK, $END
        /// </summary>
        public Keyword Keyword { get; set; }

        /// <summary>
        /// Reference to global map
        /// </summary>
        public Dictionary<string, Rule> MapCopy { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Rule()
        {
            this.Words = new List<Word>();
            this.Keyword = new Keyword();
            this.Reference = new List<string>();
        }

        public Rule(string name)
        {
            this.Definition = name;
        }

        /// <summary>
        /// Copy the reference of global complete map into each rule in local
        /// </summary>
        /// <param name="map"></param>
        public void CopyFinishedMap(Dictionary<string, Rule> map)
        {
            this.MapCopy = map;
        }

        /// <summary>
        /// Recursive calling to display a rule and its sub-component.
        /// </summary>
        public void Display()
        {
            int index;

            if (Words.Count > 0)
            {
                index = RandomHelper.GetRandomNumber(Words.Count);

                // Random word display
                Words[index].Display();
            }

            if (Reference.Count > 0)
            {
                // Random keyword or reference to other rule.
                // Assume normal form <> will be selected randomly.
                // $END prefix with '|', so if it appears, display by probability.
                var isKeywordEnd = this.Keyword.Name != null && this.Keyword.Name.Equals("$END");

                var totalNumber = Reference.Count + (isKeywordEnd ? 1 : 0);
                
                index = RandomHelper.GetRandomNumber(totalNumber);

                // keyword = $END don't need to print anything. 
                if ((index != totalNumber -1) || (isKeywordEnd == false))
                {
                    Rule tempRule;
                    this.MapCopy.TryGetValue(Reference[index], out tempRule);

                    if (tempRule != null)
                        tempRule.Display();

                    // after all, use line break
                    //line break won't be selected randomly. 
                    if (this.Keyword.Name == "$LINEBREAK")                   
                        Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Add keyword into rule
        /// </summary>
        /// <param name="s">string value of keyword</param>
        public void AddKeyword(string s)
        {
            this.Keyword = new Keyword(s);
        }

        /// <summary>
        /// Add word into candidate list.
        /// </summary>
        /// <param name="s">string value of word</param>
        public void AddWord(string s)
        {
            this.Words.Add(new Word(s));
        }

        /// <summary>
        /// Add references to rule
        /// </summary>
        /// <param name="s">name of a rule</param>
        public void AddRefRule(string s)
        {
            this.Reference.Add(s);
        }
    }
}
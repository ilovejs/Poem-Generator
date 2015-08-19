using System.Collections.Generic;
using System.Text.RegularExpressions;
using PoemMaster;

namespace ParseMaster
{
    /// <summary>
    /// Regex parser to generate a semantic map
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Input format is: VERB: runs|walk <PREPOSITION>|<PRONOUN>|$END
        /// So, map 'name of rule' to list of candidate words and other references.
        /// </summary>
        public Dictionary<string, Rule> Map { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            this.Map = new Dictionary<string, Rule>();
        }
        
        /// <summary>
        /// Parse rules with given string format of line
        /// </summary>
        /// <param name="line">String format of line</param>
        public void ParseLine(string line) 
        {
            // Split before ':' and after
            var parts = line.Split(':');
            var definition = parts[0];
            var rest = parts[1].Trim();

            var rule = new Rule { Definition = definition };

            // Parse word e.g. transcends
            var regex = new Regex("([a-z]+)\\|*");
            foreach (var w in regex.Matches(rest)) 
               rule.AddWord(w.ToString().Replace("|", ""));


            // Parse reference e.g. <PREPOSITION>
            regex = new Regex("<(?<rule>[A-Z]+)>");
            foreach (var reference in regex.Matches(rest))
            {
                var refName = reference.ToString();
                
                // remove first and last char
                refName = refName.Substring(1, refName.Length - 2);
                
                rule.AddRefRule(refName);
            }
            

            // Parse keyword e.g. $END
            regex = new Regex("\\$[A-Z]+");
            foreach (var k in regex.Matches(rest))
                rule.AddKeyword(k.ToString());

            // Add to map
            this.Map.Add(definition, rule);
        }

        /// <summary>
        /// Inside each rule, it holds a reference to global sematic map.
        /// Reason is earlieer rule will bind to undefinded rule, which later has been defined. 
        /// So, after parsing all lines, this funciton should be called.
        /// </summary>
        public void AssignFinalMapToRule()
        {
            foreach (var k in this.Map.Keys)
            {
                Rule tempR;
                this.Map.TryGetValue(k, out tempR);

                if (tempR != null)
                {
                    tempR.CopyFinishedMap(this.Map);
                }
            }
        }
    }
}

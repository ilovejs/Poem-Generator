using System.Collections.Generic;
using PoemMaster;

namespace ParseMaster
{
    /// <summary>
    /// Generate Poem according to the rules and semantics parsed into the map.
    /// </summary>
    public class Generator
    {
        Dictionary<string, Rule> Map { get; set; }

        /// <summary>
        /// Constructor bring reference from outside.
        /// </summary>
        /// <param name="map"></param>
        public Generator(Dictionary<string, Rule> map)
        {
            this.Map = map;
        }

        /// <summary>
        /// Display Poem in console
        /// </summary>
        public void DisplayPoem()
        {
            // Use "Poem" as start command
            Rule rule;
            Map.TryGetValue("POEM", out rule);

            // Poem contains LINES
            foreach (var ruleName in rule.Reference)
            {
                // find in map and display accordingly.
                Rule subRule;
                Map.TryGetValue(ruleName, out subRule);
                subRule.Display();
            }
        }
    }
}

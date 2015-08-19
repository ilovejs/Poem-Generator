using System;
using System.IO;
using ParseMaster;

namespace PoemMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    parser.ParseLine(line);
                }
            }

            // Inside each rule, it holds a reference to global sematic map.
            // Reason is earlieer rule will bind to undefinded rule, which later has been defined. 
            // So, after parsing all lines, this funciton should be called.
            parser.AssignFinalMapToRule();

            var generastringor = new Generator(parser.Map);

            generastringor.DisplayPoem();
            
            Console.ReadKey();
        }
    }
}

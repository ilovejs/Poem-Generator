namespace PoemMaster.Type
{
    /// <summary>
    /// Keyword class has chance to extend
    /// </summary>
    public class Keyword
    {
        /// <summary>
        /// Name of keyword
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Keyword()
        {
            
        }

        public Keyword(string name)
        {
            this.Name = name;
        }
    }
}
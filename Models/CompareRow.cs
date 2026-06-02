namespace TrixCompareDb.Models
{
    public class CompareRow
    {
        public System.Collections.Generic.Dictionary<string, object> Source { get; set; }
        public System.Collections.Generic.Dictionary<string, object> Target { get; set; }
        public string Status { get; set; }
    }
}

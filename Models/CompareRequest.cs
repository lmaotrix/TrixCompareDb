namespace TrixCompareDb.Models
{
    // Request to compare a table between two different connection strings/databases
    public class CompareRequest
    {
        public string DatabaseSource { get; set; }
        public string DatabaseTarget { get; set; }
        // the table name to compare in both databases
        public string TableName { get; set; }
    }
}

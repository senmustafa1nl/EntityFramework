namespace Pratik_Survivor_Dependency_Injection.Models.Competitor
{
    public class CompetitorDetails
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CategoryId { get; set; }
        public string FullName { get; set; }
    }
}

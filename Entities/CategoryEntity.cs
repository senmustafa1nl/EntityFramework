namespace Pratik_Survivor_Dependency_Injection.Entities
{
    public class CategoryEntity : BaseEntity

    {
      
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public List<CompetitorsEntity> Competitors { get; set; }
    }
    
}

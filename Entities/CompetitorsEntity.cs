using System.ComponentModel.DataAnnotations.Schema;

namespace Pratik_Survivor_Dependency_Injection.Entities
{
    public class CompetitorsEntity : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}

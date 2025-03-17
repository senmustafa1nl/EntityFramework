using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pratik_Survivor_Dependency_Injection.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedDate= DateTime.Now;
            ModifiedDate= DateTime.Now;
            IsDeleted = false;
        }
    }
}

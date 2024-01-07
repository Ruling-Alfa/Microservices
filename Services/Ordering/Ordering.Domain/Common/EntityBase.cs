using CrossCutting.Persistance.SQL.Entities;

namespace Ordering.Domain.Common
{
    public abstract record EntityBase : BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastmodifiedDate { get; set; }
    }
}

using System;

namespace ScDataTransfer.Data.Entities
{
    public class SharedField : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid FieldId { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual Item Item { get; set; }
    }
}

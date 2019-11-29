using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScDataTransfer.Data.Entities
{
    [Table("Descendants")]
    public class DescendantRow : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid Ancestor { get; set; }
        public Guid Descendant { get; set; }

        public virtual Item SelectedDescendantItem { get; set; }
    }
}

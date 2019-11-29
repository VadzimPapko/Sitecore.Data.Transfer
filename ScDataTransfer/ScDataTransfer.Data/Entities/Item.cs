using System;
using System.Collections.Generic;

namespace ScDataTransfer.Data.Entities
{
    public class Item : BaseEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid TemplateID { get; set; }
        public Guid MasterID { get; set; }
        public Guid ParentID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual List<VersionedField> VersionedFields { get; set; }
        public virtual List<UnversionedField> UnversionedFields { get; set; } 
        public virtual List<SharedField> SharedFields { get; set; }
        public virtual List<DescendantRow> DescTableRowsByDescendantId { get; set; }
    }
}

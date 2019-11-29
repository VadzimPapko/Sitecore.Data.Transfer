using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class ItemSerializer : EntitySerializerBase
    {
        public ItemSerializer(string fieldsTerminator, string rowsTerminator, string dtFormat) : base(fieldsTerminator, rowsTerminator, dtFormat)
        {
        }
        public override string Serialize(BaseEntity entity)
        {
            var item = entity as Item;
            return $"{item.ID}{fieldsTerminator}{item.Name}{fieldsTerminator}{item.TemplateID}{fieldsTerminator}{item.MasterID}{fieldsTerminator}{item.ParentID}{fieldsTerminator}{item.Created.ToString(dtFormat)}{fieldsTerminator}{item.Updated.ToString(dtFormat)}{rowsTerminator}";
        }
    }
}

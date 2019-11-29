using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class SharedFieldSerializer : EntitySerializerBase
    {
        public SharedFieldSerializer(string fieldsTerminator, string rowsTerminator, string dtFormat) : base(fieldsTerminator, rowsTerminator, dtFormat)
        {
        }
        public override string Serialize(BaseEntity entity)
        {
            var sf = entity as SharedField;
            return $"{sf.Id}{fieldsTerminator}{sf.ItemId}{fieldsTerminator}{sf.FieldId}{fieldsTerminator}{sf.Value}{fieldsTerminator}{sf.Created.ToString(dtFormat)}{fieldsTerminator}{sf.Updated.ToString(dtFormat)}{rowsTerminator}";
        }
    }
}

using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class UnversionedFieldSerializer : EntitySerializerBase
    {
        public UnversionedFieldSerializer(string fieldsTerminator, string rowsTerminator, string dtFormat) : base(fieldsTerminator, rowsTerminator, dtFormat)
        {
        }
        public override string Serialize(BaseEntity entity)
        {
            var uf = entity as UnversionedField;
            return $"{uf.Id}{fieldsTerminator}{uf.ItemId}{fieldsTerminator}{uf.Language}{fieldsTerminator}{uf.FieldId}{fieldsTerminator}{uf.Value}{fieldsTerminator}{uf.Created.ToString(dtFormat)}{fieldsTerminator}{uf.Updated.ToString(dtFormat)}{rowsTerminator}";
        }
    }
}

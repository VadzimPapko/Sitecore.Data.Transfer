using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class VersionedFieldSerializer : EntitySerializerBase
    {
        public VersionedFieldSerializer(string fieldsTerminator, string rowsTerminator, string dtFormat) : base(fieldsTerminator, rowsTerminator, dtFormat)
        {
        }
        public override string Serialize(BaseEntity entity)
        {
            var vf = entity as VersionedField;
            return $"{vf.Id}{fieldsTerminator}{vf.ItemId}{fieldsTerminator}{vf.Language}{fieldsTerminator}{vf.Version}{fieldsTerminator}{vf.FieldId}{fieldsTerminator}{vf.Value}{fieldsTerminator}{vf.Created.ToString(dtFormat)}{fieldsTerminator}{vf.Updated.ToString(dtFormat)}{rowsTerminator}";
        }
    }
}

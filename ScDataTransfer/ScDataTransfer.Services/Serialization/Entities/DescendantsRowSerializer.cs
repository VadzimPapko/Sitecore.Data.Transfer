using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class DescendantsRowSerializer : EntitySerializerBase
    {
        public DescendantsRowSerializer(string fieldsTerminator, string rowsTerminator, string dtFormat) : base(fieldsTerminator, rowsTerminator, dtFormat)
        {
        }

        public override string Serialize(BaseEntity entity)
        {
            var row = entity as DescendantRow;
            return $"{row.ID}{fieldsTerminator}{row.Ancestor}{fieldsTerminator}{row.Descendant}{rowsTerminator}";
        }
    }
}

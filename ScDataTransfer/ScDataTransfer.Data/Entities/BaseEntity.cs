using ScDataTransfer.Data.Interfaces;

namespace ScDataTransfer.Data.Entities
{
    public abstract class BaseEntity
    {
        public string Serialize(IEntitySerializer serializer)
        {
            return serializer.Serialize(this);
        }
    }
}

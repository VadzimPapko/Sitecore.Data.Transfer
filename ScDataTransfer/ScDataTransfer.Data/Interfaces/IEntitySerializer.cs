using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Data.Interfaces
{
    public interface IEntitySerializer
    {
        string Serialize(BaseEntity entity);
    }
}
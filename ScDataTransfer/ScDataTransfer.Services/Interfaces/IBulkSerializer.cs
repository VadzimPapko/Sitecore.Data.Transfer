using System.Collections.Generic;
using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Services.Interfaces
{
    public interface IBulkSerializer
    {
        string Serialize(SharedField sf);

        string Serialize(VersionedField vf);

        string Serialize(UnversionedField uf);

        string Serialize(Item item);

        string Serialize(DescendantRow row);

        void SerializeToDisk(List<Item> items);
    }
}
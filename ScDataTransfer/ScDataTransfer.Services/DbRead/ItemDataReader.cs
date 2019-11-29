using ScDataTransfer.Data.Interfaces;
using ScDataTransfer.Data.Repository;
using ScDataTransfer.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using ScDataTransfer.Utils.Options;
using ScDataTransfer.Utils.Logging;

namespace ScDataTransfer.Services.DbRead
{
    public class ItemDataReader
    {
        private IBulkSerializer _serializer;

        private IScRepository _repository;

        public ItemDataReader(string cStr, IBulkSerializer serializer)
        {
            _repository = new ScRepository(cStr);
            _serializer = serializer;
        }

        private int GetQueriesCount(int itemsCount, int maxPerQuery)
        {
            return itemsCount / maxPerQuery + (itemsCount % maxPerQuery != 0 ? 1 : 0);
        }

        public void GetItemsData(Guid rootItemId)
        {
            try
            {
                Log.SetMessage("start reading rootItem descendants");
                var itemsIds = _repository.GetItemsIds(rootItemId);
                Log.SetMessage("reading items data");
                var num = SerializingOptionsWrapper.MaxItemsPerQuery != 0 ? SerializingOptionsWrapper.MaxItemsPerQuery : 4000;
                var queriesCount = GetQueriesCount(itemsIds.Count<Guid>(), num);
                if (queriesCount > 0)
                    ClearFiles();
                for (var index = 0; index < queriesCount; ++index)
                {
                    var items = _repository.GetItems(itemsIds.Skip<Guid>(index * num).Take<Guid>(num));
                    Log.SetMessage(
                        $"{index + 1}. received {items.Count} of {itemsIds.Count<Guid>()} items from db");
                    _serializer.SerializeToDisk(items);
                    Log.SetMessage($"serialized {items.Count} items");
                }
                Log.SetMessage("Done!");
            }
            catch (Exception ex)
            {
                Log.SetMessage(ex);
            }
        }

        private void ClearFiles()
        {
            Log.SetMessage("Deleting old files");
            foreach (var filePath in SerializingOptionsWrapper.OutputFilesAsArray)
            {
                File.Delete(filePath);
            }
        }

    }
}

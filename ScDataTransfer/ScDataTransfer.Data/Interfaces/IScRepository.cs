using System;
using System.Collections.Generic;
using System.Linq;
using ScDataTransfer.Data.Entities;

namespace ScDataTransfer.Data.Interfaces
{
    public interface IScRepository
    {
        List<Item> GetItems(IEnumerable<Guid> part);
        IOrderedEnumerable<Guid> GetItemsIds(Guid rootItemId);
    }
}


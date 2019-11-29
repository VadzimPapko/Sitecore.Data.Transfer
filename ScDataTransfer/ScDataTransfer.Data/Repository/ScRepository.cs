using ScDataTransfer.Data.Context;
using ScDataTransfer.Data.Entities;
using ScDataTransfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ScDataTransfer.Data.Repository
{
    public class ScRepository : IScRepository
    {
        private string _cStr;

        public ScRepository(string cStr)
        {
            _cStr = cStr;
        }

        public IOrderedEnumerable<Guid> GetItemsIds(Guid rootItemId)
        {
            using (var context = new ScDbContext(_cStr))
            {
                var itemIds = context.Descendants.AsNoTracking().Where(i => i.Ancestor == rootItemId).Select(i => i.Descendant).ToList();
                itemIds.Insert(0, rootItemId);
                return itemIds.OrderBy(kk => kk);
            }
        }

        public List<Item> GetItems(IEnumerable<Guid> part)
        {
            using (var context = new ScDbContext(_cStr))
            {
                var result = context.Items.AsNoTracking()
                            .Where(i => part.Contains(i.ID))
                            .Include(i => i.VersionedFields)
                            .Include(i => i.UnversionedFields)
                            .Include(i => i.SharedFields)
                            .Include(i => i.DescTableRowsByDescendantId)
                            .Include(i => i.DescTableRowsByDescendantId)
                            .ToList();

                return result;
            }
        }
    }
}

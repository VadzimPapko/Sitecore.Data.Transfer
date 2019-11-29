using ScDataTransfer.Data.Entities;
using ScDataTransfer.Data.Interfaces;
using System;

namespace ScDataTransfer.Services.Serialization.Entities
{
    public class EntitySerializerBase : IEntitySerializer
    {
        protected string fieldsTerminator;
        protected string rowsTerminator;
        protected string dtFormat;

        public EntitySerializerBase(string fieldsTerminator, string rowsTerminator, string dtFormat)
        {
            this.fieldsTerminator = fieldsTerminator;
            this.rowsTerminator = rowsTerminator;
            this.dtFormat = dtFormat;
        }

        public virtual string Serialize(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

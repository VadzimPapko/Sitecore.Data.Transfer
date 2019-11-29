using ScDataTransfer.Data.Entities;
using ScDataTransfer.Services.Interfaces;
using ScDataTransfer.Utils.Options;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ScDataTransfer.Services.Serialization
{
    public class BulkSerializer : IBulkSerializer
    {
        private readonly string _cat = SerializingOptionsWrapper.FieldsTerminator;
        private readonly string _pig = SerializingOptionsWrapper.RowsTerminator;
        private readonly string _format = SerializingOptionsWrapper.SqlDateTimeFormat;

        public void SerializeToDisk(List<Item> items)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            using (StreamWriter streamWriter1 = new StreamWriter(SerializingOptionsWrapper.ItemsFilePath, true,
                SerializingOptionsWrapper.OutputEncoding))
            {
                using (StreamWriter streamWriter2 = new StreamWriter(SerializingOptionsWrapper.VersionedFIeldsFilePath,
                    true, SerializingOptionsWrapper.OutputEncoding))
                {
                    using (StreamWriter streamWriter3 = new StreamWriter(SerializingOptionsWrapper.SharedFIeldsFilePath,
                        true, SerializingOptionsWrapper.OutputEncoding))
                    {
                        using (StreamWriter streamWriter4 = new StreamWriter(
                            SerializingOptionsWrapper.UnversionedFIeldsFilePath, true,
                            SerializingOptionsWrapper.OutputEncoding))
                        {
                            using (StreamWriter streamWriter5 = new StreamWriter(
                                SerializingOptionsWrapper.DescendantsFilePath, true,
                                SerializingOptionsWrapper.OutputEncoding))
                            {
                                foreach (Item obj in items)
                                {
                                    streamWriter1.Write(this.Serialize(obj));
                                    foreach (DescendantRow row in obj.DescTableRowsByDescendantId)
                                        streamWriter5.Write(this.Serialize(row));
                                    foreach (VersionedField versionedField in obj.VersionedFields)
                                        streamWriter2.Write(this.Serialize(versionedField));
                                    foreach (UnversionedField unversionedField in obj.UnversionedFields)
                                        streamWriter4.Write(this.Serialize(unversionedField));
                                    foreach (SharedField sharedField in obj.SharedFields)
                                        streamWriter3.Write(this.Serialize(sharedField));
                                }
                            }
                        }
                    }
                }
            }
        }

        public string Serialize(Item item)
        {
            return
                $"{item.ID}{_cat}{item.Name}{_cat}{item.TemplateID}{_cat}{item.MasterID}{_cat}{item.ParentID}{_cat}{item.Created.ToString(_format)}{_cat}{item.Updated.ToString(_format)}{_pig}";
        }

        public string Serialize(VersionedField vf)
        {
            return
                $"{vf.Id}{_cat}{vf.ItemId}{_cat}{vf.Language}{_cat}{vf.Version}{_cat}{vf.FieldId}{_cat}{vf.Value}{_cat}{vf.Created.ToString(_format)}{_cat}{vf.Updated.ToString(_format)}{_pig}";
        }

        public string Serialize(UnversionedField uf)
        {
            return
                $"{uf.Id}{_cat}{uf.ItemId}{_cat}{uf.Language}{_cat}{uf.FieldId}{_cat}{uf.Value}{_cat}{uf.Created.ToString(_format)}{_cat}{uf.Updated.ToString(_format)}{_pig}";
        }

        public string Serialize(SharedField sf)
        {
            return
                $"{sf.Id}{_cat}{sf.ItemId}{_cat}{sf.FieldId}{_cat}{sf.Value}{_cat}{sf.Created.ToString(_format)}{_cat}{sf.Updated.ToString(_format)}{_pig}";
        }

        public string Serialize(DescendantRow row)
        {
            return
                $"{row.ID}{_cat}{row.Ancestor}{_cat}{row.Descendant}{_pig}";
        }
    }
}
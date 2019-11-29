using System;

namespace ScDataTransfer.Utils.Options
{
    public class SerializingOptions
    {
        public string ConnectionString { get; set; }
        public Guid RootItemId { get; set; }
        public string DataFolderName { get; set; }
        public string ItemsFileName { get; set; }
        public string SharedFIeldsFileName { get; set; }
        public string VersionedFIeldsFileName { get; set; }
        public string UnversionedFIeldsFileName { get; set; }
        public string DescendantsFileName { get; set; }
        public string FieldsTerminator { get; set; }
        public string RowsTerminator { get; set; }
        public string SqlDateTimeFormat { get; set; }
        public int MaxItemsPerQuery { get; set; }
    }
}

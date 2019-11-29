using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScDataTransfer.Utils.Options
{
    public class SerializingOptionsWrapper
    {
        private static string OptionsFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SerializingOptions.json");
        private static DateTime LastChanged;
        private static DateTime NextRead;
        private static SerializingOptions options;

        private static bool IsConfigUpdated
        {
            get
            {
                if (NextRead > DateTime.Now)
                    return false;

                if (System.IO.File.Exists(OptionsFileName))
                {
                    NextRead = DateTime.Now.AddSeconds(30);
                    return LastChanged != System.IO.File.GetLastWriteTime(OptionsFileName);
                }
                else
                {
                    throw new System.IO.FileNotFoundException("Could not find options file!");
                }
            }
        }

        private static SerializingOptions Options
        {
            get
            {
                if (IsConfigUpdated || options == null)
                {
                    var data = System.IO.File.ReadAllText(OptionsFileName);
                    options = JsonConvert.DeserializeObject<SerializingOptions>(data);
                    LastChanged = System.IO.File.GetLastWriteTime(OptionsFileName);
                    Logging.Log.SetMessage($"Configuration loaded from {OptionsFileName}");
                }

                return options;
            }
        }


        public static string ConnectionString { get { return Options.ConnectionString; } }
        public static Guid RootItemId { get { return Options.RootItemId; } }

        public static string DataFolderName { get { return Options.DataFolderName; } }

        public static string ItemsFilePath { get { return GetFullPath(Options.ItemsFileName); } }
        public static string SharedFIeldsFilePath { get { return GetFullPath(Options.SharedFIeldsFileName); } }
        public static string VersionedFIeldsFilePath { get { return GetFullPath(Options.VersionedFIeldsFileName); } }
        public static string UnversionedFIeldsFilePath { get { return GetFullPath(Options.UnversionedFIeldsFileName); } }
        public static string DescendantsFilePath { get { return GetFullPath(Options.DescendantsFileName); } }

        public static int MaxItemsPerQuery { get { return Options.MaxItemsPerQuery; } }
        public static Encoding OutputEncoding { get { return Encoding.Unicode; } }
        public static string FieldsTerminator { get { return Options.FieldsTerminator; } }
        public static string RowsTerminator { get { return Options.RowsTerminator; } }

        public static string SqlDateTimeFormat { get { return Options.SqlDateTimeFormat; } }


        public static List<string> OutputFilesAsArray { get { return new List<string> { ItemsFilePath, SharedFIeldsFilePath, VersionedFIeldsFilePath, UnversionedFIeldsFilePath, DescendantsFilePath }; } }

        public static string GetConfig() => Newtonsoft.Json.JsonConvert.SerializeObject(Options, Formatting.Indented);

        private static string GetFullPath(string fileName) => System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DataFolderName, fileName);
    }
}

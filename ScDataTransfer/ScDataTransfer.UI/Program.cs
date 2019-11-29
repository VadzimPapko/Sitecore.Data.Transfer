using ScDataTransfer.Services.DbRead;
using ScDataTransfer.Services.Serialization;
using ScDataTransfer.Utils.Options;
using System;

namespace ScDataTransfer.UI
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                ShowMenu();

                var input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        break;
                    case "1":
                        Console.WriteLine(SerializingOptionsWrapper.GetConfig());
                        Console.ReadLine();
                        continue;
                    case "2":
                    {
                        var reader = new ItemDataReader(SerializingOptionsWrapper.ConnectionString, new BulkSerializer());
                        reader.GetItemsData(SerializingOptionsWrapper.RootItemId);
                        Console.ReadLine();
                        continue;
                    }
                }
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - show config");
            Console.WriteLine("2 - run");
            Console.WriteLine("0 - exit");
        }
    }
}

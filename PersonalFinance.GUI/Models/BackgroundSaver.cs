using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PersonalFinance.GUI.Models
{
    public struct WalletBackground
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }

    public static class WalletBackgroundSaver
    {
        public static void Save(int walletId, string path)
        {
            var items = JsonSerializer.Deserialize<List<WalletBackground>>("backgrounds.json");
            items!.Add(new WalletBackground { Id = walletId, Path = path });
            var file = JsonSerializer.Serialize(items);
            File.WriteAllText("backgrounds.json", file);
        }

        public static List<WalletBackground> Load()
        {
            return JsonSerializer.Deserialize<List<WalletBackground>>("backgrounds.json")!;
        }
    }
}

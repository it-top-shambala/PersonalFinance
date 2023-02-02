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
            var fromFile = File.ReadAllText("backgrounds.json");
            var list = JsonSerializer.Deserialize<List<WalletBackground>>(fromFile);
            list!.Add(new WalletBackground { Id = walletId, Path = path });
            var file = JsonSerializer.Serialize(list);
            File.WriteAllText("backgrounds.json", file);
        }

        public static List<WalletBackground> Load()
        {
            var fromFile = File.ReadAllText("backgrounds.json");
            return JsonSerializer.Deserialize<List<WalletBackground>>(fromFile)!;
        }
    }
}

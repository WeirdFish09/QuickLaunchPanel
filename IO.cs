using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace QuickLaunchPanel
{
    public static class IO
    {
        private static string home = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static string path = home + "/.config/QLP/Entries.json";
        public static List<Entry> LoadEntries()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string result = sr.ReadToEnd();
                if (result == "")
                {
                    return new List<Entry>();
                }
                return JsonConvert.DeserializeObject<List<Entry>>(result);
            }
        }
        public static void SaveEntries(List<Entry> entries)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(JsonConvert.SerializeObject(entries));
            }
        }
        public static void CheckCreateConfig()
        {
            DirectoryInfo di = new DirectoryInfo(home + "/.config");
            if (!di.GetDirectories().FolderExists("QLP"))
            {
                Directory.CreateDirectory(home + "/.config/QLP");
                using (StreamWriter sw = new StreamWriter(path, false)) { };
            }
        }
        private static bool FolderExists(this DirectoryInfo[] di, string name)
        {
            for (int i = 0; i < di.Length; i++)
            {
                if (di[i].Name == name) return true;
            }
            return false;
        }
    }
}
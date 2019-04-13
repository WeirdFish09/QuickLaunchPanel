using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;
namespace QuickLaunchPanel
{
    public static class IO
    {
        private static string configPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/.config";
        private static string path = configPath + ConfigurationManager.AppSettings["EntriesPath"] + ConfigurationManager.AppSettings["EntriesFile"];
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
            DirectoryInfo di = new DirectoryInfo(configPath);
            if (!di.GetDirectories().FolderExists(ConfigurationManager.AppSettings["EntriesPath"].Replace("/","")))
            {
                Directory.CreateDirectory(configPath + ConfigurationManager.AppSettings["EntriesPath"]);
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
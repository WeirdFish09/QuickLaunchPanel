using System;
using System.Collections.Generic;
using System.Linq;
namespace QuickLaunchPanel
{
    public static class Controller
    {
        private static List<Entry> entries = new List<Entry>();
        public static void LoadEntries(){
            entries = IO.LoadEntries().Take(16).ToList();
        }
        public static void SaveEntries(){
            IO.SaveEntries(entries);
        }
        public static List<Entry> GetEntries(){
            return entries;
        }
        public static List<Entry> GetTopRow(){
            return entries.Take(8).ToList();
        }
        public static List<Entry> GetBotRow(){
            return entries.Skip(8).TakeWhile(entry => entry!=null).ToList();
        }
        public static void RemoveEntry(string name){
            entries.Remove(entries.Where(entry => entry.Name == name).ToList()[0]);
        }
        public static bool AddEntry(string name, string command){
            if(entries.Count==14) return false;
            entries.Add(new Entry(name, command));
            return true;
        }
        public static string GetCommand(string name){
            return entries.Where(entry => entry.Name == name).First().Command;
        }
    }
}
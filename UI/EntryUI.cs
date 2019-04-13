using System;
using Gtk;
namespace QuickLaunchPanel.UI
{
    public class EntryUI : Button
    {
        private MainWindow Parrent;
        private bool deletion = false;
        public bool Deletion{
            get{
                return deletion;
            }
            set{
                deletion = value;
                if(deletion){
                    this.Clicked -= new EventHandler(ExecuteCommand); 
                    this.Clicked += new EventHandler(OnDeletion);
                } else {
                    this.Clicked += new EventHandler(ExecuteCommand); 
                    this.Clicked -= new EventHandler(OnDeletion);
                }
            }}
        public EntryUI(Entry entry, MainWindow parrent)
        {
            Name = entry.Name;
            this.Label = Name;
            this.Clicked += new EventHandler(ExecuteCommand);
            Parrent = parrent;
        }
        private void ExecuteCommand(object sender, EventArgs e){
            Controller.GetCommand(this.Name).Bash();
        }
        private void OnDeletion(object sender, EventArgs e){
            Controller.RemoveEntry(this.Name);
            Parrent.ShowAll();
        }

    }
}
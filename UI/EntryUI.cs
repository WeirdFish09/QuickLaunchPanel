using System;
using Gtk;
namespace QuickLaunchPanel.UI
{
    public class EntryUI : Button
    {
        public EntryUI(Entry entry)
        {
            Name = entry.Name;
            this.Label = Name;
            this.Clicked += new EventHandler(
                (sender, EventArgs) => {
                    Controller.GetCommand(this.Name).Bash();
                }
            );
        }

    }
}
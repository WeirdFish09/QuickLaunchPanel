using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;
namespace QuickLaunchPanel.UI
{
    public class MainWindow : Window
    {
        bool deletion = false;
        Gdk.Color btnColor;
        VBox mainVBox;

        List<EntryUI> entryWidgets = new List<EntryUI>();
        public MainWindow() : this("") { }

        private MainWindow(string str) : base(str)
        {
            SetGeometry();
            InitMainVBox();
            this.ShowAll();
        }
        private void SetGeometry(){
            int width, height = 0;
            MonitorInfo.GetMonitorGeometry(out height,out width);
            width = (int) (width * 0.7);
            height = (int) (height * 0.35);
            this.SetSizeRequest(width,height);
            this.Move(width/2,0);
        }
        private void InitMainVBox(){
            mainVBox = new VBox();
            mainVBox.PackStart(new TopPanel(),false,false,0);
            DisplayEntries();
            mainVBox.ShowAll();
            this.Add(mainVBox);
        }
        private void DisplayEntries(){
            entryWidgets.Clear();
            if(Controller.GetEntries().Count>8){
                HBox hboxTop = new HBox();
                HBox hboxBot = new HBox();
                mainVBox.Add(PopulateHbox(hboxTop,Controller.GetTopRow()));
                mainVBox.Add(PopulateHbox(hboxBot,Controller.GetBotRow()));
            } else {
                HBox hbox = new HBox();
                mainVBox.Add(PopulateHbox(hbox,Controller.GetEntries()));
            }
        }
        private HBox PopulateHbox(HBox hbox, List<Entry> entries){
            EntryUI entryUI;
            if(entries.Count>3){
                entryUI = new EntryUI(entries[0], this); 
                hbox.PackStart(entryUI,false,false,0);
                entryWidgets.Add(entryUI);
                entryUI = new EntryUI(entries[1], this);
                hbox.Add(entryUI);
                entryWidgets.Add(entryUI);
                //entries.Remove(entries[0]);
                //entries.Remove(entries[0]); //make this pretty
                HBox hboxTmp = new HBox();
                hbox.Add(PopulateHbox(hboxTmp, entries.Skip(2).ToList()));
                return hbox;
            }
            foreach(var entry in entries){
                entryUI = new EntryUI(entry, this);
                hbox.Add(entryUI);
                entryWidgets.Add(entryUI);
            }
            return hbox;
        }
        protected override void OnShowAll(){
            entryWidgets.Clear();
            if(this.Child==mainVBox)
                this.Remove(mainVBox);
            mainVBox = null;
            InitMainVBox();
            mainVBox.ShowAll();
        }
        public void ToggleDeletion(){
            deletion = !deletion;
            if(deletion){
                ChangeBg(new Gdk.Color(255,0,0));
                foreach(var entry in entryWidgets){
                    entry.Deletion = true;
                }
            } else {
                entryWidgets.Clear();
                this.ShowAll();
            }
        }
        private void ChangeBg(Gdk.Color color){
            foreach(var entryUI in entryWidgets){
                    entryUI.ModifyBg(StateType.Normal,color);
                }
        }
    }
}

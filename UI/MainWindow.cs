using System;
using Gtk;
using System.Collections.Generic;
namespace QuickLaunchPanel.UI
{
    class MainWindow : Window
    {
        VBox mainVBox;
        public MainWindow() : this("") { }

        private MainWindow(string str) : base(str)
        {
            SetGeometry();
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
            if(entries.Count>3){
                hbox.PackStart(new EntryUI(entries[0]),false,false,0);
                hbox.Add(new EntryUI(entries[1]));
                entries.Remove(entries[0]);
                entries.Remove(entries[0]); //make this pretty
                HBox hboxTmp = new HBox();
                hbox.Add(PopulateHbox(hboxTmp, entries));
                return hbox;
            }
            foreach(var entry in entries){
                hbox.Add(new EntryUI(entry));
            }
            return hbox;
        }
        protected override void OnShowAll(){
            this.Remove(mainVBox);
            mainVBox = null;
            InitMainVBox();
            mainVBox.ShowAll();
        }
    }
}

using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace QuickLaunchPanel
{
    class MainWindow : Window
    {
        [UI] Label labelTest = null;
        public MainWindow() : this("") { }

        private MainWindow(string str) : base(str)
        {
            int width, heigth = 0;
            MonitorInfo.GetMonitorGeometry(out heigth,out width);
            width = (int) (width * 0.7);
            heigth = (int) (heigth * 0.35);
            this.SetSizeRequest(width,heigth);
            labelTest = new Label();
            labelTest.Expand = true;
            HBox hbox = new HBox();
            hbox.Fill = true;
            hbox.Add(labelTest);
            this.Add(hbox);
            this.Move(0,5 - heigth);
            this.ShowAll();
            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}

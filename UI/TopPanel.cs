using System;
using Gtk;

namespace QuickLaunchPanel.UI
{
    public class TopPanel: Gtk.Toolbar
    {
        ToolButton Exit;
        ToolButton New;
        ToolButton Delete;
        public TopPanel()
        {
            this.ToolbarStyle = ToolbarStyle.Icons;
            InitExit();
            InitNew();
            InitDelete();
            this.Insert(New,0);
            this.Insert(Delete,1);
            this.Insert(new SeparatorToolItem(),2);
            this.Insert(Exit,3);
            this.ShowAll();
        }

        private void InitExit(){
            Exit = new ToolButton(Stock.Quit);
            Exit.Clicked += new EventHandler(ExitClick);
        }
        private void ExitClick(object sender, EventArgs e){
            Application.Quit();
        }
        private void InitNew(){
            New = new ToolButton(Stock.Add);
            New.Clicked += new EventHandler(OnCreateNew);
        }
        private void InitDelete(){
            Delete = new ToolButton(Stock.Delete);
        }
        private void RefreshParrent(){
            this.Parent.Parent.ShowAll();
        }
        private void OnCreateNew(object sender, EventArgs e){
            AddNewDialog newDialog = new AddNewDialog();
            newDialog.Hidden += new EventHandler(HandleDialog);
            newDialog.Show();
            newDialog.GrabFocus();
        }
        private void HandleDialog(object sender, EventArgs e){
            Controller.AddEntry(((AddNewDialog) sender).EntryName, ((AddNewDialog) sender).EntryCommand);
            RefreshParrent();
        }
    }
}
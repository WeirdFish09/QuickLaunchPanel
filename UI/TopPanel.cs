using System;
using Gtk;

namespace QuickLaunchPanel.UI
{
    public class TopPanel: Gtk.Toolbar
    {
        ToolButton Exit;
        ToolButton New;
        ToolButton Delete;
        //ToolButton ChangeSettings;
        //ToolButton RestoreSettings;
        public TopPanel()
        {
            this.ToolbarStyle = ToolbarStyle.Icons;
            InitExit();
            InitNew();
            InitDelete();
            //InitChangeSettings();
            //InitRestoreSettings();
            this.Insert(New,0);
            this.Insert(Delete,1);
            this.Insert(new SeparatorToolItem(),2);
            this.Insert(Exit,3);
            //this.Insert(ChangeSettings,4);
            //this.Insert(RestoreSettings,5);
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
            Delete.Clicked += new EventHandler(OnDelete);
        }
        private void OnDelete(object sender, EventArgs e){
            ((MainWindow)this.Parent.Parent).ToggleDeletion();
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
            string EntryName = ((AddNewDialog) sender).EntryName.Trim();
            string EntryCommand = ((AddNewDialog) sender).EntryCommand.Trim();
            if(EntryName != String.Empty && EntryCommand != String.Empty)
                Controller.AddEntry(((AddNewDialog) sender).EntryName, ((AddNewDialog) sender).EntryCommand);
            RefreshParrent();
        }
        // private void InitChangeSettings(){
        //     ChangeSettings = new ToolButton(Stock.No);
        //     ChangeSettings.Clicked += new EventHandler(ChangeSettingsClick);
        // }
        // private void ChangeSettingsClick(object sender, EventArgs e){
        //     ConfigSettings.WriteSetting("EntriesPath","/QLP2/");
        // }
        // private void InitRestoreSettings(){
        //     RestoreSettings = new ToolButton(Stock.Yes);
        //     RestoreSettings.Clicked += new EventHandler(RestoreSettingsClick);
        // }
        // private void RestoreSettingsClick(object sender, EventArgs e){
        //     ConfigSettings.WriteSetting("EntriesPath","/QLP/");
        // }
    }
}
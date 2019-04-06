using System;
using Gtk;
namespace QuickLaunchPanel.UI
{
    public class AddNewDialog : Window
    {
        private VBox mainVBox;
        private Gtk.Entry nameEntry;
        private Gtk.Entry commandEntry;
        private Button confirmButton;
        private Button cancelButton;
        public string EntryName{get; private set;}
        public string EntryCommand{get; private set;}
        public AddNewDialog() : base ("")
        {
            this.SetSizeRequest(500,250);
            nameEntry = new Gtk.Entry();
            commandEntry = new Gtk.Entry();
            nameEntry.Name = "nameEntry";
            commandEntry.Name = "commandEntry";
            InitButtons();
            InitMainVBox();
            this.Add(mainVBox);
            this.ShowAll();
        }
        private void InitMainVBox(){
            mainVBox = new VBox();
            HBox topHBox = new HBox();
            topHBox.Add(new Label("Name:"));
            topHBox.Add(nameEntry);
            HBox midHBox = new HBox();
            midHBox.Add(new Label("Command:"));
            midHBox.Add(commandEntry);
            HBox botHBox = new HBox();
            botHBox.Add(cancelButton);
            botHBox.Add(confirmButton);
            mainVBox.Add(topHBox);
            mainVBox.Add(midHBox);
            mainVBox.Add(botHBox);
        }
        private void InitButtons(){
            confirmButton =  new Gtk.Button("Confirm");
            confirmButton.Clicked += new EventHandler(OnConfirm);
            cancelButton = new Button("Cancel");
            cancelButton.Clicked += new EventHandler(OnCancel);
        }
        private void OnConfirm(object sender, EventArgs e){
            EntryName = nameEntry.Text;
            EntryCommand = commandEntry.Text;
            this.Hide();
        }
        private void OnCancel(object sender, EventArgs e){
            EntryName = nameEntry.Text;
            EntryCommand = commandEntry.Text;
            this.Hide();
        }
    }
}
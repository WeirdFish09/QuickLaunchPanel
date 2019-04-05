using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace GtkNamespace
{
    class QuickLaunchPanel : Window
    {
        public QuickLaunchPanel() : this(new Builder("QuickLaunchPanel.glade")) { }

        private QuickLaunchPanel(Builder builder) : base(builder.GetObject("QuickLaunchPanel").Handle)
        {
            builder.Autoconnect(this);
        }
    }
}

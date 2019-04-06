namespace QuickLaunchPanel
{
    public class Entry
    {
        public string Command{get; private set;}
        public string Name{get; private set;}
        public Entry(string name, string command)
        {
            Command = command;
            Name = name;
        }
    }
}
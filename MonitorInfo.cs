using System;
using Gdk;
namespace QuickLaunchPanel
{
    public static class MonitorInfo
    {
        public static void GetMonitorGeometry(out int height, out int width){
            int x,y = 0;
            Gdk.Display.Default.GetPointer(out x,out y);
            int monitorId = Gdk.Screen.Default.GetMonitorAtPoint(x,y);
            height = Gdk.Screen.Default.GetMonitorGeometry(monitorId).Height;
            width = Gdk.Screen.Default.GetMonitorGeometry(monitorId).Width;
        }
    }
}
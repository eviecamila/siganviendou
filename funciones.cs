using Gtk;
using System;
namespace funciones
{
    public class f
    {
        public static void cajita(string txt, Window w)
        {MessageDialog dlg = new MessageDialog(w, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, txt);dlg.Run();dlg.Destroy();}
        public static void show_score(Label l, int wins, int totalwins)
        {l.Text = "Wins: " + str(wins)+ " Total Wins: " + str(totalwins+wins);}
        public static string str(dynamic num){return Convert.ToString(num);}
        public static int intt(string num){return Convert.ToInt32(num);}
    }
}
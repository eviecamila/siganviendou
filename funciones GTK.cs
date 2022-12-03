using Gtk;
using System;
namespace funciones
{
    public class f
    {
        public static void cajita(string txt, Window w)
        {MessageDialog dlg = new MessageDialog(w, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, txt);dlg.Run();dlg.Destroy();}

        public string str(dynamic num){return Convert.ToString(num);}
    }
}
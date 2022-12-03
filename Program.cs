using System;
using Gtk;
using System.Threading;
using rps;
namespace mishicutre
{   
    public class Program
    {
        public static Window w_menu = new menu();
        // public static Window w_sudoku = new sudoku(), w_tictactoe = new tictactoe.tictactoe_gui(), w_pairs = new pares_y_nones.pares_nones_gui(), w_rps = new rps.rps_gui(), w_menu = new menu(), 
        public static Window w_login = new login();
        public static Application app = new Application("org.mishicutre.mishicutre", GLib.ApplicationFlags.None);
        [STAThread]
        public static void Main(string[] args)
        {
            
            Application.Init();
            // this.app = new Application("org.proj.login", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);
            // app.AddWindow(w_sudoku);
            // app.AddWindow(w_tictactoe);
            // app.AddWindow(w_pairs);
            // app.AddWindow(w_rps);
            // app.AddWindow(w_menu);
            // app.AddWindow(w_login);
            // w_rps.Hide();
            w_login.Show();
            Application.Run();
        }
    }
}

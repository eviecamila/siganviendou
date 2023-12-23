using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using mishicutre;
using funciones;
namespace mishicutre
{
    class menu : Window
    {
        conexion sql = conexion.get_inst();
        
        [UI] private Button b_rps = new Button(), b_pairs = new Button(), b_sudoku = new Button(), b_tictactoe = new Button();
        private bool r = true, p = true, s = true, t = true;
        [UI] private Entry TB_USR = new Entry(), TB_PASS = new Entry();
        public menu() : this(new Builder("menu.glade")) { }

        private menu(Builder builder) : base(builder.GetRawOwnedObject("ventana"))
        {
            //TB_PASS.Visibility = false;
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            b_rps.Clicked += b_rps_Clicked;
            b_pairs.Clicked += b_pairs_Clicked;
            b_sudoku.Clicked += b_sudoku_Clicked;
            b_tictactoe.Clicked += b_tictactoe_Clicked;
        }
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {Application.Quit();}

        private void b_rps_Clicked(object sender, EventArgs a)
        {Window w = new rps.rps_gui();r = open(r, w, "RPS");}
        private void b_tictactoe_Clicked(object sender, EventArgs a)
        {Window w = new tictactoe.tictactoe_gui();t = open(t, w, "TicTacToe");}
        private void b_sudoku_Clicked(object sender, EventArgs a)
        {Window w = new sudoku();s = open(s, w, "Sudoku #");}
        private void b_pairs_Clicked(object sender, EventArgs a)
        {Window w = new pares_y_nones.pares_nones_gui();p = open(p, w, "Pares y Nones");}
        public bool open(bool a, Window w, string title)
        {if (a) Application.AddWindow(w); a = false;w.Show();this.Hide(); return a;}
    }
}
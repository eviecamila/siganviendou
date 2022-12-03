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
        [UI] private Button b_rps, b_pairs, b_sudoku, b_tictactoe;
        [UI] private Entry TB_USR, TB_PASS;
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
        {Window w = new rps.rps_gui();;open(w, "RPS");}
        private void b_tictactoe_Clicked(object sender, EventArgs a)
        {Window w = new tictactoe.tictactoe_gui();open(w, "TicTacToe");}
        private void b_sudoku_Clicked(object sender, EventArgs a)
        {Window w = new sudoku();open(w, "Sudoku #");}
        private void b_pairs_Clicked(object sender, EventArgs a)
        {Window w = new pares_y_nones.pares_nones_gui();open(w, "Pares y Nones");}
        public void open(Window w, string title)
        {Application.AddWindow(w);w.Show();this.Hide();}
    }
}
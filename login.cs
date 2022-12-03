using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using mishicutre;
using System.Threading;
using funciones;
namespace mishicutre
{
    class login : Window
    {
        conexion sql = conexion.get_inst();
        [UI] private Button b_login = null;
        [UI] private Entry TB_USR = null, TB_PASS = null;
        public login() : this(new Builder("login.glade")) { }

        private login(Builder builder) : base(builder.GetRawOwnedObject("FR_LOGIN"))
        {
            //TB_PASS.Visibility = false;
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            b_login.Clicked += b_login_Clicked;
        }
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {Application.Quit();}

        private void b_login_Clicked(object sender, EventArgs a)
        {
            log();
        }
        [STAThread]
        private void log()
        {
            if (sql.buscar_where_x_e_y("users", TB_USR.Text, "name", "pass") == TB_PASS.Text)
            {
                // Thread t_menu = new Thread(raaan);
                // t_menu.Start();
                raaan();
                this.Hide();
            }
        }
        private void raaan()
        {
            Program.app.AddWindow(Program.w_menu);
            Program.w_menu.Show();

            // run.w_menu = run.menu();
        }
        
    }
}
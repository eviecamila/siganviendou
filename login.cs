using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Newtonsoft.Json;

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
            string datos = con.rest.consumir("http://127.0.0.1:3000/login&u="+ TB_USR.Text +"&p=" + TB_PASS.Text);
            string escorrecto = con.rest.socket();
            dynamic data = JsonConvert.DeserializeObject(datos);
            if (escorrecto[0] == '1') raaan(data);
            // if (conexion.buscar_where_x_e_y("users", TB_USR.Text, "name", "pass") == TB_PASS.Text)
            // {
            //     // Thread t_menu = new Thread(raaan);
            //     // t_menu.Start();
            //     raaan();
            //     this.Destroy();
            // }
            else f.cajita("Verifique sus datos, escroto = " + escorrecto, this);
        }
        private void raaan(dynamic data)
        {
            //servicios web
            
            
            //web service

            string _id = data.id;
            string _user = data.user;
            user a = user._i(_id, _user);
            Program.app.AddWindow(Program.w_menu);
            Program.w_menu.Show();
            this.Hide();
            
        }
        
    }
}
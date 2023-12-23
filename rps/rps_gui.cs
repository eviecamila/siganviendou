using System;
using Gtk;
//using GtkSharp;
using UI = Gtk.Builder.ObjectAttribute;
using characters;
using funciones;
using mishicutre;
// using System.Threading;
// using System.Linq;
// using System.Collections.Generic;

namespace rps
{
    class rps_gui : Window
    {
        // int _id;
        // string _user;
        //VICTORIAS
        static user p = user._i();
        // int wins = 0, totalwins = f.intt(con.rest.socket_exec("http:127.0.0.1/rps/load"));
        int wins = 0, totalwins = f.intt(con.rps.load(p.id));

        //JUGADORES
        cpu bot = chars.bot;
        you yourself = chars.you;

        [UI] public Fixed fx = new Fixed();
        [UI] Label a = new Label(), l_wins = new Label(); 
        // public Button b_r=null , b_p=null, b_s=null;
        [UI] public Button b_r = new Button(), b_p = new Button(), b_s = new Button(), b_menu = new Button();
        // private Image _i = new Image();
        // public Image r = new Image(), p = new Image(), s = new Image(), img_logo = new Image();

        //INSTANCIA
        // private gui _instance;

        //CONSTRUCTORES DEL FORM

        //int id, string user  _id = id; _user = user;
        public rps_gui() : this(new Builder("piedrosos.glade")) {}
        public rps_gui(Builder builder) : base(builder.GetRawOwnedObject("ventana"))
        {
            
            // this.Title = "RPS BY PACOCK";
            builder.Autoconnect(this); f.show_score(l_wins, wins, totalwins);
            DeleteEvent += Window_DeleteEvent;
            //Build win before start
            fx.Add(a);fx.Move(a, 450, 300);
            // _i.Show();
            // cargar_img(img_logo, "sprites/logo.png");

            //BOTONES:
            b_r.Clicked += b_r_Clicked;
            b_p.Clicked += b_p_Clicked;
            b_s.Clicked += b_s_Clicked;
            b_menu.Clicked += b_menu_Clicked;
            ShowAll();
        }
        public void cargar_img(Gtk.Image img, string path){
        var buffer =  System.IO.File.ReadAllBytes(path);
        var pixbuf = new Gdk.Pixbuf(buffer); img.Pixbuf = pixbuf;}
        private void b_r_Clicked(object sender, EventArgs e)
        {startgame(1);}
        private void b_p_Clicked(object sender, EventArgs e)
        {startgame(2);}
        private void b_s_Clicked(object sender, EventArgs e)
        {startgame(3);}
        private void b_menu_Clicked(object sender, EventArgs e)
        {Program.w_menu.Show(); con.rps.save(f.str(totalwins+wins), p.id);this.Hide();}
        private void startgame(int n)
        {
            rps game = new rps(n);
            cajita("Has seleccionado " + ((items)(chars.you.rps-1)));
            cajita("CPU ha seleccionado " + ((items)(chars.bot.rps-1)));
                switch (game.winner)
                {
                    case 1: {cajita("Has ganado"); wins++; f.show_score(l_wins, wins, totalwins);}break;
                    case 2: {cajita("Has perdido");}break;
                    case 0: {cajita("Empate");}break;
                }
        }
        
        //CERRAR PROGRAMA
        private void Window_DeleteEvent(object sender, DeleteEventArgs a){Application.Quit();}
        //DIALOG BOX
        public void cajita(string txt){MessageDialog dlg = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, txt);dlg.Run();dlg.Destroy();}

    }
}
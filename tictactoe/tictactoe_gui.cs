using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace tictactoe
{
    class tictactoe_gui : Window
    {

        //PONER IP DE LA OTRA COMPU
        string ip_remota = "";
        [UI] private Label size = null;

        //BOTONES DEL TICTACTOE
        [UI] private Button b00, b01, b02, b10, b11, b12, b20, b21, b22, b_ret, b_new;
        [UI] private Image i00 = new Image(), i01 = new Image(), i02 = new Image(),
                           i10 = new Image(), i11 = new Image(), i12 = new Image(),
                           i20 = new Image(), i21 = new Image(), i22 = new Image();
        private tictactoe_src game = tictactoe_src._actual();
        private char c = ' ';

        //Constructores con metodos
        public tictactoe_gui() : this(new Builder("tictactoe_fr.glade")) { }
        private tictactoe_gui(Builder builder) : base(builder.GetRawOwnedObject("ventana"))
        {
            this.Title = "Tictactoe by min min";
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            
            b00.Clicked +=  b00_c;b01.Clicked +=  b01_c;b02.Clicked +=  b02_c;
            b10.Clicked +=  b10_c;b11.Clicked +=  b11_c;b12.Clicked +=  b12_c;
            b20.Clicked +=  b20_c;b21.Clicked +=  b21_c;b22.Clicked +=  b22_c;

            b_ret.Clicked += b_ret_clk;b_new.Clicked += b_new_clk;
            

        }

        //Cerrar programa
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            this.Hide();
            // this.Destroy();
        } 

        //Funcion de caja de dialogo
        private void cajita(string txt){MessageDialog dlg = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, txt);dlg.Run();dlg.Destroy();}

        //Funcion que activa cada boton del grid
        private void b00_c(object sender, EventArgs a){grid_btn_click(b00, i00, 0, 0);}
        private void b01_c(object sender, EventArgs a){grid_btn_click(b01, i01, 0, 1);}
        private void b02_c(object sender, EventArgs a){grid_btn_click(b02, i02, 0, 2);}
        private void b10_c(object sender, EventArgs a){grid_btn_click(b10, i10, 1, 0);}
        private void b11_c(object sender, EventArgs a){grid_btn_click(b11, i11, 1, 1);}
        private void b12_c(object sender, EventArgs a){grid_btn_click(b12, i12, 1, 2);}
        private void b20_c(object sender, EventArgs a){grid_btn_click(b20, i20, 2, 0);}
        private void b21_c(object sender, EventArgs a){grid_btn_click(b21, i21, 2, 1);}
        private void b22_c(object sender, EventArgs a){grid_btn_click(b22, i22, 2, 2);}

        //Funcion generica para los botones del grid
        private void grid_btn_click(Button btn, Image img, int x, int y)
        {
            if (!game.terminado() /*&& game.es_turno()*/)
            {
            c= game.get_icon();
           
            // if (game.put_icon(c,x, y) == true) btn.Label = Convert.ToString(c);
            if (game.put_icon(c,x, y) == true)  cargar(img, "tictactoe/sprites/"+c+".png");
            else  cajita("No se puede ahi compañero");
            if (game.terminado()) cajita("El ganador es el jugador " + Convert.ToString(game.elganador()));
            else if (game.vamosen() == 10) cajita("Supongo que esto es un empate");
            }
            // else if (!game.terminado()){
                // string a = con.sockets.receive(ip_remota, this);
                // funciones.f.cajita(a, this);
                // c = game.get_icon();
                // }
            // ShowAll();       
        }

        //FUNCION PARA REGRESAR AL MENU PRINCIPAL
        private void b_ret_clk(object sender, EventArgs a)
        {
            mishicutre.Program.w_menu.Show();
            this.Destroy();
        }

        /*Funcion al presionar el boton "NUEVO JUEGO"
                Reinicia la instancia a un juego vacio
                Limpia los botones*/
        private void b_new_clk(object sender, EventArgs a)
        {
            game = tictactoe_src._newgame();
            clr(i00);clr(i01);clr(i02);clr(i10);clr(i11);clr(i12);clr(i20);clr(i21);clr(i22);
        }

        //Limpia una imagen
        public void clr(Image img){cargar(img, "tictactoe/sprites/nothing.png");}


        //metodo para cambiar la imagen con el objeto imagen y la ruta de la imagen a cargar
        public static void cargar(Gtk.Image img, string path){
        var buffer =  System.IO.File.ReadAllBytes(path);
        var pixbuf = new Gdk.Pixbuf(buffer); img.Pixbuf = pixbuf;}
    }
}

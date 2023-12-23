using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Threading;
using System.Threading.Tasks;

using mishicutre;
using funciones;

namespace pares_y_nones
{
    public class pares_nones_gui : Window
    {
        // static user p = user._i();
        static user p = user._i();
        [UI] private Label l_wins = new Label();
        int wins = 0, totalwins = f.intt(con.pares.load(p.id));
        // static Builder b = new Builder("pares_nones.glade");
        [UI] private Label timer;
        [UI] private Button b_new, b_menu, b1, b2;
        [UI] private Image player, bot;
        [UI] private MessageDialog md;
        public string _counter = "", mode = " ", salida = "";
        Semaphore sem = new Semaphore(4, 4);
        bool pressed = false, showed = false;
        object enter = new object();
        
        public pares_nones_gui() : this(new Builder("pares_nones.glade")) { }

        private pares_nones_gui(Builder builder) : base(builder.GetRawOwnedObject("ventana"))
        {
            builder.Autoconnect(this);
            // b.GetObject("timer");
            DeleteEvent += Window_DeleteEvent;
            f.show_score(l_wins, wins, totalwins);
            // ShowAll();\
            // this.timer.Text = "PENE";
            b_new.Clicked += cambiar_tipo;
            b_menu.Clicked += menu_principal;
            b1.Clicked += b1_clk;
            b2.Clicked += b2_clk;
            // b_new.Clicked += esperar_caja;
        }

        bool candado;
        private void cuenta_regresiva()
        {
            // sem.WaitOne();
            candado = false;
            int clock = 3;
            while (clock > 0){Thread.Sleep(1000); clock--; timer.Text = Convert.ToString(clock);}
            candado = true;
            // sem.Release();
        }
        private void selectnum()
        {
            // sem.WaitOne();
            while (candado == false)
            {
                this.KeyPressEvent += keypress;
                this.Title = (_counter);
            }
            this.Title =("Has elegido "+ (_counter));
            // cajita(_counter);
            // sem.Release();
            // Thread caja = new Thread(() => cajita("so"));
            // caja.Start();
            // cajita(_counter);
            
        }
        
        //BORRRAR PORQUE YA ESTA EN LA FINAL
        private void cajita(string txt)
        {
            MessageDialog dlg = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, txt);dlg.Run();dlg.Destroy();
        }
        public string str(int num){return Convert.ToString(num);}

        
        private void keypress(object sender, KeyPressEventArgs a)
        {
            // sem.WaitOne();
            // string num = " ";
            switch (a.Event.Key)
            {
            case Gdk.Key.Key_1:_counter = "0";break;
            case Gdk.Key.Key_2:_counter = "1";break;
            case Gdk.Key.Key_3:_counter = "2";break;
            default: _counter = "NULL";break;
            }
            // this._counter = /*Convert.ToInt32*/(num);
        }
        private void nokey(object sender, KeyPressEventArgs a){}
        private void selectmode(object sender, KeyPressEventArgs a)
        {
            switch (a.Event.Key)
            {
            case Gdk.Key.Key_1:mode = "1";this.pressed = true;break;
            case Gdk.Key.Key_2:mode = "0";this.pressed = true;break;
            }
            // if (pressed) {cajita(mode);pressed = false;}

            //No borrar, capaz y jala
            if (pressed == true && showed == false) elegiste();
            else cajita("bugiadoooo");
        }
        private void elegiste()
        {
            
            switch (mode)
            {
                case "0": salida = "pares";break;
                case "1": salida = "nones";break;
            }
            cajita("Has seleccionado " + salida); showed = true;
            this.Title = "Estas jugando con: " + salida;
        }
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
        // private void esperar_caja(string txt){Thread.Sleep(3000);}

        //funcion que cambia el modo de juego a pares o nones en cualquier momento deseado
        private void cambiar_modo()
        {
            // Monitor.Enter(enter);
            // while (true)
            // {
                this.KeyPressEvent += selectmode;
                while (pressed == false){}
                // if (pressed) 
                {this.KeyPressEvent -= selectmode;  //break;
                }
            // }
            // cajita(mode);return;
            // Monitor.Exit(enter);
            return;
        }

        //Funcion que compara si un numero es par o impar y retorna su tipo
        private string comparar(int num)
        {if (num % 2 == 0) return "pares"; return "nones";}

        //Funcion de jugada generica
        private void jugada(int num, int pon)
        {
            pares_nones_src game = pares_nones_src.newgame(num, pon);
            cajita("Has elegido " + str(num) + " (" + comparar(num) + ")");
            cajita("CPU ha seleccionado " + str(game.stats.cpu) + " (" + comparar(game.stats.cpu) + ")");
            cajita(str(num) + " + " +str(game.stats.cpu) + " = " + str(game.stats.cpu + num) + "\n\t" + comparar(game.stats.cpu + num));
            if (game.ganaste()) {cajita("Has ganado");wins++; f.show_score(l_wins, wins, totalwins + wins);}
            else cajita("Has Perdido");
        }

        //Funciones de los botones que llaman a la jugada generica
        private void menu_principal(object sender, EventArgs a)
        {mishicutre.Program.w_menu.Show();this.Destroy();}
        private void b1_clk(object sender, EventArgs a)
        {if (mode != " ")jugada(1, Convert.ToInt32(mode));
         else cajita("XD" + mode);}
        private void b2_clk(object sender, EventArgs a)
        {if (mode != " ")jugada(0, Convert.ToInt32(mode));
         else cajita("XD" + mode);}


         //Funcion del boton que hace cambiar el modo de juego
        private void cambiar_tipo(object sender, EventArgs a)
        {
            Title = "Elige un numero, 1-Pares, 2-Nones";
            pressed = false;showed = false;
            cajita("Cierra esto y selecciona un numero:\nNones: 1\nPares: 2");
            
            Thread modo = new Thread(cambiar_modo);
            modo.Start();

            // Thread game = new Thread(cambiar_game);


        }
    }
}

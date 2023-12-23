using System;
using funciones;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Linq;
namespace mishicutre
{
    class sudoku : Window
    {
        static string num = " ";
        public static char[][] grid = {
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };
        bool completo = false;
        static sudoku_src game = new sudoku_src(grid);
        //JALAR UN GRID Y USARLO PARA MOVER
        [UI] private Button b00, b10, b20, b30, b40, b50, b60, b70, b80, b01, b11, b21, b31, b41, b51, b61, b71, b81,
                            b02, b12, b22, b32, b42, b52, b62, b72, b82, b03, b13, b23, b33, b43, b53, b63, b73, b83,
                            b04, b14, b24, b34, b44, b54, b64, b74, b84, b05, b15, b25, b35, b45, b55, b65, b75, b85,
                            b06, b16, b26, b36, b46, b56, b66, b76, b86, b07, b17, b27, b37, b47, b57, b67, b77, b87,
                            b08, b18, b28, b38, b48, b58, b68, b78, b88, b_menu;
        [UI] private Label LB_COMOVA, LB_NUMERO;

        private int _counter;

        //CONSTRUCTORES DEL FORM
        public sudoku() : this(new Builder("FR_SUDOKU.glade")) { }
        private sudoku(Builder builder) : base(builder.GetRawOwnedObject("FR_GAME"))
        {

            builder.Autoconnect(this);DeleteEvent += Window_DeleteEvent;
            
            this.KeyPressEvent += keypress;
            //ENCASQUETAR LOS 81 EVENTOS
            b00.Clicked += b00_Clicked;b10.Clicked += b10_Clicked; b20.Clicked += b20_Clicked;
            b30.Clicked += b30_Clicked;b40.Clicked += b40_Clicked; b50.Clicked += b50_Clicked;
            b60.Clicked += b60_Clicked;b70.Clicked += b70_Clicked; b80.Clicked += b80_Clicked;
            
            b01.Clicked += b01_Clicked;b11.Clicked += b11_Clicked; b21.Clicked += b21_Clicked;
            b31.Clicked += b31_Clicked;b41.Clicked += b41_Clicked; b51.Clicked += b51_Clicked;
            b61.Clicked += b61_Clicked;b71.Clicked += b71_Clicked; b81.Clicked += b81_Clicked;

            b02.Clicked += b02_Clicked;b12.Clicked += b12_Clicked; b22.Clicked += b22_Clicked;
            b32.Clicked += b32_Clicked;b42.Clicked += b42_Clicked; b52.Clicked += b52_Clicked;
            b62.Clicked += b62_Clicked;b72.Clicked += b72_Clicked; b82.Clicked += b82_Clicked;

            b03.Clicked += b03_Clicked;b13.Clicked += b13_Clicked; b23.Clicked += b23_Clicked;
            b33.Clicked += b33_Clicked;b43.Clicked += b43_Clicked; b53.Clicked += b53_Clicked;
            b63.Clicked += b63_Clicked;b73.Clicked += b73_Clicked; b83.Clicked += b83_Clicked;

            b04.Clicked += b04_Clicked;b14.Clicked += b14_Clicked; b24.Clicked += b24_Clicked;
            b34.Clicked += b34_Clicked;b44.Clicked += b44_Clicked; b54.Clicked += b54_Clicked;
            b64.Clicked += b64_Clicked;b74.Clicked += b74_Clicked; b84.Clicked += b84_Clicked;

            b05.Clicked += b05_Clicked;b15.Clicked += b15_Clicked; b25.Clicked += b25_Clicked;
            b35.Clicked += b35_Clicked;b45.Clicked += b45_Clicked; b55.Clicked += b55_Clicked;
            b65.Clicked += b65_Clicked;b75.Clicked += b75_Clicked; b85.Clicked += b85_Clicked;

            b06.Clicked += b06_Clicked;b16.Clicked += b16_Clicked; b26.Clicked += b26_Clicked;
            b36.Clicked += b36_Clicked;b46.Clicked += b46_Clicked; b56.Clicked += b56_Clicked;
            b66.Clicked += b66_Clicked;b76.Clicked += b76_Clicked; b86.Clicked += b86_Clicked;

            b07.Clicked += b07_Clicked;b17.Clicked += b17_Clicked; b27.Clicked += b27_Clicked;
            b37.Clicked += b37_Clicked;b47.Clicked += b47_Clicked; b57.Clicked += b57_Clicked;
            b67.Clicked += b67_Clicked;b77.Clicked += b77_Clicked; b87.Clicked += b87_Clicked;

            b08.Clicked += b08_Clicked;b18.Clicked += b18_Clicked; b28.Clicked += b28_Clicked;
            b38.Clicked += b38_Clicked;b48.Clicked += b48_Clicked; b58.Clicked += b58_Clicked;
            b68.Clicked += b68_Clicked;b78.Clicked += b78_Clicked; b88.Clicked += b88_Clicked;
            b_menu.Clicked += b_menu_Clicked;

            

            //CREAR OBJ DE SUDOKU
            
        }
        //CERRAR APP
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {Application.Quit();}

        //FUNCION CAMBIAR COLOR
        
        // [Obsolete]
        // private Button cambiarcolor(string c, Button btn)
        // {
        //     Gdk.Color color = new Gdk.Color();
        //     Gdk.Color.Parse(c, ref color);
        //     btn.ModifyBg(StateType.Normal, color);
        //     return btn;
        // }


        //FUNCIONES DE LOS 81 BOTONES :v con sus coordenadas del array
        private void b00_Clicked(object sender, EventArgs a){cambio(b00, 0 , 0);} private void b10_Clicked(object sender, EventArgs a){cambio(b10, 1 , 0);} private void b20_Clicked(object sender, EventArgs a){cambio(b20, 2 , 0);}
        private void b30_Clicked(object sender, EventArgs a){cambio(b30, 3 , 0);} private void b40_Clicked(object sender, EventArgs a){cambio(b40, 4 , 0);} private void b50_Clicked(object sender, EventArgs a){cambio(b50, 5 , 0);}
        private void b60_Clicked(object sender, EventArgs a){cambio(b60, 6 , 0);} private void b70_Clicked(object sender, EventArgs a){cambio(b70, 7 , 0);} private void b80_Clicked(object sender, EventArgs a){cambio(b80, 8 , 0);}

        private void b01_Clicked(object sender, EventArgs a){cambio(b01, 0 , 1);} private void b11_Clicked(object sender, EventArgs a){cambio(b11, 1 , 1);} private void b21_Clicked(object sender, EventArgs a){cambio(b21, 2 , 1);}
        private void b31_Clicked(object sender, EventArgs a){cambio(b31, 3 , 1);} private void b41_Clicked(object sender, EventArgs a){cambio(b41, 4 , 1);} private void b51_Clicked(object sender, EventArgs a){cambio(b51, 5 , 1);}
        private void b61_Clicked(object sender, EventArgs a){cambio(b61, 6 , 1);} private void b71_Clicked(object sender, EventArgs a){cambio(b71, 7 , 1);} private void b81_Clicked(object sender, EventArgs a){cambio(b81, 8 , 1);}

        //'pene

        private void b02_Clicked(object sender, EventArgs a){cambio(b02, 0 , 2);} private void b12_Clicked(object sender, EventArgs a){cambio(b12, 1 , 2);} private void b22_Clicked(object sender, EventArgs a){cambio(b22, 2 , 2);}
        private void b32_Clicked(object sender, EventArgs a){cambio(b32, 3 , 2);} private void b42_Clicked(object sender, EventArgs a){cambio(b42, 4 , 2);} private void b52_Clicked(object sender, EventArgs a){cambio(b52, 5 , 2);}
        private void b62_Clicked(object sender, EventArgs a){cambio(b62, 6 , 2);} private void b72_Clicked(object sender, EventArgs a){cambio(b72, 7 , 2);} private void b82_Clicked(object sender, EventArgs a){cambio(b82, 8 , 2);}

        private void b03_Clicked(object sender, EventArgs a){cambio(b03, 0 , 3);} private void b13_Clicked(object sender, EventArgs a){cambio(b13, 1 , 3);} private void b23_Clicked(object sender, EventArgs a){cambio(b23, 2 , 3);}
        private void b33_Clicked(object sender, EventArgs a){cambio(b33, 3 , 3);} private void b43_Clicked(object sender, EventArgs a){cambio(b43, 4 , 3);} private void b53_Clicked(object sender, EventArgs a){cambio(b53, 5 , 3);}
        private void b63_Clicked(object sender, EventArgs a){cambio(b63, 6 , 3);} private void b73_Clicked(object sender, EventArgs a){cambio(b73, 7 , 3);} private void b83_Clicked(object sender, EventArgs a){cambio(b83, 8 , 3);}

        private void b04_Clicked(object sender, EventArgs a){cambio(b04, 0 , 4);} private void b14_Clicked(object sender, EventArgs a){cambio(b14, 1 , 4);} private void b24_Clicked(object sender, EventArgs a){cambio(b24, 2 , 4);}
        private void b34_Clicked(object sender, EventArgs a){cambio(b34, 3 , 4);} private void b44_Clicked(object sender, EventArgs a){cambio(b44, 4 , 4);} private void b54_Clicked(object sender, EventArgs a){cambio(b54, 5 , 4);}
        private void b64_Clicked(object sender, EventArgs a){cambio(b64, 6 , 4);} private void b74_Clicked(object sender, EventArgs a){cambio(b74, 7 , 4);} private void b84_Clicked(object sender, EventArgs a){cambio(b84, 8 , 4);}

        private void b05_Clicked(object sender, EventArgs a){cambio(b05, 0 , 5);} private void b15_Clicked(object sender, EventArgs a){cambio(b15, 1 , 5);} private void b25_Clicked(object sender, EventArgs a){cambio(b25, 2 , 5);}
        private void b35_Clicked(object sender, EventArgs a){cambio(b35, 3 , 5);} private void b45_Clicked(object sender, EventArgs a){cambio(b45, 4 , 5);} private void b55_Clicked(object sender, EventArgs a){cambio(b55, 5 , 5);}
        private void b65_Clicked(object sender, EventArgs a){cambio(b65, 6 , 5);} private void b75_Clicked(object sender, EventArgs a){cambio(b75, 7 , 5);} private void b85_Clicked(object sender, EventArgs a){cambio(b85, 8 , 5);}

        private void b06_Clicked(object sender, EventArgs a){cambio(b06, 0 , 6);} private void b16_Clicked(object sender, EventArgs a){cambio(b16, 1 , 6);} private void b26_Clicked(object sender, EventArgs a){cambio(b26, 2 , 6);}
        private void b36_Clicked(object sender, EventArgs a){cambio(b36, 3 , 6);} private void b46_Clicked(object sender, EventArgs a){cambio(b46, 4 , 6);} private void b56_Clicked(object sender, EventArgs a){cambio(b56, 5 , 6);}
        private void b66_Clicked(object sender, EventArgs a){cambio(b66, 6 , 6);} private void b76_Clicked(object sender, EventArgs a){cambio(b76, 7 , 6);} private void b86_Clicked(object sender, EventArgs a){cambio(b86, 8 , 6);}

        private void b07_Clicked(object sender, EventArgs a){cambio(b07, 0 , 7);} private void b17_Clicked(object sender, EventArgs a){cambio(b17, 1 , 7);} private void b27_Clicked(object sender, EventArgs a){cambio(b27, 2 , 7);}
        private void b37_Clicked(object sender, EventArgs a){cambio(b37, 3 , 7);} private void b47_Clicked(object sender, EventArgs a){cambio(b47, 4 , 7);} private void b57_Clicked(object sender, EventArgs a){cambio(b57, 5 , 7);}
        private void b67_Clicked(object sender, EventArgs a){cambio(b67, 6 , 7);} private void b77_Clicked(object sender, EventArgs a){cambio(b77, 7 , 7);} private void b87_Clicked(object sender, EventArgs a){cambio(b87, 8 , 7);}

        private void b08_Clicked(object sender, EventArgs a){cambio(b08, 0 , 8);} private void b18_Clicked(object sender, EventArgs a){cambio(b18, 1 , 8);} private void b28_Clicked(object sender, EventArgs a){cambio(b28, 2 , 8);}
        private void b38_Clicked(object sender, EventArgs a){cambio(b38, 3 , 8);} private void b48_Clicked(object sender, EventArgs a){cambio(b48, 4 , 8);} private void b58_Clicked(object sender, EventArgs a){cambio(b58, 5 , 8);}
        private void b68_Clicked(object sender, EventArgs a){cambio(b68, 6 , 8);} private void b78_Clicked(object sender, EventArgs a){cambio(b78, 7 , 8);} private void b88_Clicked(object sender, EventArgs a){cambio(b88, 8 , 8);}



        private void b_menu_Clicked(object sender, EventArgs a)
        {mishicutre.Program.w_menu.Show();this.Destroy();}        
        private void keypress(object sender, KeyPressEventArgs a)
        {
            switch (a.Event.Key)
        {
            case Gdk.Key.Key_1:{num = "1";}break;
            case Gdk.Key.Key_2:{num = "2";}break;
            case Gdk.Key.Key_3:{num = "3";}break;
            case Gdk.Key.Key_4:{num = "4";}break;
            case Gdk.Key.Key_5:{num = "5";}break;
            case Gdk.Key.Key_6:{num = "6";}break;
            case Gdk.Key.Key_7:{num = "7";}break;
            case Gdk.Key.Key_8:{num = "8";}break;
            case Gdk.Key.Key_9:{num = "9";}break;
        }
        LB_NUMERO.Text = num;
        }
        //FUNCION PARA CAMBIAR LAS COSAS EN EL BOTON GENERICO Y EN EL ARRAY
        private void cambio(Button btn, int x, int y)
        {
            //LLAMAR UPDATE CON EL BOTON
            
            btn.Label = num;
            // num = " ";
            // btn.Label = Convert.ToString(update(btn.Label[0]));
            //CAMBIAR LA POSICION DEL ARRAY AL VALOR DEL BOTON
            grid[x][y] = btn.Label[0];
            //FUNC CHANGE(char[][] arr, Button btn, int x, int y)
            game._grid = grid;
            check(game._grid, ' ');
            if(game.IsValid())
            {//f.cajita("OK", this);
            LB_COMOVA.Text = "BIEN";
            //cambiarcolor("green", btn);
            }
            else
            {//f.cajita("MAL", this);
            LB_COMOVA.Text = "MAL";
            //cambiarcolor("red", btn);
            }
            if (game.IsValid() && completo == true)
            {
                f.cajita("HAS GANADO", this);
                LB_COMOVA.Text = "GANASTE";
                }
        }
        
        //CAMBIAR EL BOTON DEL 1 AL 9 O DEJARLO EN BLANCO
        private char update(char owo)
        {if (owo == ' '){return '1';}
        else if (owo == '9'){return ' ';}
        else {return(Convert.ToChar(Convert.ToInt32(owo)+1));}}
        void check(char[][] grd, char caracter)
        {

            bool encontrado = false;
            string xd = "";
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grd[i][j] == caracter){encontrado = true;
                    //f.cajita("PERAME MIJA", this);
                    break;}
                    xd += Convert.ToString(grd[i][j]);
                    y = j;
                }
                if (grd[i][y] == caracter){break;}
            }
            //f.cajita(xd, this);
            if (encontrado == false){completo = true;}
        }
    }
}
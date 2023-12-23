using System;
// using System.Linq;
// using NAudio;
// using MediaFoundation;
// using System.Threading;

namespace tictactoe
{
    public class tictactoe_src
    {
        int x = -1, y = -1;
        bool turno = true; char num = '1';
        int index = 1;
        char[][] grid = {
                new char[]{' ', ' ', ' '},
                new char[]{' ', ' ', ' '},
                new char[]{' ', ' ', ' '},
            };
        public char get_icon(){return num;}
        /*
        Diccionario status
        fin = fin de la partida
        winner= numero del jugador que la gano, 0 si aun no o empate
        linea= 0== horizontal 1==vertical 2==diagonal
        pos: posicion donde se pondra la linea
            horizontal: 0 = arriba 1 = mid 2= abajo _
            vertical: 0 = izq 1 = mid 2=der  |
            diagonal: 0 = de abajo pa arriba/ 1=de arriba a abajo\
        */
        (bool fin, char winner, int linea, int pos) status; 
        public bool terminado(){return status.fin;}
        public bool es_turno(){return turno;}
        
        public char elganador(){return status.winner;}
        public int vamosen(){return index;}
        private static tictactoe_src _inst;
        private tictactoe_src(){}
        public static tictactoe_src _actual()
        {if (_inst == null) _inst = new tictactoe_src(); return _inst;}
        public static tictactoe_src _newgame()
        {_inst = new tictactoe_src(); return _inst;}
        // public (bool, tictactoe_src) feed(char c, int x, int y)
        // {
        //     bool set = put_icon(c,x,y);
        //     return (set, this);
        // }
        // static void Main(String[] args)
        // {
        //     tictactoe_src _i = new tictactoe_src();
        //     _i.autoplay();
        //     if (_i.status.fin == true) Console.WriteLine("\n\nGana el Jugador " + _i.status.winner);
        //     else Console.WriteLine("EMPATE LOL" );

        // }

        private string input(string str){Console.WriteLine(str); return Console.ReadLine() + "";}
        private void printarray()
        {
            foreach (char[] cc in grid)
            {foreach(char c in cc)
            {Console.Write("\'"+c+"\',");}Console.Write("\n");}
        }
        private void cambiar_turno()
        {turno = !turno;if (turno) num = '1'; else num = '2';}
        public bool put_icon(char icon, int x, int y)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2)return false;
            if (grid[x][y] == '1' || grid[x][y] == '2') return false;
            else grid[x][y] =icon; cambiar_turno();check();index++;return true;
        }
        public void autoplay()
        {
            while (status.fin == false)
            {
                Console.WriteLine("Turno " + Convert.ToString(index)+ "\n\n");
                turno = !turno;
                // x = Convert.ToInt32(input("\nTurno del jugador "+num+"\n\nValor x 1-3"))-1;
                // y = Convert.ToInt32(input("Valor y 1-3"))-1;
                select_random(num);
                // if (put_icon(num, x, y) == false) {Console.WriteLine("Todo Mal \n");turno = !turno;}
                check();
                printarray();
                // Console.Write("\nPresione una tecla para continuar\n");
                // Thread.Sleep(500);
                // Console.ReadKey();
                index++;
                if (index == 10) break;
            }
        }
        private void select_random(char i)
        {Random r = new Random();while(put_icon(i, r.Next(1,4)-1, r.Next(1,4)-1) ==false);
        }
        
        private void check()
        {
            status = horizontal_check();
            if (status.fin == false) status=vertical_check();
            if (status.fin == false) status=diagonal_check();
        }
        private (bool, char, int, int) horizontal_check()
        {
           
           if (grid[1][0] == grid[0][0] && grid[2][0] == grid[0][0] && (grid[0][0] == '1' || grid[0][0] == '2')) return (true, grid[0][0], 0, 0);
           if (grid[1][1] == grid[0][1] && grid[2][1] == grid[0][1] && (grid[0][1] == '1' || grid[0][1] == '2')) return (true, grid[0][1], 0, 1);
           if (grid[1][2] == grid[0][2] && grid[2][2] == grid[0][2] && (grid[0][2] == '1' || grid[0][2] == '2')) return (true, grid[0][2], 0, 2);
           else return (false, ' ', 0, 0);
        }
        private (bool, char, int, int) vertical_check()
        {
           if (grid[0][1] == grid[0][0] && grid[0][2] == grid[0][0] && (grid[0][0] == '1' || grid[0][0] == '2')) return (true, grid[0][0], 1, 0);
           if (grid[1][1] == grid[1][0] && grid[1][2] == grid[1][0] && (grid[1][0] == '1' || grid[1][0] == '2')) return (true, grid[1][0], 1, 1);
           if (grid[2][1] == grid[2][0] && grid[2][2] == grid[2][0] && (grid[2][0] == '1' || grid[2][0] == '2')) return (true, grid[2][0], 1, 2);
           else return (false, ' ', 0, 0);
        }
        private (bool, char, int, int) diagonal_check()
        {
            if (grid[2][2] == grid[1][1] && grid[0][0] == grid[1][1] && (grid[1][1] == '1' || grid[1][1] == '2')) return (true, grid[1][1], 2, 0);
            if (grid[0][2] == grid[1][1] && grid[2][0] == grid[1][1] && (grid[1][1] == '1' || grid[1][1] == '2')) return (true, grid[1][1], 0, 1);
            else return (false, ' ',0,0);
        }
    }
}
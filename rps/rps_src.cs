using System;
using characters;
namespace rps
{
    public enum items
    {
        Piedra, Papel, Tijeras
    }
    public class rps
    {
        //TABLA QUE DETERMINA EL GANADOR
        //0 = piedra, 1 = Papel, 2 = Tijeras
        //en [][] 0 = empate, 1 gana P1, 2 gana P2
                                //P2
        public rps(int n)
        {
            this.u.rps = n;
            this.bot.rps = this.bot.select_rps();
            this.winner = comparar(u.rps-1, bot.rps-1);
        }
        public int[][] tabla={//0,1,2
                /*0*/new int[]{0,2,1},
            /* P1 1*/new int[]{1,0,2},
                /*2*/new int[]{2,1,0},
        };
        you u = chars.you;
        cpu bot = chars.bot;
        public int winner = 0;
        public rps()
        {game();}
        public void game()
        {
            while (iniciar()){Console.Clear();}
        }
        public bool iniciar()
        {
            u.rps = Convert.ToInt32(input("\n\n\nRPS\n\nElige una opcion\n\n\t1-Piedra\n\t2-Papel\n\t3-Tijeras\n\n>> "));
            if (u.rps >0 && u.rps <4)
            {
                bot.rps = bot.select_rps();
                Console.Clear();
                prt("\n" +u.rps);
                prt("\n" +bot.rps);
                prt("\n\nSeleccionaste "  + ((items)(u.rps-1)) + "\n\nEl oponente seleccionó " + ((items)(u.rps-1)) + "\n\n");
                winner = comparar(u.rps-1, bot.rps-1);
                switch (winner)
                {
                    case 1: {prt("Has ganado");}break;
                    case 2: {prt("Has perdido");}break;
                    case 0: {prt("Empate");}break;
                }
                Console.ReadKey();
                Console.Clear();
                switch (input("\nQuieres continuar?\n\n\t1-Si\n\t2-No\n\n>> "))
                {
                    case "1" : {return true;}//Do nothing lol
                    case "2" : {return false;}
                    default: {break;}
                }
            }
            else 
            {
                prt("\nTodo Mal :v");

            }
            return true;
        }
        public string input(string st){prt(st);  return Console.ReadLine();}
        public void prt(dynamic st){Console.Write(st);}

        //Compara lo que tienen en la mano los jugadores
        public int comparar(int e1, int e2)
        {
        return tabla[e1][e2];
        }
        

    }
}
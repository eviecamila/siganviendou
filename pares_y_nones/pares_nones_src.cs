using System;

namespace pares_y_nones
{
    public class pares_nones_src
    {
        public (int you, int cpu, int pon) stats;
        private static pares_nones_src _inst;
        private pares_nones_src()
        {}
        private pares_nones_src(int number, int pon)
        {
            stats.you = number;
            stats.cpu = select_random(2);
            stats.pon = pon;
        }
        public static pares_nones_src newgame(int number, int pon)
        {_inst = new pares_nones_src(number, pon); return _inst;}


        //si el residuo de las 2 manos es igual a lo que elegiste, ganaste, si no, return 0 lol
        public bool ganaste(){if((stats.you + stats.cpu) % 2 == stats.pon) return true; return false;}

        //pruebas que hice en consola para depurarlo :v


        // static void Main(String[] args)
        // {
        //     pares_nones_src _i = new pares_nones_src();
        //     Console.WriteLine("Elige pares o nones\n0-Pares\n1-Nones");
        //     int game = Convert.ToInt32(Console.ReadLine());
        //     Console.WriteLine("elige un numero del 0 al 2");
        //     int player = Convert.ToInt32(Console.ReadLine());
        //     int bot = _i.select_random();
        //     Console.WriteLine("Tu: " + _i.str(player) + "\nCPU: " + _i.str(bot) + "\nTotal:" + _i.str(player+bot) + "\n");
        //     if ((player+bot)%2== game) Console.WriteLine("Has ganado");
        //     else Console.WriteLine("Te chingaste pa");
        // }
        
        private string input(string str){Console.WriteLine(str); return Console.ReadLine() + "";}
        private int select_random(int max)
        {
            Random r = new Random();
            return r.Next(1,max+1)-1;
        }
        
        
    }
}
using System;
namespace characters
{
    public class chars
    {
        public static you you =  you.get_inst();
        public static cpu bot = cpu.get_inst();
    }
    public class player
    {
        public int wins, loss, tie;
        public int rps=-1;
        public virtual int select_rps(){return -1;}
        public virtual int select_rps(int n){return -1;}
    }
    public class you : player
    {
        private you(){}
        private static you _instance;

        public static you get_inst()
        {
            if (_instance == null) _instance = new you();
            return _instance;
        }
        // public string select_rps(){return dardato;}
        public override int select_rps(int num){return num;}
        // public string dardato(string s){return rps.input(s);}
    }
    public class cpu : player
    {
        private cpu(){}
        private static cpu _instance;
        
        public static cpu get_inst()
        {
            if (_instance == null) _instance = new cpu();
            return _instance;
        }

        //Funcion que selecciona del 0 al 2
        public override int select_rps()
        {Random r = new Random(); return (r.Next(1, 4));}
        
    }
}
using System;
using Gtk;
using System.Threading;
using rps;
namespace mishicutre
{
    public class user
    {
        public static user obj;
        public string id, name;
        public user(string id, string name){this.id = id;this.name = name;}
        public static user _i(string id, string name)
        {obj = new user(id, name); return obj;}
        public static user _i(){return obj;}


    }
}
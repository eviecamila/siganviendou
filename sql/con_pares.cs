using System;
using System.Data.SqlClient;
// using System.Data;
using funciones;
namespace con
{
    public class pares : mishicutre.conexion
    {
        //Guardar datos
        public static void save(string value, string id)
        {
            _conexion.Open();
            SqlCommand cmd = new SqlCommand("update pairs set wins = '" + value + "' where id = '" + id + "'", _conexion);
            cmd.ExecuteNonQuery();
            _conexion.Close();
        }

        //cargar datos
        public static string load(string id)
        {string val = (buscar_where_x_e_y("pairs", id, "id", "wins"));
        if (val == "null"){newreg(id); return "0";}
        return val;
        }

        //registrar usuario nuevo
        public static void newreg(string id)
        {   
            _conexion.Open();
            SqlCommand cmd = execute("insert into pairs values ('" +id + "', '0')");
            _conexion.Close();
        }

        //borrar wins totales
        public void reset(string player)
        {
            _conexion.Open();
            SqlCommand cmd = execute("update pairs set wins = '0' where id = '" + player + "'");
            _conexion.Close();
        }
    }
}
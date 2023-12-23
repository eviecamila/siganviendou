using System;
using System.Data.SqlClient;
// using System.Data;

namespace mishicutre
{   
    public class conexion
    {
        private static conexion obj;
        protected conexion(){}
        public static conexion get_inst()
        {
            if (obj == null) {obj  = new conexion();} //al pedir instancia se creara si o si solo una
            return obj; //creado o no, return
        }
        public static SqlConnection _conexion = new SqlConnection("Data Source=localhost; Initial Catalog=game; User Id=sa;Password=Daisy789;");

        public static string buscar_where_x_e_y(string tabla, string valor, string col, string rcol)
        {
            _conexion.Open();
            SqlCommand cmdConsultar = execute("select * from " + tabla + " where "+col+ " = '"+ valor + "'");                    
            SqlDataReader rdr = cmdConsultar.ExecuteReader();
                    string sql = "";
                    //comprobar si hay datos, entonces mostrar la descripcion del producto                    
                    if(rdr.HasRows) //si hubo datos, entonces mostrar la descripcion del producto                    
                        while(rdr.Read())            
                            sql = (rdr[rcol].ToString());                
                    else sql ="null";
                rdr.Close();
                _conexion.Close();   
                    return sql ;             
        }
        public static SqlCommand execute(string instruccion)
        {   SqlCommand cmd = new SqlCommand(instruccion, _conexion);
            cmd.ExecuteNonQuery();return cmd;
        }
        //Funcion que regresa el valor maximo de una columna en una tabla
        public string get_max(string tabla, string row)
        {
            SqlCommand cmd = execute("select max("+row+") r from "+tabla + "t");

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()){return String.Format("{0}",reader["r"]);}
                return "ERROR";
            }
        }
        public void get_table(string t)
        {
            SqlCommand cmd = execute("select * from " +t);
            Console.ReadKey();
        }

        //Funcion que crea un usuario
        public void crear_usuario(string name)
        {
            int a = Int32.Parse(get_max("id", "users"));
            Console.WriteLine(a);

            //SqlCommand cmd = new SqlCommand(, con);
            //cmd.ExecuteNonQuery();
        }
    }
}
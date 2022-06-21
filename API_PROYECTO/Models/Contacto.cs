using MySql.Data.MySqlClient;
using System.Data;

namespace API_PROYECTO.Models
{
    public class Contacto
    {
        public int id_contacto { get; set; }
        public int id_persona { get; set; }
        public int correo { get; set; }
        public int puesto { get; set; }

        string connectionString = "Server=localhost;Database=casos_legales;Uid=root;Pwd=123456;convert zero datetime=True;";

        public DataTable Obtener_Contactos_Tabla()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand sql = new MySqlCommand("SELECT * FROM contactos JOIN personas WHERE contactos.ID_PERSONA = personas.ID_PERSONA;", con);

            dt.Load(sql.ExecuteReader());
            con.Close();
            return dt;
        }

    }
}

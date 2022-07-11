using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Sistema
    {

        public string connection = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";


        public void registraNuovoUtente(Utente nuovoUtente)
        {

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO user (name, surname, email, password) VALUES (@name, @surname, @email, @password)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@name", nuovoUtente.nome));
                    cmd.Parameters.Add(new SqlParameter("@surname", nuovoUtente.cognome));
                    cmd.Parameters.Add(new SqlParameter("@email", nuovoUtente.email));
                    cmd.Parameters.Add(new SqlParameter("@password", nuovoUtente.password));

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine("Registrazione effettuata correttamente");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }

}
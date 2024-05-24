using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrattoriaGreta.Modelli;

namespace TrattoriaGreta
{
    internal class Db
    {
        private SqlConnection GetConnection()
        {
            var connenctionString = "Server=GRETA-DESKTOP\\SQLEXPRESS;Database=TrattoriaGreta;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connenctionString);
            connection.Open();
            return connection;
        }

        ////Lettura Menu
        
        ///

       public MenuPortata ReadMenu()
        {
            var menu = new MenuPortata();
            var connection = GetConnection();
            SqlDataReader sqlDataReader = null;

            try
            {
                menu.Menu = new Menu();
                menu.Portate = new List<Portata>();

                SqlCommand cmd = new SqlCommand(Resource1.ReadMenu, connection);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var portata = new Portata();
                    menu.Id = sqlDataReader.GetInt32(0);
                    menu.Menu.Descrizione= sqlDataReader.GetString(1);

                    portata.NomePiatto= sqlDataReader.GetString(6);
                    portata.Prezzo=sqlDataReader.GetDecimal(7);
                   //// portata.IdTipologiaPiatto=sqlDataReader.GetInt32(8);

                    menu.Portate.Add(portata);

                }
                connection.Close();
                return menu;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        ///CreaOrdine 
        public void CreaOrdine(string menu, decimal totale) 
        {
            var connection = GetConnection();
            try
            {
                var cmd = new SqlCommand(Resource1.CreaOrdine, connection);
                cmd.Parameters.AddWithValue("@menu", menu);
                cmd.Parameters.AddWithValue("@totale", totale);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}

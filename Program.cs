using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrattoriaGreta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Db db = new Db();
            var returnDati = db.ReadMenu();

            Console.WriteLine("Ecco il menu di oggi!");
            var stampaDati = string.Empty;
            stampaDati += $"Menu: {returnDati.Menu.Descrizione}\n";
            foreach (var item in returnDati.Portate)

            {

                stampaDati = string.Empty;
                stampaDati += $"Piatto: {item.NomePiatto} - {item.Prezzo}\n";
              
            


                Console.WriteLine(stampaDati);
                // Add an empty line for clarity between objects
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Settings
{
    //Classe para armazenar a strong de conexão com o banco de dados.
    public class SqlServerSettings
    {
        //Método para retornar a string de conexão com o banco de dados.
        public static string GetConnectionString()
        {
            //return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDContasApp;";
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDContasApp;";
        }
    }
}

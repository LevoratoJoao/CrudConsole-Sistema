using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CrudConsoleAluno
{
    class Connection
    {
        static string ConexaoString = "DATA SOURCE=JOAOVITOR; INITIAL CATALOG=PROVA; Trusted_Connection=True";

        private static SqlConnection con;

        public SqlConnection Conectar()
        {
            con = new SqlConnection(ConexaoString);

            try
            {
                con.Open();
                Console.WriteLine("Conexão realizada com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao tentar conectar com o banco " + e);
            }
            return con;
        }

        public void Fechar()
        {
            con = new SqlConnection(ConexaoString);

            try
            {
                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao conectar no banco..." + e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleAluno
{
    class Curso
    {
        

        public void InserirCurso(SqlConnection con, int id, string nome, int periodo, double valor)
        {

            SqlCommand cmd = new SqlCommand();
            string query = "INSERT INTO CURSO VALUES (@IDCURSO, @DESCRICAO, @PERIODO, @VALOR)";

            cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", id));
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", nome));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", periodo));
                cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Curso cadastrado com sucesso!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao cadastrar curso " + e.Message);
            }
        }

        public void AlterarCurso(SqlConnection con, string nome, int periodo, double valor, int id)
        {
            string query = "UPDATE CURSO SET\nDESCRICAO = @DESCRICAO,\nPERIODO = @PERIODO,\nVALOR = @VALOR WHERE IDCURSO = @IDCURSO";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", nome));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", periodo));
                cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", id));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Curso alterado com sucesso");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao tentar alterar curso " + e.Message);
            }
        }

        public DadosCurso ConsultarCurso(SqlConnection con, int id, DadosCurso curso)
        {
            string query = "SELECT * FROM CURSO WHERE IDCURSO = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                
                if(reader.Read())
                {
                    curso.SetIdCurso(int.Parse(reader[0].ToString()));
                    curso.SetDescCurso(reader[1].ToString());
                    curso.SetDuracaoCurso(int.Parse(reader[2].ToString()));
                    curso.SetValorCurso(double.Parse(reader[3].ToString()));
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao consultar produto " + e.Message);
            }
            return curso;
        }

        public void ExcluirCurso(SqlConnection con, int id)
        {
            string query = "DELETE FROM CURSO WHERE IDCURSO = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int ret = cmd.ExecuteNonQuery();

            if(ret==0)
            {
                Console.WriteLine("Curso não encontrado");
            }
            else
            {
                Console.WriteLine("Produto excluido com sucesso");
            }
        }
    }
}

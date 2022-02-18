using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleAluno
{
    class Aluno
    {
        
        public void Matricula(SqlConnection con, int mat, string nome, string cpf, string email, string telefone, string cidade, string uf, int idcurso)
        {
            SqlCommand cmd = new SqlCommand();
            
            string query = "INSERT INTO ALUNO VALUES (@MAT, @NOME, @CPF, @EMAIL, @TELEFONE, @CIDADE, @UF, @IDCURSO)";
            cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@MAT", mat));
                cmd.Parameters.Add(new SqlParameter("@NOME", nome));
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", email));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", telefone));
                cmd.Parameters.Add(new SqlParameter("@CIDADE", cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", uf));
                cmd.Parameters.Add(new SqlParameter("IDCURSO", idcurso));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Matrícula registrada com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao registrar matrícula " + e.Message);
            }
        }

        public void AlterarMatricula(SqlConnection con, string nome, string cpf, string email, string telefone, string cidade, string uf, int idcurso, int mat)
        {
            string query = "UPDATE ALUNO SET\nNOME = @NOME,\nCPF = @CPF,\nEMAIL = @EMAIL,\nTELEFONE = @TELEFONE,\nCIDADE = @CIDADE,\nUF = @UF,\nIDCURSO = @IDCURSO WHERE MAT = @MAT";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.Add(new SqlParameter("@NOME", nome));
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", email));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", telefone));
                cmd.Parameters.Add(new SqlParameter("@CIDADE", cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", uf));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", idcurso));
                cmd.Parameters.Add(new SqlParameter("@MAT", mat));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Matrícula alterada com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao alterar matrícula " + e.Message);
            }
        }
        public DadosAluno ConsultarMatricula(SqlConnection con, int mat, DadosAluno matricula)
        {
            string query = "SELECT * FROM ALUNO WHERE MAT = '" + mat + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    matricula.SetMat(int.Parse((reader[0].ToString())));
                    matricula.SetNome(reader[1].ToString());
                    matricula.SetCPF(reader[2].ToString());
                    matricula.SetEmail(reader[3].ToString());
                    matricula.SetTelefone(reader[4].ToString());
                    matricula.SetCidade(reader[5].ToString());
                    matricula.SetUf(reader[6].ToString());
                    matricula.SetIdCurso(int.Parse(reader[7].ToString()));
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao consultar matrícula " + e.Message);
            }
            return matricula;
        }
        public void ExcluirMatricula(SqlConnection con, int mat)
        {
            string query = "DELETE FROM ALUNO WHERE MAT = '" + mat + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(query, con);
            int ret = cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                Console.WriteLine("Matrícula não encontrada");
            }
            else
            {
                Console.WriteLine("Matrícula excluida com sucesso!!!");
            }

        }

    }
}

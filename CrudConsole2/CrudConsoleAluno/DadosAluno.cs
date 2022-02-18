using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleAluno
{
    class DadosAluno
    {
        private int Mat;
        private string nome;
        private string cpf;
        private string email;
        private string telefone;
        private string cidade;
        private string uf;
        private int idcurso;

        public void SetMat(int Mat)
        {
            this.Mat = Mat;
        }
        public int GetMat()
        {
            return this.Mat;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public string GetNome()
        {
            return this.nome;
        }

        public void SetCPF(string cpf)
        {
            this.cpf = cpf;
        }
        public string GetCPF()
        {
            return this.cpf;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return this.email;
        }

        public void SetTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public string GetTelefone()
        {
            return telefone;
        }

        public void SetCidade(string cidade)
        {
            this.cidade = cidade;
        }
        public string GetCidade()
        {
            return this.cidade;
        }

        public void SetUf(string uf)
        {
            this.uf = uf;
        }
        public string GetUf()
        {
            return this.uf;
        }

        public void SetIdCurso(int idcurso)
        {
            this.idcurso = idcurso;
        }
        public int GetIdCurso()
        {
            return this.idcurso;
        }
    }
}

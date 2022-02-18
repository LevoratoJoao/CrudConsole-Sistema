using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleAluno
{
    class DadosCurso
    {
        private int IdCurso;
        private string descCurso;
        private int duracaoCurso;
        private double valorCurso;

        public void SetIdCurso(int IdCurso)
        {
            this.IdCurso = IdCurso;
        }
        public int GetIdCurso()
        {
            return this.IdCurso;
        }

        public void SetDescCurso(string descCurso)
        {
            this.descCurso = descCurso;
        }
        public string GetDescCurso()
        {
            return this.descCurso;
        }

        public void SetDuracaoCurso(int duracaoCurso)
        {
            this.duracaoCurso = duracaoCurso;
        }
        public int GetDuracaoCurso()
        {
            return this.duracaoCurso;
        }

        public void SetValorCurso(double valorCurso)
        {
            this.valorCurso = valorCurso;
        }
        public double GetValorCurso()
        {
            return this.valorCurso;
        }
    }
}

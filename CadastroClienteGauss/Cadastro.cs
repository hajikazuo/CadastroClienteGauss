using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteGauss
{
    public class Cadastro
    {
        public int CadastroId { get; set; }
        public TipoSetor Setor { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
    }
}

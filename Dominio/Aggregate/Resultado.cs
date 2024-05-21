using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ValueObject;

namespace Dominio.Aggregate
{
    public class Resultado
    {
        public bool Ok { get; set; }
        public IList<NumeroDivisor> divisores { get; set; }
        public string Erro { get; set; }

        public Resultado()
        {
            divisores = new List<NumeroDivisor>();
        }
    }
}

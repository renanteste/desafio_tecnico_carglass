using Dominio.Aggregate;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repository
{
    public interface ICalculoService
    {
        Resultado CalcularDivisor(NumeroDivisor divisor);
    }

}

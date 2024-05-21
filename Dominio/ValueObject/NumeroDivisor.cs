using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    public class NumeroDivisor
    {
        public long numero { get; set; }
        public bool isPrimo { get; set; }

        public NumeroDivisor(long numeroDivisor)
        {
            this.numero = numeroDivisor;
            this.isPrimo = false;
        }

        public bool Validar()
        {
            if (this.numero == 0) throw new Exception("Divisão por 0");
            if (this.numero < 0) throw new Exception("Apenas numeros inteiros positivos");
            return true;
        }

        public bool IsPrimo() {
            this.isPrimo = true;
            for (int divisor = 2; divisor <= Math.Sqrt(this.numero); divisor++) {
                if (this.numero % divisor == 0) {
                    this.isPrimo = false; break; }
            }
            return this.isPrimo;
        }

        public Boolean IsDivisor(long numeroDividendo) => (this.numero % numeroDividendo == 0);
    }
}

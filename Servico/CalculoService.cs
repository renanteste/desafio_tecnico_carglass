using Dominio.Aggregate;
using Dominio.ValueObject;
using Dominio.Repository;
using global::Servico;
using System;
using System.Collections.Generic;


namespace Servico
{
    public class CalculoService : ICalculoService
    {
        public Resultado CalcularDivisor(NumeroDivisor divisor)
        {
            Resultado response = new Resultado();
            try
            {
                divisor.Validar();

                for (long i = 1; i <= divisor.numero; i++)
                {
                    if (divisor.IsDivisor(i))
                    {
                        NumeroDivisor _n = new NumeroDivisor(i);
                        _n.isPrimo = _n.IsPrimo();
                        response.divisores.Add(_n);
                    }
                }

                response.Ok = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Erro = ex.Message;
                response.Ok = false;

                return response;
            }
        }
    }
}

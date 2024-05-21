using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dominio.ValueObject;
using Dominio.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dominio.Aggregate;
using Servico;

namespace api.Controllers
{
    [Route("api/calculos")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoService _calculoService;
        private NumeroDivisor _numeroDivisor;


        public CalculoController()
        {
            _calculoService = new CalculoService();
        }

        [HttpGet("divisoresEPrimos")]
        public ActionResult<Resultado> PrimosEDivisores(long numero)
        {
            _numeroDivisor = new NumeroDivisor(numero);

            var result = _calculoService.CalcularDivisor(_numeroDivisor);

            if (result.Ok)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Erro);
            }
        }

        [HttpGet("divisores")]
        public ActionResult<List<long>> Divisores(long numero)
        {
            _numeroDivisor = new NumeroDivisor(numero);

            var result = _calculoService.CalcularDivisor(_numeroDivisor);

            if (result.Ok)
            {
                return Ok(result.divisores.Select(x => x.numero).ToList());
            }
            else
            {
                return BadRequest(result.Erro);
            }
        }

        [HttpGet("primos")]
        public ActionResult<List<long>> Primos(long numero)
        {
            _numeroDivisor = new NumeroDivisor(numero);

            var result = _calculoService.CalcularDivisor(_numeroDivisor);

            if (result.Ok)
            {
                return Ok(result.divisores.Where(y => y.isPrimo == true).Select(x => x.numero).ToList());
            }
            else
            {
                return BadRequest(result.Erro);
            }
        }

    }
}

using Dominio.Aggregate;
using Dominio.Repository;
using Dominio.ValueObject;
using Servico;

namespace Testes
{
    public class UnitTest1
    {

        [Fact]
        public void DeveRetornarErroNumeroInvalido()
        {
            ICalculoService _calculoService = new CalculoService();
            NumeroDivisor divisor = new NumeroDivisor(0);

            //Act
            var result = _calculoService.CalcularDivisor(divisor);

            //Assert
            Assert.False(result.Ok);
            Assert.Equal("Divisão por 0", result.Erro);
            Assert.Equal(0, result.divisores.Count);
        }


        [Fact]
        public void DeveRetornarErroNumeroNegativo()
        {
            ICalculoService _calculoService = new CalculoService();
            NumeroDivisor divisor = new NumeroDivisor(-1);

            //Act
            var result = _calculoService.CalcularDivisor(divisor);

            //Assert
            Assert.False(result.Ok);
            Assert.Equal("Apenas numeros inteiros positivos", result.Erro);
            Assert.True(divisor.numero < 0);
        }

        [Fact]
        public void TestRetornaDivisoresSucesso()
        {
            ICalculoService _calculoService = new CalculoService();
            NumeroDivisor divisor = new NumeroDivisor(10);

            var listaEsperada = new List<long> { 1, 2, 5, 10 };

            Resultado result = _calculoService.CalcularDivisor(divisor);

            var listaDivisores = result.divisores.Select(x => x.numero).ToList();

            //Test
            Assert.True(result.Ok);
            Assert.Null(result.Erro);
            Assert.Equal(listaEsperada, listaDivisores);
        }

        [Fact]
        public void TestRetornaDivisoresPrimoSucesso()
        {
            ICalculoService _calculoService = new CalculoService();
            NumeroDivisor divisor = new NumeroDivisor(10);

            var listaEsperada = new List<long> { 1, 2, 5 };

            Resultado result = _calculoService.CalcularDivisor(divisor);

            var listaDivisoresPrimo = result.divisores.Where(y => y.isPrimo == true).Select(x => x.numero).ToList();

            //Test
            Assert.True(result.Ok);
            Assert.Null(result.Erro);
            Assert.Equal(listaEsperada, listaDivisoresPrimo);
        }

        

    }
}
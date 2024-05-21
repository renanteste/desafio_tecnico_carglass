using Dominio.Aggregate;
using Dominio.Repository;
using Dominio.ValueObject;
using Servico;

namespace technical.challenge.console
{
    public class Program
    {
        private static ICalculoService _calculoService;
        private static NumeroDivisor _numeroDivisor;

        public static void Main(string[] args)
        {
            _calculoService = new CalculoService();
            ExecutaCalculosDivisao();
        }

        public static void ExecutaCalculosDivisao() {
            Console.Clear();
            Console.Write("\r\nDigite uma opçao desejada: ");
            Console.WriteLine("\r\nOpções:");
            Console.WriteLine("1 - Exibir divisores de um número");
            Console.WriteLine("2 - Exibir numeros primos divisores de um número");
            Console.WriteLine("3 - Exibir ambos (divisores e primos)");
            Console.WriteLine("4 - Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine($"\r\nVocê selecionou 'Exibir divisores de um número'");
                    CalcularRetornaDivisores();
                    return;
                case "2":
                    Console.WriteLine($"\r\nVocê selecionou 'Exibir numeros primos divisores de um número'.");
                    CalcularRetornaDivisoresPrimos();
                    return;
                case "3":
                    Console.WriteLine($"\r\nVocê selecionou 'Exibir ambos (divisores e primos)'.");
                    CalcularRetornaDivisoresEPrimos();
                    return;
                case "4":
                    System.Environment.Exit(0);
                    return;
                default:
                    RetornarProcesso();
                    break;
            }
        }

        public static void RetornarProcesso()
        {
            Console.WriteLine("\n\n Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadLine();
            ExecutaCalculosDivisao();
        }

        public static NumeroDivisor GetNumeroDividendo()
        {
            try
            {
                Console.Write("\r\nDigite o número para executar a divisão: ");
                string input = Console.ReadLine();

                bool isNumber = long.TryParse(input, out var valor);
                if(!isNumber) throw new Exception("Caracter inválido");

                _numeroDivisor = new NumeroDivisor(valor);
                _numeroDivisor.Validar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                RetornarProcesso();
            }
            return _numeroDivisor;
        }


        public static IList<NumeroDivisor> RetonaDivisores()
        {
            var result = _calculoService.CalcularDivisor(GetNumeroDividendo());
            return result.divisores;
        }


        public static void CalcularRetornaDivisores()
        {
            IList<NumeroDivisor> divisores = RetonaDivisores();
            long[] res = divisores.Select(x => x.numero).ToArray();

            string result = string.Join(", ", res.Select(x => x.ToString()));

            Console.WriteLine($"Numeros divisores: {result}");

            RetornarProcesso();
        }

        public static void CalcularRetornaDivisoresPrimos()
        {
            IList<NumeroDivisor> divisores = RetonaDivisores();
            long[] res = divisores.Where(y => y.isPrimo == true).Select(x => x.numero).ToArray();

            string result = string.Join(", ", res.Select(x => x.ToString()));

            Console.WriteLine($"Numeros divisores: {result}");

            RetornarProcesso();
        }

        public static void CalcularRetornaDivisoresEPrimos()
        {
            IList<NumeroDivisor> divisores = RetonaDivisores();
            long[] res = divisores.Select(x => x.numero).ToArray();
            long[] resPrimos = divisores.Where(y => y.isPrimo == true).Select(x => x.numero).ToArray();

            string result = string.Join(", ", res.Select(x => x.ToString()));
            string resultPrimos = string.Join(", ", resPrimos.Select(x => x.ToString()));

            Console.WriteLine($"Numeros divisores: {result}");
            Console.WriteLine($"Numeros Primos: {resultPrimos}");

            RetornarProcesso();
        }


    }
}

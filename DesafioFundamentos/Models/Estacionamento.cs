using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string veiculo = string.Empty;
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculo = Console.ReadLine();

            veiculo = veiculo.Replace(" ", "");
            if (string.IsNullOrEmpty(veiculo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor digite algo");
                Console.ResetColor();
            }
            else if (ValidarPlaca(veiculo) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor digitar uma placa válida no formato XXX-1234 \nApenas letras maúsculas e números");
                Console.ResetColor();
            }
            else if (veiculos.Any(x => x == veiculo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veículo já cadastrado.");
                Console.ResetColor();
            }
            else
            {
                veiculos.Add(veiculo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Veículo adicionado com sucesso!");
                Console.ResetColor();
            }
        }

        static bool ValidarPlaca(string veiculo)
        {
            string validacaoPlaca = @"[A-Z]{3}[-][0-9]{4}";
            Regex regex = new Regex(validacaoPlaca);
            return regex.IsMatch(veiculo);
        }
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();


            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string horas = string.Empty;
                decimal valorTotal = 0;
                horas = Console.ReadLine();
                if (Convert.ToInt32(horas) > 0)
                {
                    valorTotal = precoInicial + (Convert.ToInt32(horas) * precoPorHora);
                }
                bool removido = veiculos.Remove(placa);
                if (removido == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Console.ResetColor();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {veiculos[i]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não há veículos estacionados.");
                Console.ResetColor();
            }
        }
    }
}

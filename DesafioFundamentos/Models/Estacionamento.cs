using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Carro> listaVeiculos = new List<Carro>();

        public class Carro
        {
            public string Placa { get; set; }
            public DateTime HoraEntrada { get; set; }

        }
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            var veiculo = new Carro();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculo.Placa = Console.ReadLine();

            veiculo.Placa = veiculo.Placa.Replace(" ", "");
            if (string.IsNullOrEmpty(veiculo.Placa))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor digite algo");
                Console.ResetColor();
            }
            else if (!ValidarPlaca(veiculo.Placa))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor digitar uma placa válida no formato XXX-1234 \nApenas letras maúsculas e números");
                Console.ResetColor();
            }
            else if (listaVeiculos.Any(x => x.Placa.ToUpper() == veiculo.Placa.ToUpper()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veículo já cadastrado.");
                Console.ResetColor();
            }
            else
            {
                veiculo.HoraEntrada = DateTime.Now;
                listaVeiculos.Add(veiculo);

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
            string placa = Console.ReadLine() ?? string.Empty;
            Carro veiculo = listaVeiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());


            if (veiculo != null)
            {
                DateTime horaAtual = DateTime.Now;
                TimeSpan tempoEstacionado = horaAtual - veiculo.HoraEntrada;

                double horasEstacionada = Math.Ceiling(tempoEstacionado.TotalHours);

                decimal valorTotal = precoInicial;

 
                if (horasEstacionada > 1)
                {
                    valorTotal += (decimal)(horasEstacionada - 1) * precoPorHora;
                }
                
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}. Tempo estacionado: {FormatarTempo(tempoEstacionado)}");
                Console.ResetColor();

                listaVeiculos.Remove(veiculo);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Console.ResetColor();
            }
        }

        private string FormatarTempo (TimeSpan tempo)
        {
            return $"{tempo.Hours:D2}:{tempo.Minutes:D2}:{tempo.Seconds:D2}";
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (listaVeiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < listaVeiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listaVeiculos[i].Placa}");
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

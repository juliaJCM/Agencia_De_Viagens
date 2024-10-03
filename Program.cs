using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    class Program
    {
        static void Main(string[] args)
        {
            // aeroportos
            Aeroporto aeroportoSP = new Aeroporto("Aeroporto Internacional de Guarulhos", "GRU", "São Paulo", "SP", "Brasil");
            Aeroporto aeroportoNY = new Aeroporto("John F. Kennedy International Airport", "JFK", "Nova York", "NY", "EUA");
            Aeroporto aeroportoLondres = new Aeroporto("Heathrow Airport", "LHR", "Londres", "LDN", "Reino Unido");

            // companhias aéreas
            CiaAerea latam = new CiaAerea("LATAM Airlines", 1001, "LATAM Linhas Aéreas S/A", "00.000.000/0001-00", 50.0, 100.0);
            CiaAerea americanAirlines = new CiaAerea("American Airlines", 1002, "American Airlines Inc.", "11.111.111/0001-11", 60.0, 120.0);

            Voo vooSPNY = new Voo("Voo SP-NY", Voo.GerarCodigoRota(), new List<CiaAerea> { latam },
                                  new List<Aeroporto> { aeroportoSP }, new List<Aeroporto> { aeroportoNY },
                                  new List<string> { "Segunda", "Quarta", "Sexta" },
                                  new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0),
                                  "EUA", 1000, 1500, 2000, "BRL");

            Voo vooNYLondres = new Voo("Voo NY-Londres", Voo.GerarCodigoRota(), new List<CiaAerea> { americanAirlines },
                                       new List<Aeroporto> { aeroportoNY }, new List<Aeroporto> { aeroportoLondres },
                                       new List<string> { "Terça", "Quinta" },
                                       new TimeSpan(20, 0, 0), new TimeSpan(8, 0, 0),
                                       "Reino Unido", 1200, 1700, 2200, "USD");

            Voo vooNYSP = new Voo("Voo NY-SP", Voo.GerarCodigoRota(), new List<CiaAerea> { latam },
                                    new List<Aeroporto> { aeroportoNY }, new List<Aeroporto> { aeroportoSP },
                                    new List<string> { "Sexta" },
                                    new TimeSpan(20, 0, 0), new TimeSpan(8, 0, 0),
                                    "Brasil", 1000, 1500, 2000, "USD");

            List<Voo> listaVoos = new List<Voo> { vooSPNY, vooNYLondres, vooNYSP };

            Console.WriteLine("\nDigite o código do aeroporto de origem (GRU, JFK, LHR):");
            string codigoOrigem = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o código do aeroporto de destino (GRU, JFK, LHR):");
            string codigoDestino = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite a data da viagem de ida (dd/mm/yyyy):");
            DateTime dataIda;
            while (!DateTime.TryParse(Console.ReadLine(), out dataIda))
            {
                Console.WriteLine("Data inválida. Por favor, insira novamente (dd/mm/yyyy):");
            }

            Console.WriteLine("Deseja pesquisar por um voo de volta? (s/n):");
            string resposta = Console.ReadLine().ToLower();

            DateTime? dataVolta = null;
            if (resposta == "s")
            {
                Console.WriteLine("Digite a data da viagem de volta (dd/mm/yyyy):");
                DateTime dataTemp;
                while (!DateTime.TryParse(Console.ReadLine(), out dataTemp))
                {
                    Console.WriteLine("Data inválida. Por favor, insira novamente (dd/mm/yyyy):");
                }
                dataVolta = dataTemp;
            }

            Aeroporto origem = listaVoos.SelectMany(v => v.AeroportosOrigem).FirstOrDefault(a => a.Sigla.Equals(codigoOrigem, StringComparison.OrdinalIgnoreCase));
            Aeroporto destino = listaVoos.SelectMany(v => v.AeroportosDestino).FirstOrDefault(a => a.Sigla.Equals(codigoDestino, StringComparison.OrdinalIgnoreCase));

            if (origem == null || destino == null)
            {
                Console.WriteLine("Aeroporto de origem ou destino inválido.");
                return;
            }

            Console.WriteLine($"\nPesquisando voos de {origem.Nome} PARA {destino.Nome} \n(Ida: {dataIda.ToShortDateString()})...");
            var voosIda = Voo.PesquisarVoos(listaVoos, origem, destino, dataIda);
            ExibirVoos(voosIda);

            if (dataVolta.HasValue)
            {
                Console.WriteLine($"\nPesquisando voos de {destino.Nome} PARA {origem.Nome} \n(Volta: {dataVolta.Value.ToShortDateString()})...");
                var voosVolta = Voo.PesquisarVoos(listaVoos, destino, origem, dataVolta.Value);
                ExibirVoos(voosVolta);
            }

            // provisorio
            Passagem passagem = new Passagem { Voos = new List<Voo> { vooSPNY, vooNYLondres } };

            //tarifa total
            float tarifaTotal = passagem.CalcularTarifaTotal();
            Console.WriteLine($"\nTarifa total da passagem com conexão: {tarifaTotal} {vooSPNY.Moeda}");
        }
        static void ExibirVoos(List<Voo> voos)
        {
            if (voos.Any())
            {
                foreach (var voo in voos)
                {
                    Console.WriteLine($"Voo {voo.CodRota} - {voo.Nome} - Saída: {voo.HoraSaida}, Chegada: {voo.HoraChegada}, Tarifa: {voo.ValorTarifaBasica} {voo.Moeda}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }
        }
    }


}

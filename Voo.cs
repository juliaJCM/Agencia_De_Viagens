using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        public string Nome { get; set; }
        public string CodRota { get; set; }
        public List<CiaAerea> CiasAereas { get; set; }
        public List<Aeroporto> AeroportosOrigem { get; set; }
        public List<Aeroporto> AeroportosDestino { get; set; }
        public List<string> DiasSemana { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan HoraChegada { get; set; }
        public string Pais { get; set; }
        public float ValorTarifaBasica { get; set; }
        public float ValorTarifaBusiness { get; set; }
        public float ValorTarifaPremium { get; set; }
        public string Moeda { get; set; }

        public Voo(string nome, string codRota, List<CiaAerea> ciasAereas, List<Aeroporto> aeroportosOrigem,
                    List<Aeroporto> aeroportosDestino, List<string> diasSemana, TimeSpan horaSaida,
                    TimeSpan horaChegada, string pais, float valorTarifaBasica,
                    float valorTarifaBusiness, float valorTarifaPremium, string moeda = "BRL")
        {
            this.Nome = nome;
            this.CodRota = GerarCodigoRota();
            this.CiasAereas = ciasAereas;
            this.AeroportosOrigem = aeroportosOrigem;
            this.AeroportosDestino = aeroportosDestino;
            this.DiasSemana = diasSemana;
            this.HoraSaida = horaSaida;
            this.HoraChegada = horaChegada;
            this.Pais = pais;
            this.ValorTarifaBasica = valorTarifaBasica;
            this.ValorTarifaBusiness = valorTarifaBusiness;
            this.ValorTarifaPremium = valorTarifaPremium;
            this.Moeda = pais != "Brasil" ? "USD" : moeda;
        }

        public static List<Voo> PesquisarVoos(List<Voo> voos, Aeroporto origem, Aeroporto destino, DateTime data)
        {
            List<Voo> voosEncontrados = new List<Voo>();

            var diasDaSemanaPortugues = new Dictionary<DayOfWeek, string>
    {
        { DayOfWeek.Monday, "Segunda" },
        { DayOfWeek.Tuesday, "Terca" },
        { DayOfWeek.Wednesday, "Quarta" },
        { DayOfWeek.Thursday, "Quinta" },
        { DayOfWeek.Friday, "Sexta" },
        { DayOfWeek.Saturday, "Sabado" },
        { DayOfWeek.Sunday, "Domingo" }
    };

            string diaDaSemana = diasDaSemanaPortugues[data.DayOfWeek];

            Console.WriteLine($"Pesquisando voos para a data: {data.ToShortDateString()} ({diaDaSemana})");

            foreach (var voo in voos)

            {   //teste Contains:
                // Console.WriteLine($"Origem: {string.Join(", ", voo.AeroportosOrigem.Select(a => a.Sigla))} | Destino: {string.Join(", ", voo.AeroportosDestino.Select(a => a.Sigla))}");
                // Console.WriteLine($"Dias disponíveis: {string.Join(", ", voo.DiasSemana)}");
                // Console.WriteLine($"Origem: {origem.Sigla} - Return: {voo.AeroportosOrigem.Contains(origem)}");
                // Console.WriteLine($"Destino: {destino.Sigla} - Return: {voo.AeroportosDestino.Contains(destino)}");
                // Console.WriteLine($"Dia da semana: {diaDaSemana} - Return: {voo.DiasSemana.Contains(diaDaSemana)}");

                if (voo.AeroportosOrigem.Contains(origem) &&
                    voo.AeroportosDestino.Contains(destino) &&
                    voo.DiasSemana.Contains(diaDaSemana))
                {
                    voosEncontrados.Add(voo);
                    Console.WriteLine($"Voo {voo.Nome} encontrado e adicionado aos resultados.");
                }
                else
                {
                    Console.WriteLine($"Voo {voo.Nome} não atende aos critérios.");
                }

                Console.WriteLine(new string('-', 50));
            }

            return voosEncontrados;
        }

        public static string GerarCodigoRota()
        {
            Random random = new Random();
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";

            char letra1 = letras[random.Next(letras.Length)];
            char letra2 = letras[random.Next(letras.Length)];

            string numero = "";
            for (int i = 0; i < 4; i++)
            {
                numero += numeros[random.Next(numeros.Length)];
            }

            return $"{letra1}{letra2}{numero}";
        }
        public bool ValidaCriacaoVoo()
        {
            if (CiasAereas == null || CiasAereas.Count == 0 || AeroportosOrigem == null || AeroportosOrigem.Count == 0 ||
                AeroportosDestino == null || AeroportosDestino.Count == 0 || string.IsNullOrEmpty(CodRota))
            {
                Console.WriteLine("Dados inválidos. Voo não criado.");
                return false;
            }

            Console.WriteLine();
            return true;
        }
    }
}

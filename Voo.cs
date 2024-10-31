using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        private static readonly Random random = new Random();
        public string Codigo { get; private set; }
        public Aeroporto AeroportoOrigem { get; private set; }
        public Aeroporto AeroportoDestino { get; private set; }
        public CiaAerea CiaAerea { get; private set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public Frequencia Frequencia { get; private set; }
        public StatusEnum Status { get; set; }

        public Voo(
            Aeroporto aeroportoOrigem,
            Aeroporto aeroportoDestino,
            CiaAerea ciaAerea,
            DateTime dataPartida,
            DateTime dataChegada,
            List<DayOfWeek> diasFrequencia,
            string horaFrequencia,
            StatusEnum statusEnum

        )
        {
            Codigo = GerarCodigoVoo();
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Frequencia = new Frequencia(diasFrequencia, horaFrequencia);
            Status = statusEnum;
        }

        public static string GerarCodigoVoo()
        {
            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);
            int numeros = random.Next(1000, 10000);
            return $"{letra1}{letra2}{numeros}";
        }
        public void ExibirVoo()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Informações do Voo:");
            Console.WriteLine($"Código do Voo: {Codigo}");
            Console.WriteLine($"Aeroporto de Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla})");
            Console.WriteLine($"Aeroporto de Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla})");
            Console.WriteLine($"Companhia Aérea: {CiaAerea.Nome}");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Chegada: {DataChegada:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Frequência: {Frequencia.Hora} nos dias {string.Join(", ", Frequencia.Dias)}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine("-----------------------------------------------------");

        }

    }
}

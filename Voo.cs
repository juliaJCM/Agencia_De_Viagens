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
        public string Status { get; set; }

        public Voo(
            Aeroporto aeroportoOrigem,
            Aeroporto aeroportoDestino,
            CiaAerea ciaAerea,
            DateTime dataPartida,
            DateTime dataChegada,
            List<DayOfWeek> diasFrequencia,
            string horaFrequencia,
            string status

        )
        {
            Codigo = GerarCodigoVoo();
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Frequencia = new Frequencia(diasFrequencia, horaFrequencia);
            Status = status;
        }

        public static string GerarCodigoVoo()
        {
            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);
            int numeros = random.Next(1000, 10000);
            return $"{letra1}{letra2}{numeros}";
        }
    }
}

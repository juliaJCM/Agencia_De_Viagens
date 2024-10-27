using System;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        public Aeroporto AeroportoOrigem { get; private set; }
        public Aeroporto AeroportoDestino { get; private set; }
        public CiaAerea CiaAerea { get; private set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public Frequencia Frequencia { get; private set; }

        public Voo(
            Aeroporto aeroportoOrigem,
            Aeroporto aeroportoDestino,
            CiaAerea ciaAerea,
            DateTime dataPartida,
            DateTime dataChegada,
            List<DayOfWeek> diasFrequencia,
            string horaFrequencia
        )
        {
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Frequencia = new Frequencia(diasFrequencia, horaFrequencia);
        }
    }
}
using System;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        public string Codigo { get; set; }
        public Aeroporto AeroportoOrigem { get; private set; } // Apenas um aeroporto de origem
        public Aeroporto AeroportoDestino { get; private set; } // Apenas um aeroporto de destino
        public CiaAerea CiaAerea { get; private set; } // Apenas uma companhia aérea por voo
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public Tarifa Tarifa { get; private set; }
        public Aeroporto? AeroportoConexao { get; set; } // Apenas um aeroporto de destino
        public string Status { get; set; }

        public Voo(
        string codigo,
        string status,
        Aeroporto aeroportoOrigem,
        Aeroporto aeroportoDestino,
        DateTime dataPartida,
        DateTime dataChegada,
        double tarifaBasica,
        double tarifaPremium,
        double tarifaBusiness,
        Aeroporto? aeroportoConexao = null)
        {
            Codigo = codigo;
            Status = status;
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Tarifa = new Tarifa(tarifaBasica, tarifaPremium, tarifaBusiness);
            AeroportoConexao = aeroportoConexao;
        }

    }
}
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

        //-----ATRIBUTOS RELACIONADOS À SPRINT 4-----//
        public Aeronave Aeronave{ get; set; }

        public Voo(
            Aeroporto aeroportoOrigem,
            Aeroporto aeroportoDestino,
            CiaAerea ciaAerea,
            DateTime dataPartida,
            // DateTime dataChegada,
            List<DayOfWeek> diasFrequencia,
            string horaFrequencia,
            StatusEnum statusEnum,
            Aeronave aeronave
        )
        {
            Codigo = GerarCodigoVoo();
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            // DataChegada = dataChegada;
            Frequencia = new Frequencia(diasFrequencia, horaFrequencia);
            Status = statusEnum;
            Aeronave = aeronave;
        }

        public static string GerarCodigoVoo()
        {
            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);
            int numeros = random.Next(1000, 10000);
            return $"{letra1}{letra2}{numeros}";
        }
        public void Exibir()
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("INFORMAÇÕES DO VOO");
            Console.WriteLine($"Código do Voo: {Codigo}");
            Console.WriteLine($"Aeroporto de Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla})");
            Console.WriteLine($"Aeroporto de Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla})");
            Console.WriteLine($"Companhia Aérea: {CiaAerea.Nome}");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Chegada: {DataChegada:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Frequência: {Frequencia.Hora} nos dias {string.Join(", ", Frequencia.Dias)}");
            Console.WriteLine($"Status: {StatusEnum.Ativo}");
            Console.WriteLine(new string('-', 30));
        }

//-----MÉTODOS RELACIONADOS À SPRINT 4-----//
        public float CalculaTempoViagem()
        {
            float distancia = CalculaDistancia(AeroportoOrigem.Latitude, AeroportoOrigem.Longitude, AeroportoDestino.Latitude, AeroportoDestino.Longitude
            );

            if(Aeronave == null || Aeronave.VelocidadeMedia <=0)
            {
                throw new InvalidOperationException("A velocidade média da aeronave é inválida!");
            }

            return distancia/ Aeronave.VelocidadeMedia;
        }

        public float CalculaDistancia(float x1, float y1, float x2, float y2)
        {
            return 110.57f * MathF.Sqrt(MathF.Pow(x2-x1, 2) + MathF.Pow(y2-y1 , 2));
        }

        public DateTime CalculaHorarioPrevistoChegada()
        {
            float tempoViagemHoras = CalculaTempoViagem();
            TimeSpan tempo = TimeSpan.FromHours(tempoViagemHoras);
            return DataPartida.Add(tempo);
        }
    }
}

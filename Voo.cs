using System;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        public string Codigo { get; set; }
        public Aeroporto AeroportoOrigem { get; set; } // Apenas um aeroporto de origem
        public Aeroporto AeroportoDestino { get; set; } // Apenas um aeroporto de destino
        public CiaAerea CiaAerea { get; set; }   // Apenas uma companhia aérea por voo
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public double Tarifa { get; set; }

        public Voo(string codigo, Aeroporto aeroportoOrigem, Aeroporto aeroportoDestino, CiaAerea ciaAerea, DateTime dataPartida, DateTime dataChegada, double tarifa)
        {
            Codigo = codigo;
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Tarifa = tarifa;
        }

        public void ExibirDadosVoo()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Código do Voo: {Codigo}");
            Console.WriteLine($"Aeroporto de Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla}) - {AeroportoOrigem.Cidade}, {AeroportoOrigem.Estado}, {AeroportoOrigem.Pais}");
            Console.WriteLine($"Aeroporto de Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla}) - {AeroportoDestino.Cidade}, {AeroportoDestino.Estado}, {AeroportoDestino.Pais}");
            Console.WriteLine($"Companhia Aérea: {CiaAerea.Nome} - CNPJ: {CiaAerea.CNPJ}");
            Console.WriteLine($"Data de Partida: {DataPartida}");
            Console.WriteLine($"Data de Chegada: {DataChegada}");
            Console.WriteLine($"Tarifa: 'US$'{Tarifa}");
            Console.WriteLine(new string('-', 30));
        }
        public static string GerarCodigoRota()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
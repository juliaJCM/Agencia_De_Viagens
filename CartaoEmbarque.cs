using System;

namespace Agencia_De_Viagens
{
    public class CartaoEmbarque
    {
        public Aeroporto AeroportoOrigem { get; set; }
        public Aeroporto AeroportoDestino { get; set; }
        public DateTime DataPartida { get; set; }
        public string AssentoReservado { get; set; }
        public Passagem passagem{ get; set; }
        public Cliente Nome { get; set; }
        public Aeronave aeronave { get; set; }
        
        // Horário de embarque calculado como 40 minutos antes da partida
        public DateTime HorarioEmbarque => passagem.DataPartida.AddMinutes(-40);

        public CartaoEmbarque(Aeroporto aeroportoOrigem, Aeroporto aeroportoDestino, DateTime dataPartida)
        {
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            DataPartida = dataPartida;
        }

        // Método para exibir informações do cartão de embarque
        public void ExibirCartao()
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("CARTÃO DE EMBARQUE:");
            Console.WriteLine($"Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla})");
            Console.WriteLine($"Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla})");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine(new string('-', 30));
        }
    }
}

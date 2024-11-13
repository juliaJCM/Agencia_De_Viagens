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
        
        // Horário de embarque calculado como 40 minutos antes da partida
        public DateTime HorarioEmbarque => passagem.DataPartida.AddMinutes(-40);

        public CartaoEmbarque(Aeroporto aeroportoOrigem, Aeroporto aeroportoDestino, DateTime dataPartida, Cliente nome, string assentoReservado)
        {
            Nome = nome;
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            DataPartida = dataPartida;
            AssentoReservado = assentoReservado;
        }

        // Método para exibir informações do cartão de embarque
        public void ExibirCartao()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Cartão de Embarque");
            Console.WriteLine($"Passageiro: {Nome}");
            Console.WriteLine($"Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla})");
            Console.WriteLine($"Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla})");
            Console.WriteLine($"Horário de Embarque: {HorarioEmbarque:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Assento: {AssentoReservado}");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}

using System;

namespace Agencia_De_Viagens
{
    public class CartaoEmbarque
    {
        public Aeroporto AeroportoOrigem { get; private set; }
        public Aeroporto AeroportoDestino { get; private set; }
        public DateTime DataPartida { get; private set; }
        public string NomePassageiro { get; private set; }
        public string SobrenomePassageiro { get; private set; }
        public string AssentoReservado { get; private set; }

        // Horário de embarque calculado como 40 minutos antes da partida
        public DateTime HorarioEmbarque => DataPartida.AddMinutes(-40);

        public CartaoEmbarque(Aeroporto aeroportoOrigem, Aeroporto aeroportoDestino, DateTime dataPartida, string nomePassageiro, string sobrenomePassageiro, string assentoReservado)
        {
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            DataPartida = dataPartida;
            NomePassageiro = nomePassageiro;
            SobrenomePassageiro = sobrenomePassageiro;
            AssentoReservado = assentoReservado;
        }

        // Método para exibir informações do cartão de embarque
        public void ExibirCartao()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Cartão de Embarque");
            Console.WriteLine($"Passageiro: {NomePassageiro} {SobrenomePassageiro}");
            Console.WriteLine($"Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla})");
            Console.WriteLine($"Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla})");
            Console.WriteLine($"Horário de Embarque: {HorarioEmbarque:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Assento: {AssentoReservado}");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}

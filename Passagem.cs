using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    public class Passagem
    {
        public string Codigo { get; private set; }
        public Aeroporto AeroportoOrigem { get; private set; } 
        public Aeroporto AeroportoDestino { get; private set; } 
        public Aeroporto? AeroportoConexao { get; private set; } 
        public CiaAerea CiaAerea { get; private set; } 
        public DateTime DataPartida { get; private set; }
        public DateTime DataChegada { get; private set; }
        public Cliente cliente { get; set; }
        public Tarifa Tarifa { get; private set; }
        public string Moeda { get; private set; }
        public double ValorDaPrimeiraBagagem { get; private set; }
        public double ValorDaBagagemAdicional { get; private set; }
        public bool Ativo { get; private set; } = false;
        public TipoPassagemEnum TipoPassagem { get; private set; }
        private double TARIFA_VIAGEM_INTERNACIONAL = 5.60;
        public List<Voo> Voos { get; set; }
        public StatusEnum Status { get; set; }
        public string AssentoReservado { get; private set; }
        public bool VerificaCheckIn { get; set; }
        public List<CartaoEmbarque> CartoesEmbarque { get; private set; }  = new List<CartaoEmbarque>();

        //-------------------------CONSTRUTOR DA CLASSES PASSAGEM---------------------------------//
        public Passagem(
            string codigo,
            Aeroporto aeroportoOrigem,
            Aeroporto aeroportoDestino,
            CiaAerea ciaAerea,
            DateTime dataPartida,
            DateTime dataChegada,
            string moeda,
            double tarifaBasica,
            double tarifaPremium,
            double tarifaBusiness,
            TipoPassagemEnum tipo,
            List<Voo> voos,
            StatusEnum statusEnum,
            Aeroporto? aeroportoConexao = null 
        )
        {
            Codigo = codigo;
            AeroportoOrigem = aeroportoOrigem;
            AeroportoDestino = aeroportoDestino;
            CiaAerea = ciaAerea;
            DataPartida = dataPartida;
            DataChegada = dataChegada;
            Moeda = moeda;
            TipoPassagem = tipo;
            AeroportoConexao = aeroportoConexao;
            ValorDaPrimeiraBagagem = ciaAerea.ValorPrimeiraBagagem;
            ValorDaBagagemAdicional = ciaAerea.ValorDemaisBagagens;
            Voos = voos;
            if (TipoPassagemEnum.Internacional.Equals(tipo))
            {
                tarifaBasica *= TARIFA_VIAGEM_INTERNACIONAL;
                tarifaPremium *= TARIFA_VIAGEM_INTERNACIONAL;
                tarifaBusiness *= TARIFA_VIAGEM_INTERNACIONAL;
            }
            Tarifa = new Tarifa(tarifaBasica, tarifaPremium, tarifaBusiness);
            Status = statusEnum;
        }

        //-------------------------MÉTODO PARA GERAR CÓDIGO DA ROTA---------------------------------//
        public static string GerarCodigoRota()
        {
            Random rnd = new Random();

            string letras = "";
            for (int i = 0; i < 2; i++)
            {
                int randValue = rnd.Next(0, 26);
                letras += Convert.ToChar(randValue + 65);
            }

            var numeros = rnd.Next(1000, 9999);

            string codigoDeVoo = letras + numeros;

            return codigoDeVoo;
        }

        //-------------------------MÉTODO PARA MOSTRAR PASSAGEM---------------------------------//
        public void ExibirPassagem()
        {
            Console.WriteLine("Informações da Passagem:");
            Console.WriteLine($"Código do Voo: {Codigo}");
            Console.WriteLine($"Aeroporto de Origem: {AeroportoOrigem.Nome} ({AeroportoOrigem.Sigla}) - {AeroportoOrigem.Cidade}, {AeroportoOrigem.Pais}");
            Console.WriteLine($"Aeroporto de Destino: {AeroportoDestino.Nome} ({AeroportoDestino.Sigla}) - {AeroportoDestino.Cidade}, {AeroportoDestino.Pais}");

            if (AeroportoConexao != null)
            {
                Console.WriteLine($"Aeroporto de Conexão: {AeroportoConexao.Nome} ({AeroportoConexao.Sigla}) - {AeroportoConexao.Cidade}, {AeroportoConexao.Pais}");
            }

            Console.WriteLine($"Companhia Aérea: {CiaAerea.Nome}");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Chegada: {DataChegada:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Moeda: {Moeda}");
            Console.WriteLine($"Tipo de Passagem: {TipoPassagem}");
            Console.WriteLine($"Tarifa Básica: {Tarifa.TarifaBasica:F2} {Moeda}");
            Console.WriteLine($"Tarifa Premium: {Tarifa.TarifaPremium:F2} {Moeda}");
            Console.WriteLine($"Tarifa Business: {Tarifa.TarifaBusiness:F2} {Moeda}");
            Console.WriteLine($"Valor da Primeira Bagagem: {ValorDaPrimeiraBagagem:F2} {Moeda}");
            Console.WriteLine($"Valor da Bagagem Adicional: {ValorDaBagagemAdicional:F2} {Moeda}");
            Console.WriteLine($"Voos: {Voos}");
            Console.WriteLine("-----------------------------------------------------");
        }

        //-------------------------MÉTODO PARA ATIVAR A PASSAGEM APÓS SUA COMPRA---------------------------------//
        public void AtivarPassagem()
        {
            Ativo = true;
        }

        //-------------------------MÉTODO PARA REALIZAR A VERIFICAÇÃO DO CHECK IN--------------------------------//
        public void RealizaCheckIn()
        {
            DateTime agora = DateTime.Now;
            DateTime inicioCheckIn = DataPartida.AddHours(-48); 
            DateTime limiteCheckIn = DataPartida.AddMinutes(-30);

            if(agora >= inicioCheckIn && agora <= limiteCheckIn)
            {
                VerificaCheckIn = true;
                CheckIn_Realizado = true;
                Console.WriteLine("Check in realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Check in fora do período permitido!");
            }
        }

        //-------------------------MÉTODO PARA VERIFICAR SE O CLINTE REALIZOU O CHECK-IN--------------------------------//
        public void VerificaNoShow()
        {
            if(!VerificaCheckIn && DateTime.Now > DataPartida)
            {
                NoShow = true;
                Console.WriteLine("Cliente não compareceu para o check in durante o período previsto. ")
            }
        }

        //-------------------------MÉTODO PARA GERAR O CARTÃO DE EMBARQUE--------------------------------//
        private void GerarCartaoEmbarque ()
        {
            if(!VerificaCheckIn)
            {
                Console.WriteLine("Não foi possível gerar o cartaõ de embarque uma vez que o check-in não foi realizado!");
                return;
            }
            foreach (var voo in Voos)
            {
                // Calcula o horário de embarque (40 minutos antes da partida)
                DateTime horarioEmbarque = voo.DataPartida.AddMinutes(-40);

                // Cria o cartão de embarque e armazena na lista
                CartaoEmbarque cartao = new CartaoEmbarque(
                    NomePassageiro,
                    voo.AeroportoOrigem,
                    voo.AeroportoDestino,
                    horarioEmbarque,
                    voo.DataPartida,
                    voo.Assento 
                );
                CartoesEmbarque.Add(cartao);
            }
        }
        
        //-----------------------MÉTODO PARA MOSTRAR O CARTÃO DE EMBARQUE------------------------------//
        public void ExibirCartaoEmbarque()
        {
            foreach (var cartao in CartoesEmbarque)
            {
                cartao.ExibirCartao();
            }
        }

        public void RegistrarEmbarque(bool embarcou)
        {
            if (!VerificaCheckIn)
            {
                Console.WriteLine("Não foi possível registrar o embarque uma vez que o cliente não realizou o check-in!");
                return;
            }

            if (embarcou)
            {
                Embarque_Realizado = true;
                Console.WriteLine("Passageiro embarcou!");
            }
            else
            {
                NoShow = true;
                Console.WriteLine("Passageiro não embarcou. Status NO SHOW registrado!");
            }
        }

    }
}
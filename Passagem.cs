using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    public class Passagem : ILog
    {
        public string Codigo { get; private set; }
        public Aeroporto AeroportoOrigem { get; private set; }
        public Aeroporto AeroportoDestino { get; private set; }
        public Aeroporto? AeroportoConexao { get; private set; }
        public CiaAerea CiaAerea { get; private set; }
        public DateTime DataPartida { get; private set; }
        public DateTime DataChegada { get; private set; }
        public Cliente cliente { get; set; }
        public Cliente Nome { get; set; }
        public Tarifa Tarifa { get; private set; }
        public string Moeda { get; private set; }
        public double ValorDaPrimeiraBagagem { get; private set; }
        public double ValorDaBagagemAdicional { get; private set; }
        public int Bagagem { get; set; }
        public int BagagensExtras { get; set; }
        public bool Ativo { get; private set; } = false;
        public TipoPassagemEnum TipoPassagem { get; private set; }
        private static double TarifaViagemInternacional = 5.60;
        public List<Voo> Voos { get; set; }
        public StatusEnum Status { get; set; }
        public string AssentoReservado { get; set; }
        public bool VerificaCheckIn { get; set; }
        public List<CartaoEmbarque> CartoesEmbarque { get; private set; } = new List<CartaoEmbarque>();
        public CartaoEmbarque cartaoEmbarque { get; set; }

        private readonly ILog _logger;

        public Passagem(
            ILog log,
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
            _logger = log;
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
                tarifaBasica *= TarifaViagemInternacional;
                tarifaPremium *= TarifaViagemInternacional;
                tarifaBusiness *= TarifaViagemInternacional;
            }
            Tarifa = new Tarifa(tarifaBasica, tarifaPremium, tarifaBusiness);
            Status = statusEnum;
        }

        public void RegistraLog(string registro)
        {
            Log log = new Log();
            log.RegistraLog($"Dados do Sistema - {registro}");
        }

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

        public void ExibirBuscaPassagem(bool IsVip)
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("INFORMAÇÕES INICIAIS DA PASSAGEM");
            Console.WriteLine($"Data de Partida: {DataPartida:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data de Chegada: {DataChegada:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Duração do Voo: {DataChegada - DataPartida:hh\\:mm}");

            double valorPassagem = Tarifa.TarifaBasica + ValorDaPrimeiraBagagem;

            if (IsVip)
            {
                Console.WriteLine($"Valor Passagem: {(Tarifa.TarifaPremium + ValorDaPrimeiraBagagem):F2} {Moeda}");
            }
            else
            {
                valorPassagem += ValorDaBagagemAdicional;
                Console.WriteLine($"Valor Passagem (com bagagem extra): {valorPassagem:F2} {Moeda}");
            }
            Console.WriteLine(new string('-', 30));
        }

        public void ExibirPassagemFinal(bool IsVip)
        {
            double valorPassagem = Tarifa.TarifaBasica + ValorDaPrimeiraBagagem;

            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("INFORMAÇÕES DA PASSAGEM FINAL");
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
            Console.WriteLine($"Duração do Voo: {(DataChegada - DataPartida):hh\\:mm}");
            Console.WriteLine($"Moeda: {Moeda}");
            Console.WriteLine($"Tipo de Passagem: {TipoPassagem}");
            Console.WriteLine($"Tarifa Básica: {Tarifa.TarifaBasica:F2} {Moeda}");
            if (IsVip == true)
            {
                Console.WriteLine($"Valor Passagem: {(Tarifa.TarifaPremium + ValorDaPrimeiraBagagem):F2} {Moeda}");
            }
            else
            {
                valorPassagem += ValorDaBagagemAdicional;
                Console.WriteLine($"Valor Passagem (com bagagem extra): {valorPassagem:F2} {Moeda}");
            }
            // Console.WriteLine($"Tarifa Premium: {Tarifa.TarifaPremium:F2} {Moeda}");
            // Console.WriteLine($"Tarifa Business: {Tarifa.TarifaBusiness:F2} {Moeda}");   
            // Console.WriteLine($"Valor da Primeira Bagagem: {ValorDaPrimeiraBagagem:F2} {Moeda}");
            // Console.WriteLine($"Valor da Bagagem Adicional: {ValorDaBagagemAdicional:F2} {Moeda}");
            Console.WriteLine($"Status Passagem: {StatusEnum.Ativo}");
            Console.WriteLine(new string('-', 30));
        }

        public List<Voo> BuscaVooPassagem()
        {
            var voo = Voos.Where(v =>
                v.AeroportoOrigem == AeroportoOrigem &&
                v.AeroportoDestino == AeroportoDestino &&
                v.Frequencia.Dias.Contains(DataPartida.DayOfWeek) &&
                v.Frequencia.Hora == DataPartida.ToString("HH:mm") &&
                v.DataPartida >= DataPartida
            ).ToList();
            return voo;
        }

        public void RealizaCheckIn()
        {
            // DateTime agora = DateTime.Now;
            DateTime agora = DateTime.Now.AddHours(-48);

            DateTime inicioCheckIn = DataPartida.AddHours(-48);
            DateTime limiteCheckIn = DataPartida.AddMinutes(-30);

            if (agora >= inicioCheckIn && agora <= limiteCheckIn)
            {
                VerificaCheckIn = true;
                VerificaNoShow(VerificaCheckIn);
            }
            else
            {
                VerificaCheckIn = false;
                VerificaNoShow(VerificaCheckIn);
            }
        }

        public void VerificaNoShow(bool VerificaCheckIn)
        {
            if (!VerificaCheckIn)
            {
                Status = StatusEnum.NoShow;
                _logger.RegistraLog($"ERR: Check In não pôde ser realizado!");
                Console.WriteLine("\nCliente não compareceu para o check in durante o período previsto.");
            }
            else
            {
                Console.WriteLine("\nCheck-in realizado com sucesso!");
                Status = StatusEnum.CheckIn_Realizado;
                VerificaCheckIn = true;
                _logger.RegistraLog($"Check In realizado com sucesso.");
                GerarCartaoEmbarque(VerificaCheckIn);
            }
        }

        public void GerarCartaoEmbarque(bool VerificaCheckIn)
        {
            if (!VerificaCheckIn)
            {
                Console.WriteLine("\nNão foi possível gerar o cartão de embarque uma vez que o check-in não foi realizado!");
            }

            foreach (var voo in Voos)
            {
                // Cria o cartão de embarque e armazena na lista
                CartaoEmbarque cartao = new CartaoEmbarque(
                    voo.AeroportoOrigem,
                    voo.AeroportoDestino,
                    voo.DataPartida
                );
                CartoesEmbarque.Add(cartao);
            }
            foreach (var cartao in CartoesEmbarque)
            {
                cartao.ExibirCartao();
            }
        }

        //-----------------------MÉTODO PARA REGSITRAR O EMBARQUE DO CLIENTE------------------------------//
        public void RegistrarEmbarque()
        {
            if (!VerificaCheckIn)
            {
                Console.WriteLine("\nNão foi possível registrar o embarque uma vez que o cliente não realizou o check-in!");
                return;
            }

            if (VerificaCheckIn)
            {
                Status = StatusEnum.Embarque_Realizado;
                Console.WriteLine("\nPassageiro embarcou!");
            }
            else
            {
                Status = StatusEnum.NoShow;
                Console.WriteLine("\nPassageiro não embarcou. Status NO SHOW registrado!");
            }
        }

    }
}
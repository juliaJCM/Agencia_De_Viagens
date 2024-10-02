using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Voo
    {
        public string Nome { get; set; }
        public string CodRota { get; set; }
        public List<CiaAerea> CiasAereas { get; set; }
        public List<Aeroporto> AeroportosOrigem { get; set; }
        public List<Aeroporto> AeroportosDestino { get; set; }
        public DiasSemana DiasSemana { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan HoraChegada { get; set; }
        public string Pais { get; set; }
        public float ValorTarifaBasica { get; set; }
        public float ValorTarifaBusiness { get; set; }
        public float ValorTarifaPremium { get; set; }
        public string Moeda { get; set; }

        // Construtor
        public Voo(string nome, string codRota, List<CiaAerea> ciasAereas, List<Aeroporto> aeroportosOrigem, 
                    List<Aeroporto> aeroportosDestino, DiasSemana diasSemana, TimeSpan horaSaida, 
                    TimeSpan horaChegada, string pais, float valorTarifaBasica, 
                    float valorTarifaBusiness, float valorTarifaPremium, string moeda)
        {
            this.Nome = nome;
            this.CodRota = GerarCodigoRota();
            this.CiasAereas = ciasAereas;
            this.AeroportosOrigem = aeroportosOrigem;
            this.AeroportosDestino = aeroportosDestino;
            this.DiasSemana = diasSemana;
            this.HoraSaida = horaSaida;
            this.HoraChegada = horaChegada;
            this.Pais = pais;
            this.ValorTarifaBasica = valorTarifaBasica;
            this.ValorTarifaBusiness = valorTarifaBusiness;
            this.ValorTarifaPremium = valorTarifaPremium;
            this.Moeda = moeda;
        }

        public static string GerarCodigoRota()
        {
            Random random = new Random();
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Letras maiúsculas
            string numeros = "0123456789"; // Números

            // Gerar duas letras aleatórias
            char letra1 = letras[random.Next(letras.Length)];
            char letra2 = letras[random.Next(letras.Length)];

            // Gerar quatro números aleatórios
            string numero = "";
            for (int i = 0; i < 4; i++)
            {
                numero += numeros[random.Next(numeros.Length)];
            }

            // Concatenar letras e números
            return $"{letra1}{letra2}{numero}";
        }

        // Método para criar o voo
        public bool CriarVoo()
        {
            // Validação simples
            if (CiasAereas == null || CiasAereas.Count == 0 || AeroportosOrigem == null || AeroportosOrigem.Count == 0 ||
                AeroportosDestino == null || AeroportosDestino.Count == 0 || string.IsNullOrEmpty(CodRota))
            {
                Console.WriteLine("Dados inválidos. Voo não criado.");
                return false;
            }

            // Aqui você pode adicionar lógica adicional, como salvar no banco de dados ou realizar outras validações
            Console.WriteLine();
            return true;
        }
    }

    // Enumeração para os dias da semana
    [Flags]
    public enum DiasSemana
    {
        Nenhum = 0,
        Segunda = 1,
        Terça = 2,
        Quarta = 4,
        Quinta = 8,
        Sexta = 16,
        Sábado = 32,
        Domingo = 64
    }
}
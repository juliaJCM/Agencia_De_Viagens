using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class CiaAerea
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public double ValorPrimeiraBagagem { get; set; }
        public double ValorDemaisBagagens { get; set; }

        // Construtor opcional
        public CiaAerea(string nome, int codigo, string razaoSocial, string cnpj, double valorPrimeiraBagagem, double valorDemaisBagagens)
        {
            Nome = nome;
            Codigo = codigo;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            ValorPrimeiraBagagem = valorPrimeiraBagagem;
            ValorDemaisBagagens = valorDemaisBagagens;
        }

        // Método para criar a companhia aérea
        public bool CriarCiaAerea(string nome, int codigo, string razaoSocial, string cnpj, double valorPrimeiraBagagem, double valorDemaisBagagens)
        {
            // Validação básica
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(razaoSocial) || string.IsNullOrEmpty(cnpj) || int.IsNegative(codigo)  || double.IsNaN(valorPrimeiraBagagem) || double.IsNaN(valorDemaisBagagens))
            {
                Console.WriteLine("Dados inválidos. Companhia aérea não criada.");
                return false;
            }

            // Atribuindo valores passados aos atributos da instância
            Nome = nome;
            Codigo = codigo;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            ValorPrimeiraBagagem = valorPrimeiraBagagem;
            ValorDemaisBagagens = valorDemaisBagagens;
            return true;
        }

        public void ExibirDadosCiaAerea()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Nome da Companhia: {Nome}");
            Console.WriteLine($"Codigo: {Codigo}");
            Console.WriteLine($"Razão Social: {RazaoSocial}");
            Console.WriteLine($"CNPJ: {CNPJ}");
            Console.WriteLine($"Valor da primeira bagagem: R${ValorPrimeiraBagagem}");
            Console.WriteLine($"Valor para bagagem extras: R${ValorDemaisBagagens}");
            Console.WriteLine(new string('-', 30));
        }
    }
}
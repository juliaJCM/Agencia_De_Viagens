using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Aeroporto
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        // Construtor opcional
        public Aeroporto(string nome, string sigla, string cidade, string estado, string pais)
        {
            Nome = nome;
            Sigla = sigla;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        // Método para criar um aeroporto
        public bool CriarAeroporto(string nome, string sigla, string cidade,string estado,string pais)
        {
            // Validação básica
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sigla) || string.IsNullOrEmpty(cidade) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(pais))
            {
                Console.WriteLine("Dados inválidos. Aeroporto não criado.");
                return false;
            }

            // Validação para garantir que a sigla contenha sempre 3 letra maiúsculas
            if (sigla.Length != 3 || !sigla.All(char.IsLetter))
            {
                Console.WriteLine("Sigla inválida. Ela deve conter exatamente 3 letras.");
                return false;
            }

            // Atribuindo valores passados aos atributos da instância
            Nome = nome;
            Sigla = sigla;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;

            // Aqui poderia haver lógica adicional, como salvar no banco de dados
            Console.WriteLine("Aeroporto criado com sucesso!");
            return true;
        }

        public void ExibirDadosAeroporto()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Sigla: {Sigla}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Cidade: {Cidade}");
            Console.WriteLine($"País: {Pais}");
        }
    }
}

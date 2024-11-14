using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Agencia_De_Viagens
{
    public class Funcionario
    {
        // Propriedades públicas para acesso externo, se necessário
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public bool AcessoSistema { get; private set; } = false;
        public string? Login { get; private set; }
        public string? Senha { get; private set; }
        public Funcionario(string nome, string cpf, string email)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        public void CriarAcessoSistema(string login, string senha)
        {
            Login = login;
            Senha = senha;
            AcessoSistema = true;
        }

        public void Exibir()
        {
            Console.WriteLine("\n"+ new string('-', 30));
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Login: {Login}");
            Console.WriteLine($"Senha: {Senha}");
            Console.WriteLine(new string('-', 30));
        }
    }
}

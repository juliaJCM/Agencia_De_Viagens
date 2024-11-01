using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Passaporte { get; set; }
        public List<Passagem> PassagensCompradas { get; set; }
        public List<Passagem> PassagensCanceladas { get; set; }
        public Aeronave Aeronave { get; set; }

        public Cliente(string nome, string cpf, string rg, string email, string passaporte)
        {
            Nome = nome;
            CPF = cpf;
            RG = rg;
            Email = email;
            Passaporte = passaporte;
            PassagensCompradas = new List<Passagem>();
            PassagensCanceladas = new List<Passagem>();

        }

        // Método para criar um novo registro de cliente

        public void AdicionarPassagemComprada(Passagem passagemComprada)
        {
            PassagensCompradas.Add(passagemComprada);
            Console.WriteLine("Passagem comprada com susesso!");
        }
        public void ExcluirPassagem(Passagem passagemComprada)
        {
            PassagensCompradas.Remove(passagemComprada);
            Console.WriteLine("Passagem comprada com susesso!");
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"RG: {RG}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Passaporte: {Passaporte}");
            Console.WriteLine(new string('-', 30));
        }
    }
}


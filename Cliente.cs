using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Cliente
    {
        // Lista de clientes armazenados
        static List<Cliente> Clientes = new List<Cliente>();

        // Propriedades
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? Email { get; set; }
        public string? Passaporte { get; set; }

        // Método para criar um novo cliente
        public bool CriarCliente(string nome, string cpf, string rg, string email, string passaporte)
        {
            // Verifica se o cliente com o mesmo CPF já existe
            if (Clientes.Exists(c => c.CPF == cpf))
            {
                Console.WriteLine("Cliente com o mesmo CPF já existe!");
                return false;
            }

            Cliente novoCliente = new Cliente
            {
                Nome = nome,
                CPF = cpf,
                RG = rg,
                Email = email,
                Passaporte = passaporte
            };

            Clientes.Add(novoCliente);
            Console.WriteLine("Cliente criado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        // Método para listar todos os clientes cadastrados anteriormente
        public void ListarClientes()
        {
            if (Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
                return;
            }

            Console.WriteLine("Clientes cadastrados:");
            foreach (var cliente in Clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.CPF}");
                Console.WriteLine($"RG: {cliente.RG}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Passaporte: {cliente.Passaporte}");
                Console.WriteLine(new string('-', 30));
            }
        }

        // Método para excluir um cliente através do CPF
        public bool ExcluirCliente(string cpf)
        {
            Cliente? clienteEncontrado = Clientes.Find(c => c.CPF == cpf);

            if (clienteEncontrado != null)
            {
                Clientes.Remove(clienteEncontrado);
                Console.WriteLine("Cliente excluído com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
                return false;
            }
        }
    }
}


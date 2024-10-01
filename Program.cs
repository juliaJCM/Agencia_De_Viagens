using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Program
    {
        private static void Main(string[] args)
        {
            while (true){
                Console.WriteLine(" _________________________________________ ");
                Console.WriteLine("|_____________Visualizar voos_____________|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Funcionario                   |");
                Console.WriteLine("|   2    |  Cliente                       |");
                Console.WriteLine("|   0    |  Sair                          |");
                Console.WriteLine("|_________________________________________|");
                Console.WriteLine("Insira o código do menu voos e digite 'Enter'");

            string? opcao1 = Console.ReadLine();

                switch (opcao1)
                {
                    case "1":
                        MenuFuncionario menu = new MenuFuncionario();
                        menu.ExibirMenu();
                        break;

                    case "2":
                        Console.WriteLine("Você selevionou a opção Cliente!");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }

            while (true)
            {

                Console.WriteLine(" _________________________________________ ");
                Console.WriteLine("|_____________Visualizar voos_____________|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Passagens                     |");
                Console.WriteLine("|   2    |  Clientes                      |");
                Console.WriteLine("|   3    |  Companhia aérea               |");
                Console.WriteLine("|   4    |  Aeroportos                    |");
                Console.WriteLine("|   5    |  Rotas                         |");
                Console.WriteLine("|   6    |  Funcionarios                  |");
                Console.WriteLine("|   7    |                                |");
                Console.WriteLine("|   8    |                                |");
                Console.WriteLine("|   9    |                                |");
                Console.WriteLine("|   0    |  Sair                          |");
                Console.WriteLine("|_________________________________________|");
                Console.WriteLine("Insira o código do menu voos e digite 'Enter'");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        break;

                    case "2":
                        ExibirMenuCliente();
                        break;

                    case "6":
                        MenuFuncionario menu = new MenuFuncionario();
                        menu.ExibirMenu();
                        break;

                    case "7":
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // MENU Cliente
        private static void ExibirMenuCliente()
        {
            Cliente cliente = new Cliente();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu de Clientes");
                Console.WriteLine("1. Criar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Excluir Cliente");
                Console.WriteLine("0. Voltar");

                string? opcaoCliente = Console.ReadLine();

                switch (opcaoCliente)
                {
                    case "1":
                        Console.WriteLine("Digite o Nome:");
                        string nome = Console.ReadLine()!;
                        Console.WriteLine("Digite o CPF:");
                        string cpf = Console.ReadLine()!;
                        Console.WriteLine("Digite o RG:");
                        string rg = Console.ReadLine()!;
                        Console.WriteLine("Digite o Email:");
                        string email = Console.ReadLine()!;
                        Console.WriteLine("Digite o Passaporte:");
                        string passaporte = Console.ReadLine()!;

                        cliente.CriarCliente(nome, cpf, rg, email, passaporte);
                        break;

                    case "2":
                        cliente.ListarClientes();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Digite o CPF do cliente a ser excluído:");
                        string cpfExcluir = Console.ReadLine()!;
                        bool removido = cliente.ExcluirCliente(cpfExcluir);

                        if (removido)
                        {
                            Console.WriteLine("Cliente removido com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Program
    {
        private static void Main(string[] args)
        {
            
            ExibirMenuPrincipal();

        }


// Funções responsáveis por exibir os menus ao usuário
        private static void ExibirMenuPrincipal(){
            while (true)
            {
                Console.WriteLine(" _________________________________________ ");
                Console.WriteLine("|_______________Tela Inicial______________|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Funcionario                   |");
                Console.WriteLine("|   2    |  Cliente                       |");
                Console.WriteLine("|   0    |  Sair                          |");
                Console.WriteLine("|_________________________________________|");
                Console.WriteLine("Insira a opção desejada e digite 'Enter'");

            string? opcaoPrincipal = Console.ReadLine();

                switch (opcaoPrincipal)
                {
                    case "1":
                        MenuFuncionario menu = new MenuFuncionario();
                        menu.ExibirMenuFuncionario();
                        break;

                    case "2":
                        ExibirMenuCliente();
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

        private static void ExibirMenuVoo(){
                Console.WriteLine(" _________________________________________ ");
                Console.WriteLine("|_____________Visualizar voos_____________|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Passagens                     |");
                Console.WriteLine("|   2    |  Companhia aérea               |");
                Console.WriteLine("|   3    |  Aeroportos                    |");
                Console.WriteLine("|   4    |  Rotas                         |");
                Console.WriteLine("|   0    |  Sair                          |");
                Console.WriteLine("|_________________________________________|");
                Console.WriteLine("Insira o código do menu voos e digite 'Enter'");

                string? opcaoVoo = Console.ReadLine();

                switch (opcaoVoo)
                {
                    case "1":
                        Console.WriteLine("Você selecionou Passagens!");
                        break;

                    case "2":
                        Console.WriteLine("Você selecionou Companhia Aérea!");
                        CriarCiaAerea();
                        break;

                    case "3":
                        Console.WriteLine("Você selecionou Aeroporto!");
                        CriarAeroporto();
                        break;

                    case "4":
                        Console.WriteLine("Você selecionou Rotas!");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
        }

        // MENU Cliente
        private static void ExibirMenuCliente()
        {
            Cliente cliente = new Cliente();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" _________________________________________ ");
                Console.WriteLine("|_______________Menu Clientes_____________|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Criar Cliente                 |");
                Console.WriteLine("|   2    |  Listar Cliente                |");
                Console.WriteLine("|   3    |  Excluir Cliente               |");
                Console.WriteLine("|   0    |  Voltar                        |");
                Console.WriteLine("|_________________________________________|");
                Console.WriteLine("Insira o código do menu voos e digite 'Enter'");

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

        private static void CriarAeroporto() 
        {
            // Chama o método CriarAeroporto e passa os argumentos
            try
            {
                // Captura os dados do usuário
                Console.WriteLine("Insira o nome do aeroporto:");
                string? nome = Console.ReadLine();

                Console.WriteLine("Insira a sigla do aeroporto (Apenas 3 letras):");
                string? sigla = Console.ReadLine();

                Console.WriteLine("Insira o estado onde o aeroporto se encontra:");
                string? estado = Console.ReadLine();

                Console.WriteLine("Insira a cidade onde o aeroporto se encontra:");
                string? cidade = Console.ReadLine();

                Console.WriteLine("Insira o país onde o aeroporto se encontra:");
                string? pais = Console.ReadLine();

                // Cria uma instância da classe Aeroporto com os dados fornecidos pelo usuário
                Aeroporto aeroporto = new Aeroporto(nome, sigla, cidade, estado, pais);

                // Exibe os dados do aeroporto criado
                Console.WriteLine("\nAeroporto criado com sucesso:");
                aeroporto.ExibirDadosAeroporto();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CriarCiaAerea()
        {
            try
            {
                Console.WriteLine("Insira o nome da companhia aerea:");
                string? nome = Console.ReadLine();

                Console.WriteLine("Insira o código da companhia aerea:");
                int codigo = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira a razão social da companhia aerea:");
                string? razaoSocial = Console.ReadLine();

                Console.WriteLine("Insira o CNPJ da companhia aerea:");
                string? cnpj = Console.ReadLine();

                Console.WriteLine("Forneça o valor fixo da primeira bagagem dos passageiros:");
                double valorPrimeiraBagagem = double.Parse(Console.ReadLine());

                Console.WriteLine("Forneça o valor fixo das demais bagagens dos passageiros?");
                double valorDemaisBagagens= double.Parse(Console.ReadLine());

                CiaAerea ciaAerea = new CiaAerea(nome, codigo, razaoSocial, cnpj, valorPrimeiraBagagem, valorDemaisBagagens);

                // Exibe os dados do aeroporto criado
                Console.WriteLine("\nAeroporto criado com sucesso:");
                ciaAerea.ExibirDadosCiaAerea();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

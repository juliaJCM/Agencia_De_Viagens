using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class MenuFuncionario
    {
        private Funcionario funcionario;

        public MenuFuncionario()
        {
            funcionario = new Funcionario();
        }

        public void ExibirMenuFuncionario()
        {
            int opcao;
            do
            {
            Console.Clear();
            Console.WriteLine(" _________________________________________ ");
            Console.WriteLine("|_____________Menu Funcionarios___________|");
            Console.WriteLine("| Código |       Opções                   |");
            Console.WriteLine("|   1    |  Realizar Login                |");
            Console.WriteLine("|   2    |  Cadastrar funcionarios        |");
            Console.WriteLine("|   3    |  Listar funcionarios           |");
            Console.WriteLine("|   4    |  Excluir funcionarios          |");
            Console.WriteLine("|   0    |  Sair                          |");
            Console.WriteLine("|_________________________________________|");
            Console.WriteLine("Insira o código do menu voos e digite 'Enter'");

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out opcao))
                {
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        RealizarLogin();
                        break;
                    case 2:
                        CadastrarFuncionario();
                        break;
                    case 3:
                        funcionario.ListarFuncionarios();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        ExcluirFuncionario();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do menu de funcionários...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);
        }

        private void CadastrarFuncionario()
        {
            Console.Clear();
            Console.WriteLine("===== Cadastrar Funcionário =====");
            Console.Write("Digite o Nome: ");
            string? nome = Console.ReadLine();

            Console.Write("Digite o CPF: ");
            string? cpf = Console.ReadLine();

            Console.Write("Digite o Email: ");
            string? email = Console.ReadLine();

            Console.Write("Crie um Login: ");
            string? login = Console.ReadLine();

            Console.Write("Digite uma Senha: ");
            string? senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                Console.WriteLine("Todos os campos são obrigatórios. Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                return;
            }

            funcionario.CriarFuncionario(nome, cpf, email, login, senha);
        }

        private void ExcluirFuncionario()
        {
            Console.Clear();
            Console.WriteLine("===== Excluir Funcionário =====");
            Console.Write("Digite o CPF do funcionário a ser excluído: ");
            string? cpf = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("O CPF é obrigatório. Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                return;
            }

            bool excluido = funcionario.ExcluirFuncionario(cpf);
            if (excluido)
            {
                Console.WriteLine("Funcionário excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void RealizarLogin()
        {
            Console.Clear();
            Console.WriteLine("===== Realizar Login =====");
            Console.WriteLine("Digite seu login:");
            string? login = Console.ReadLine();

            Console.WriteLine("Digite sua senha:");
            string? senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                Console.WriteLine("Todos os campos são obrigatórios. Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                return;
            }

            bool loginRealizado = funcionario.LoginFuncionario(login, senha);
            if (loginRealizado)
            {
                Console.WriteLine("Login efetuado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
                Console.WriteLine("Tente novamente ou faça seu cadastro no sistema.");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
 
public class Program
{
    private static void Main(string[] args)
    {
        

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
                    
                    break;

                case "6":
                {
                            MenuFuncionario menu = new MenuFuncionario();
                            menu.ExibirMenu();
                            break;
                        }

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
}
}
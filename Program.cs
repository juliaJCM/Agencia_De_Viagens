using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    class Program
    {
        static void Main(string[] args)
        {

            ExibirMenuPrincipal();

        }


        // Funções responsáveis por exibir os menus ao usuário
        private static void ExibirMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine(" _______________ ");
                Console.WriteLine("|Tela Inicial_|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Funcionario                   |");
                Console.WriteLine("|   2    |  Cliente                       |");
                Console.WriteLine("|   0    |  Sair                          |");
                Console.WriteLine("|_|");
                Console.WriteLine("Insira a opção desejada e digite 'Enter'");

                string? opcaoPrincipal = Console.ReadLine();

                switch (opcaoPrincipal)
                {
                    case "1":
                        ExibirMenuFuncionario();
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

        private static void ExibirMenuVoo()
        {


            Console.WriteLine(" _______________ ");
            Console.WriteLine("|Visualizar voos|");
            Console.WriteLine("| Código |       Opções                   |");
            Console.WriteLine("|   1    |  Passagens                     |");
            Console.WriteLine("|   2    |  Companhia aérea               |");
            Console.WriteLine("|   3    |  Aeroportos                    |");
            Console.WriteLine("|   4    |  Rotas                         |");
            Console.WriteLine("|   5    |  Voo                           |");
            Console.WriteLine("|   0    |  Sair                          |");
            Console.WriteLine("|_|");
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

                case "5":

                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    break;
            }
        }
        // Adicione essas funções na classe Program, após o método ExibirMenuVoo

        private static List<Voo> InicializarVoos()
        {
            return new List<Voo>
    {
        new Voo(Voo.GerarCodigoRota(),
            new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil"),
            new Aeroporto("Aeroporto de JFK", "JFK", "Nova York", "NY", "EUA"),
            new CiaAerea("LATAM", 123, "Brasil", "São Paulo", 1000.0, 1500.0),
            new DateTime(2024, 10, 10, 02, 0, 0), // data de partida
            new DateTime(2024, 10, 10, 18, 0, 0), // data de chegada
            1000.0 // tarifa
        ),
        new Voo(Voo.GerarCodigoRota(),
            new Aeroporto("Aeroporto de JFK", "JFK", "Nova York", "NY", "EUA"),
            new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil"),
            new CiaAerea("LATAM", 123, "Brasil", "São Paulo", 1000.0, 1500.0),
            new DateTime(2024, 10, 11, 20, 0, 0), // data de partida
            new DateTime(2024, 10, 12, 8, 0, 0), // data de chegada
            1000.0 // tarifa
        )
    };
        }

        private static void ExibirVoos(List<Voo> voos)
        {
            Console.WriteLine("Voos disponíveis:");
            foreach (var voo in voos)
            {
                Console.WriteLine($"Voo: {voo.Codigo}, Origem: {voo.AeroportoOrigem.Nome}, Destino: {voo.AeroportoDestino.Nome}, Data de Partida: {voo.DataPartida}, Tarifa: {voo.Tarifa}");
            }
        }

        // Menu Cliente
        private static void ExibirMenuCliente()
        {
            Cliente cliente = new Cliente();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" _______________ ");
                Console.WriteLine("|Menu Clientes|");
                Console.WriteLine("| Código |       Opções                   |");
                Console.WriteLine("|   1    |  Criar Cliente                 |");
                Console.WriteLine("|   2    |  Listar Cliente                |");
                Console.WriteLine("|   3    |  Excluir Cliente               |");
                Console.WriteLine("|   4    |  Rotas                         |");
                Console.WriteLine("|   5    |  Passagens                     |");
                Console.WriteLine("|   0    |  Voltar                        |");
                Console.WriteLine("|_|");
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

                    case "4":
                        Console.WriteLine("Você selecionou Rotas!");
                        break;

                    case "5":
                        List<Voo> listaVoos = InicializarVoos();

                        Console.WriteLine("\nDigite o código do aeroporto de origem (GRU, JFK, LHR):");
                        string codigoOrigem = Console.ReadLine().ToUpper();

                        Console.WriteLine("Digite o código do aeroporto de destino (GRU, JFK, LHR):");
                        string codigoDestino = Console.ReadLine().ToUpper();

                        Console.WriteLine("Digite a data da viagem de ida (dd/mm/yyyy):");
                        DateTime dataIda;
                        while (!DateTime.TryParse(Console.ReadLine(), out dataIda))
                        {
                            Console.WriteLine("Data inválida. Por favor, insira novamente (dd/mm/yyyy):");
                        }

                        Console.WriteLine("Deseja pesquisar por um voo de volta? (s/n):");
                        string resposta = Console.ReadLine().ToLower();

                        DateTime? dataVolta = null;
                        if (resposta == "s")
                        {
                            Console.WriteLine("Digite a data da viagem de volta (dd/mm/yyyy):");
                            DateTime dataTemp;
                            while (!DateTime.TryParse(Console.ReadLine(), out dataTemp))
                            {
                                Console.WriteLine("Data inválida. Por favor, insira novamente (dd/mm/yyyy):");
                            }
                            dataVolta = dataTemp;
                        }

                        // Localizando aeroportos de origem e destino na lista de voos
                        Aeroporto? origem = listaVoos.Select(v => v.AeroportoOrigem)
                                .FirstOrDefault(a => a.Sigla.Equals(codigoOrigem, StringComparison.OrdinalIgnoreCase));

                        Aeroporto? destino = listaVoos.Select(v => v.AeroportoDestino)
                                                      .FirstOrDefault(a => a.Sigla.Equals(codigoDestino, StringComparison.OrdinalIgnoreCase));
                        if (origem == null || destino == null)
                        {
                            Console.WriteLine("Aeroporto de origem ou destino inválido.");
                            return;
                        }

                        Console.WriteLine($"Pesquisando voos de {origem.Nome} PARA {destino.Nome} (Ida: {dataIda.ToShortDateString()})...");
                        var voosIda = Passagem.PesquisarVoos(listaVoos, codigoOrigem, codigoDestino, dataIda);
                        ExibirVoos(voosIda);

                        Passagem passagem = new Passagem();

                        foreach (var voo in voosIda)
                        {
                            passagem.AdicionarVoo(voo);
                        }

                        if (dataVolta.HasValue)
                        {
                            Console.WriteLine($"Pesquisando voos de {destino.Nome} PARA {origem.Nome} (Volta: {dataVolta.Value.ToShortDateString()})...");
                            var voosVolta = Passagem.PesquisarVoos(listaVoos, codigoDestino, codigoOrigem, dataVolta.Value);
                            ExibirVoos(voosVolta);

                            // Adicionando voos de volta à passagem
                            foreach (var voo in voosVolta)
                            {
                                passagem.AdicionarVoo(voo);
                            }
                        }

                        // Calculando a tarifa total
                        // float tarifaTotal = passagem.CalcularTarifaTotal();
                        // Console.WriteLine($"\nTarifa total da passagem: {tarifaTotal} {voosIda.First().Moeda}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        // Menu Funcionário
        public static void ExibirMenuFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            while (true)
            {
                {
                    Console.Clear();
                    Console.WriteLine(" _______________ ");
                    Console.WriteLine("|Menu Funcionarios|");
                    Console.WriteLine("| Código |       Opções                   |");
                    Console.WriteLine("|   1    |  Realizar Login                |");
                    Console.WriteLine("|   2    |  Cadastrar funcionarios        |");
                    Console.WriteLine("|   3    |  Listar funcionarios           |");
                    Console.WriteLine("|   4    |  Excluir funcionarios          |");
                    Console.WriteLine("|   0    |  Sair                          |");
                    Console.WriteLine("|_|");
                    Console.WriteLine("Insira o código do menu e digite 'Enter'");

                    string? opcaoFuncionario = Console.ReadLine();

                    switch (opcaoFuncionario)
                    {
                        case "1":
                            Console.WriteLine("Digite seu login:");
                            string login = Console.ReadLine()!;

                            Console.WriteLine("Digite seu senha:");
                            string senha = Console.ReadLine()!;

                            bool loginRealizado = funcionario.LoginFuncionario(login, senha);

                            if (loginRealizado)
                            {
                                Console.WriteLine("Bem Vindo(a)!");
                                ExibirMenuVoo();
                            }
                            else
                            {
                                Console.WriteLine("Login ou senha incorretos. Selecione qualquer tecla para voltar ao menu de funcionarios.");
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Digite o Nome:");
                            string nome = Console.ReadLine()!;

                            Console.WriteLine("Digite o CPF:");
                            string cpf = Console.ReadLine()!;

                            Console.WriteLine("Digite o Email");
                            string email = Console.ReadLine()!;

                            Console.WriteLine("Digite o Login:");
                            string loginFunc = Console.ReadLine()!;

                            Console.WriteLine("Digite a Senha:");
                            string senhaFunc = Console.ReadLine()!;

                            funcionario.CriarFuncionario(nome, cpf, email, loginFunc, senhaFunc);
                            break;
                        case "3":
                            funcionario.ListarFuncionario();
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.WriteLine("Digite o CPF do cliente a ser excluído:");
                            string cpfExcluir = Console.ReadLine()!;
                            bool removido = funcionario.ExcluirFuncionario(cpfExcluir);

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
                            Console.WriteLine("Saindo do menu de funcionários...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente...");
                            Console.ReadKey();
                            break;
                    }
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
                Console.WriteLine("\nAeroporto criado com sucesso!\n");
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
                double valorDemaisBagagens = double.Parse(Console.ReadLine());

                CiaAerea ciaAerea = new CiaAerea(nome, codigo, razaoSocial, cnpj, valorPrimeiraBagagem, valorDemaisBagagens);

                // Exibe os dados do aeroporto criado
                Console.WriteLine("Companhia Aérea criada com sucesso!");
                ciaAerea.ExibirDadosCiaAerea();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }
        }
    }


}
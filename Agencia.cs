using System.Globalization;
using System;

namespace Agencia_De_Viagens
{
    public class Agencia : ILog
    {
         public List<CartaoEmbarque> CartoesEmbarque { get; set; } = new List<CartaoEmbarque>();
        public List<CiaAerea> CompanhiasAereas { get; set; }
        public List<Aeroporto> Aeroportos { get; set; }
        public List<Passagem> Passagens { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Voo> Voos { get; set; }
        public Voo voo { get; set; }
        public Aeronave Aeronave { get; set; }

        public Agencia()
        {
            CompanhiasAereas = new List<CiaAerea>();
            Passagens = new List<Passagem>();
            Funcionarios = new List<Funcionario>();
            Clientes = new List<Cliente>();
            Aeroportos = new List<Aeroporto>();
            Voos = new List<Voo>();
            CartoesEmbarque = new List<CartaoEmbarque>();
        }
        public void CriarCliente(Funcionario funcionarioResponsavelPelaCriacao)
        {
            if (funcionarioResponsavelPelaCriacao.AcessoSistema)
            {
                var cliente = new Cliente("Joao", "12361213229", "12123123", "john.doe@email.com", "994360123");
                Clientes.Add(cliente);
            }
            else
            {
                Console.WriteLine("");
            }
        }
        
        public void CriarFuncionario(string nome, string cpf, string email)
        {
            var funcionario = new Funcionario(nome, cpf, email);
            funcionario.CriarAcessoSistema($"{cpf}_user", $"{email}_password");
            Funcionarios.Add(funcionario);
        }

        public bool ExcluirFuncionario(string cpf)
        {
            Funcionario? funcionarioEncontrado = Funcionarios.Find(c => c.CPF == cpf);

            if (funcionarioEncontrado != null)
            {
                Funcionarios.Remove(funcionarioEncontrado);
                Console.WriteLine("Funcionário(a) excluído com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Funcionário(a) não encontrado!");
                return false;
            }
        }

        public bool LoginFuncionario(string login, string senha)
        {
            // Busca o funcionário na lista de funcionários pelo login e senha
            Funcionario? funcionarioLogin = Funcionarios
                .FirstOrDefault(f => f.Login == login && f.Senha == senha);

            if (funcionarioLogin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CriarCompaniaAerea()
        {
            CompanhiasAereas.Add(new CiaAerea("LATAM", 123, "Brasil", "São Paulo", 1000.0, 1500.0));
            CompanhiasAereas.Add(new CiaAerea("Azul Linhas Aereas", 456, "Brasil", "Barueri", 800.0, 1100.0));

            if (CompanhiasAereas.Count == 0)
            {
                Console.WriteLine("Nenhuma companhia aérea criada.");
                return;
            }
            else
            {
                Console.WriteLine("\nCompanhia Aerea criada com sucesso!");
            }
             foreach (var companhia in CompanhiasAereas)
            {
                companhia.Exibir();
            }
        }
        
        // public void CriarAeroporto()
        // {
        //     var aeronave1 = new Aeronave("Boeing 737", 180, 200, 6);
        //     var aeronave2 = new Aeronave("Airbus A320", 150, 180, 6);
        //     Aeroportos.Add(new Aeroporto("Aeroporto Internacional de Confins", "CNF", "Belo Horizonte", "BH", "Brasil"));
        //     Aeroportos.Add(new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil"));
        //     Aeroportos[0].AdicionarAeronave(aeronave1);
        //     Aeroportos[1].AdicionarAeronave(aeronave2);
        // }

        public void CriarAeroporto()
        {
            // Criação dos aeroportos
            Aeroportos.Add(new Aeroporto("Aeroporto Internacional de Confins", "CNF", "Belo Horizonte", "BH", "Brasil"));
            Aeroportos.Add(new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil"));

            // Exibição do status
            if (Aeroportos.Count == 0)
            {
                Console.WriteLine("\nNenhum aeroporto criado.");
            }
            else
            {
                Console.WriteLine("\nAeroportos criados com sucesso!");
                foreach (var aeroporto in Aeroportos)
                {
                    aeroporto.Exibir();
                }
            }

            // Criação das aeronaves
            var aeronave1 = new Aeronave("Boeing 737", 250, 250, 150);
            var aeronave2 = new Aeronave("Airbus A320", 150, 150, 45);
            var aeronave3 = new Aeronave("Embraer E195-E2", 100, 100, 80);

            // Adiciona as aeronaves aos aeroportos
            Aeroportos[0].AdicionarAeronave(aeronave1);
            Aeroportos[1].AdicionarAeronave(aeronave2);
            Aeroportos[2].AdicionarAeronave(aeronave3);
        }

    
        public void CriarPassagem()
        {
            var aeroportoOrigem = Aeroportos.FirstOrDefault(a => a.Sigla == "CNF");
            var aeroportoDestino = Aeroportos.FirstOrDefault(a => a.Sigla == "GRU");

            if (aeroportoOrigem == null || aeroportoDestino == null)
            {
                Console.WriteLine("Aeroporto de origem ou destino não encontrado.");
                return;
            }

            var dataPartida = new DateTime(2024, 11, 01, 8, 0, 0);

            // Procura o voo correspondente
            var voo = Voos.FirstOrDefault(v =>
                v.AeroportoOrigem == aeroportoOrigem &&
                v.AeroportoDestino == aeroportoDestino &&
                v.Frequencia.Dias.Contains(dataPartida.DayOfWeek) &&
                v.Frequencia.Hora == dataPartida.ToString("HH:mm") &&
                v.DataPartida >= dataPartida
            );

            if (voo == null)
            {
                Console.WriteLine("Voo correspondente não encontrado.");
                foreach (var v in Voos)
                {
                    Console.WriteLine($"Verificando Voo: {v.Codigo} - Partida: {v.DataPartida} - Origem: {v.AeroportoOrigem.Sigla} - Destino: {v.AeroportoDestino.Sigla}");
                }
                return;
            }

            List<Voo> listaVoosPassagem = new List<Voo> { voo };

            var passagem = new Passagem(
                Passagem.GerarCodigoRota(),
                aeroportoOrigem,
                aeroportoDestino,
                voo.CiaAerea,
                voo.DataPartida,
                voo.DataChegada,
                "BRL",
                15.0,
                16.0,
                18.0,
                TipoPassagemEnum.Nacional,
                listaVoosPassagem,
                StatusEnum.Ativo
            );

            Passagens.Add(passagem);
            Console.WriteLine($"\nPassagem criada com sucesso: {passagem.Codigo}");
        }

        // public void ComprarPassagens(string cpfCliente, string codigoPassagem)
        // {
        //     var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

        //     if (cliente == null)
        //     {
        //         Console.WriteLine("Cliente não encontrado.");
        //         return;
        //     }

        //     var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);
        //     // cliente.AdicionarPassagemComprada(passagemComprada);

        //     if (passagemComprada == null)
        //     {
        //         Console.WriteLine("Passagem não encontrada.");
        //         return;
        //     }
        //     else
        //     {
        //         passagemComprada.ExibirPassagem();
        //     }
        //     Console.WriteLine("Qual será a quantidade de bagagens?");
        //     int quantidade = int.Parse(Console.ReadLine());

        //     List<Aeronave> aeronaves = passagemComprada.AeroportoOrigem.ObterAeronaves();

        //     // Verifica se a lista de aeronaves não está vazia e se há aeronave disponível
        //     if (aeronaves != null && aeronaves.Count > 0)
        //     {
        //         Aeronave aeronave = aeronaves.First(); 
        //         aeronave.CadastrarBagagens(quantidade);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Não há aeronaves disponíveis para este voo.");
        //     }

        //     Aeronave.CadastrarBagagens(quantidade);

        //     cliente.AdicionarPassagemComprada(passagemComprada);
        //     passagemComprada.ExibirPassagem();

        //     ReservarAssentoParaPassageiro(cliente, passagemComprada.AeroportoOrigem.Sigla, aeronaves);

        //     Notificacao notifica = new Notificacao();
        //     // notifica.EnviarEmail(email, mensagem);
        // }

        public void ComprarPassagens(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                Console.WriteLine("\nPassagem não encontrada.");
                return;
            }

            Console.WriteLine("\nQual será a quantidade de bagagens?");
            int quantidade = int.Parse(Console.ReadLine());

            // Verificar se a passagem tem um AeroportoOrigem válido
            if (passagemComprada.AeroportoOrigem != null)
            {
                List<Aeronave> aeronaves = passagemComprada.AeroportoOrigem.ObterAeronaves();

                // Verificar se a lista de aeronaves não é nula ou vazia
                if (aeronaves != null && aeronaves.Count > 0)
                {
                    Aeronave aeronave = aeronaves.First(); // Aqui você pode usar a lógica para escolher uma aeronave específica
                    aeronave.CadastrarBagagens(quantidade); // Adicionar as bagagens
                }
                else
                {
                    Console.WriteLine("\nNão há aeronaves disponíveis para este voo.");
                }

                // Agora, com aeronaves válidas, você pode reservar o assento
                ReservarAssentoParaPassageiro(cliente, passagemComprada.AeroportoOrigem.Sigla, aeronaves);
            }
            else
            {
                Console.WriteLine("\nAeroporto de origem não encontrado na passagem.");
            }

            cliente.AdicionarPassagemComprada(passagemComprada);
            cliente.AdicionarVooAoHistorico(passagemComprada.Voos);
            passagemComprada.ExibirPassagem();

            Notificacao notifica = new Notificacao();
            notifica.EnviarEmail(cliente.Email);
        }

        public void ExibirClientes(List<Cliente> clientes)
        {
            if (clientes == null || clientes.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente encontrado.");
                return;
            }

            Console.WriteLine("Lista de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Email: {cliente.Email}");
            }
        }

        public void EmitirBilhete(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemBilhete = cliente.PassagensCompradas.FirstOrDefault(p => p.Codigo == codigoPassagem);

            cliente.AdicionarPassagemComprada(passagemBilhete);

            // Verifica se a passagem foi encontrada
            if (passagemBilhete == null)
            {
                Console.WriteLine("\nPassagem não encontrada entre as passagens compradas pelo cliente.");
                return;
            }

            if (passagemBilhete.TipoPassagem == TipoPassagemEnum.Nacional)
            {
                Console.WriteLine("\n" + new string('-', 30));
                Console.WriteLine("EMITINDO BILHETE PARA VOO DOMESTICO");
                Console.WriteLine($"Código do Voo: {passagemBilhete.Codigo}");
                Console.WriteLine($"Aeroporto de Origem: {passagemBilhete.AeroportoOrigem.Nome} ({passagemBilhete.AeroportoOrigem.Sigla})");
                Console.WriteLine($"Aeroporto de Destino: {passagemBilhete.AeroportoDestino.Nome} ({passagemBilhete.AeroportoDestino.Sigla})");

                if (passagemBilhete.AeroportoConexao != null)
                {
                    Console.WriteLine($"Aeroporto de Conexão: {passagemBilhete.AeroportoConexao.Nome} ({passagemBilhete.AeroportoConexao.Sigla})");
                }

                Console.WriteLine($"Data de Partida: {passagemBilhete.DataPartida:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Data de Chegada: {passagemBilhete.DataChegada:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Nome do Passageiro: {cliente.Nome}");
                Console.WriteLine($"Documento: {cliente.RG ?? cliente.CPF}"); // RG ou CPF
                Console.WriteLine(new string('-', 30));
            }
            else if (passagemBilhete.TipoPassagem == TipoPassagemEnum.Internacional)
            {
                Console.WriteLine("\n" + new string('-', 30));
                Console.WriteLine("EMITINDO BILHETE PARA VOO INTERNACIONAL");
                Console.WriteLine($"Código do Voo: {passagemBilhete.Codigo}");
                Console.WriteLine($"Aeroporto de Origem: {passagemBilhete.AeroportoOrigem.Nome} ({passagemBilhete.AeroportoOrigem.Sigla})");
                Console.WriteLine($"Aeroporto de Destino: {passagemBilhete.AeroportoDestino.Nome} ({passagemBilhete.AeroportoDestino.Sigla})");

                if (passagemBilhete.AeroportoConexao != null)
                {
                    Console.WriteLine($"Aeroporto de Conexão: {passagemBilhete.AeroportoConexao.Nome} ({passagemBilhete.AeroportoConexao.Sigla})");
                }

                Console.WriteLine($"Data de Partida: {passagemBilhete.DataPartida:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Data de Chegada: {passagemBilhete.DataChegada:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Nome do Passageiro: {cliente.Nome}");
                Console.WriteLine($"Passaporte: {cliente.Passaporte}"); // Passaporte
                Console.WriteLine(new string('-', 30));
            }
            else
            {
                Console.WriteLine("\nTipo de passagem desconhecido.");
            }
        }

        public List<Passagem> BuscarVoos(string origem, string destino, DateTime data, string nome)
        {
            return Passagens.Where(v =>
                v.AeroportoOrigem.Sigla == origem &&
                v.AeroportoDestino.Sigla == destino &&
                v.DataPartida.DayOfWeek == data.DayOfWeek &&
                v.CiaAerea.Nome == nome
            ).ToList();
        }
        public List<Passagem> BuscarVoos(string codigoVoo)
        {
            return Passagens.Where(v =>
                v.Codigo == codigoVoo
            ).ToList();
        }
        public List<Passagem> BuscarVoos(DateTime dataPartida, DateTime dataChegada)
        {
            return Passagens.Where(v =>
                v.DataPartida == dataPartida &&
                v.DataChegada == dataChegada
            ).ToList();
        }

        public void CancelarVoo(string CodigoVoo, string codigoPassagem)
        {
            Console.WriteLine(CodigoVoo);
            var voo = Voos.FirstOrDefault(x => x.Codigo == CodigoVoo);

            if (voo != null)
            {
                if (voo.Status == StatusEnum.Ativo)
                {
                    voo.Status = StatusEnum.Cancelado;
                    Console.WriteLine($"\nO voo {CodigoVoo} foi cancelado com sucesso.");

                    foreach (var cliente in Clientes)
                    {
                        foreach (var passagem in cliente.PassagensCompradas)
                        {
                            if (passagem.Voos.Contains(voo) && passagem.Codigo == codigoPassagem)
                            {
                                cliente.CancelarPassagem(passagem.Codigo);

                                Console.WriteLine("\nQuantas bagagens foram inseridas?");
                                int quantidade = int.Parse(Console.ReadLine());

                                // Remove as bagagens usando o método RemoverBagagens
                                Aeronave.RemoverBagagens(quantidade);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\nO voo {CodigoVoo} já estava cancelado.");
                }
            }
            else
            {
                Console.WriteLine($"\nVoo {CodigoVoo} não encontrado.");
            }
        }

        public void ListarClientes()
        {
            if (Clientes.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente cadastrado!");
                return;
            }

            Console.WriteLine("\nCliente cadastrado com sucesso!");
            foreach (var cliente in Clientes)
            {
                cliente.Exibir();
            }
        }

        public void ListarPassagens()
        {
            if (Passagens.Count == 0)
            {
                return;
            }

            foreach (var passagem in Passagens)
            {
                passagem.ExibirPassagem();
            }
        }

        public void ListarFuncionario()
        {
            if (Funcionarios.Count == 0)
            {
                Console.WriteLine("\nNenhum funcionário(a) cadastrado!");
                return;
            }

            Console.WriteLine("\nFuncionário(a) cadastrado com sucesso!");
            foreach (var funcionario in Funcionarios)
            {
                funcionario.Exibir();
            }
        }

        public void CriarVoosPadrao()
        {
            var diasVoo = new List<DayOfWeek>
        {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
        };

        // TimeSpan duracaoVoo = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(10));
        var aeronave = Aeroportos.First().ObterAeronaves();

        CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "08:00", voo.CalculaHorarioPrevistoChegada(), aeronave[0]);
        CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "15:00", voo.CalculaHorarioPrevistoChegada(), aeronave[1]);
        CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "05:00", voo.CalculaHorarioPrevistoChegada(), aeronave[1]);
        }

        public void CriarVoo(Aeroporto origem, Aeroporto destino, CiaAerea ciaAerea, List<DayOfWeek> diasFrequencia, string horaPartida, DateTime duracao, Aeronave aeronave)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataFinal = dataAtual.AddDays(10);

            TimeSpan duracaoTimeSpan = duracao.TimeOfDay;

            for (DateTime data = dataAtual; data <= dataFinal; data = data.AddDays(1))
            {
                if (diasFrequencia.Contains(data.DayOfWeek))
                {
                    DateTime dataPartida = data.Date + TimeSpan.Parse(horaPartida);
                    DateTime dataChegada = dataPartida.Add(duracaoTimeSpan);
                    Voo novoVoo = new Voo(
                        origem,
                        destino,
                        ciaAerea,
                        dataPartida,
                        dataChegada,
                        diasFrequencia,
                        horaPartida,
                        StatusEnum.Ativo,
                        aeronave
                    );

                    Voos.Add(novoVoo);
                    novoVoo.Exibir();
                }
            }
        }

        public void ReservarAssentoParaPassageiro(Cliente passageiro, string aeroportoId, List<Aeronave> aeronaveId)
        {
            var aeroporto = Aeroportos.FirstOrDefault(a => a.Sigla == aeroportoId);
            if (aeroporto == null)
            {
                Console.WriteLine("\nAeroporto não encontrado.");
                return;
            }

            var aeronave = aeroporto.Aeronaves.FirstOrDefault(a => aeronaveId.Any(ai => ai.Nome == a.Nome));
            if (aeronave == null)
            {
                Console.WriteLine("\nAeronave não encontrada.");
                return;
            }

            aeronave.ExibirAssentosDisponiveis();
            Console.WriteLine("\nDigite o número do assento que deseja reservar:");
            string assentoEscolhido = Console.ReadLine();

            aeronave.ReservarAssento(assentoEscolhido, passageiro);
        }

        public void PromoverClienteParaVip(string cpfCliente)
        {
            Console.WriteLine("\nGostaria de se torna um cliente VIP? (Escreva apenas S ou N)");
            string vip = Console.ReadLine().Trim();;

            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (vip == "S")
            {
                cliente.TornarVip();
            }
            else if (vip == "N" )
            {
                Console.WriteLine("\nTudo bem! Vamos deixar para a próxima.");
            }
            else
            {
                Console.WriteLine("\nValor inválido.");
            }
        }

        public void FazerCheckIn(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                Console.WriteLine("\nPassagem não encontrada.");
                return;
            }

            // Verificar se a passagem está ativa
            if (passagemComprada.Status != StatusEnum.Ativo)
            {
                Console.WriteLine("\nA passagem não está ativa. Verifique o status da passagem.");
                return;
            }

            passagemComprada.RealizaCheckIn();
            passagemComprada.VerificaNoShow();
        }

        public void FazerCartaoEmbarque(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                Console.WriteLine("\nPassagem não encontrada.");
                return;
            }

            passagemComprada.GerarCartaoEmbarque();
        }

//-----MÉTODOS RELACIONADOS À SPRINT 4-----//
        public void RegistraLog(string registro)
        {
            Log log =  new Log();
            log.RegistraLog($"Dados do Sistema - {registro}");
        }

    }
}
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
        public List<Aeronave> Aeronaves{ get; set; }
        public Voo voo { get; set; }
        public Aeronave aeronave { get; set; }
        private readonly ILog _logger;

        public Agencia(ILog log)
        {
            CompanhiasAereas = new List<CiaAerea>();
            Passagens = new List<Passagem>();
            Funcionarios = new List<Funcionario>();
            Clientes = new List<Cliente>();
            Aeroportos = new List<Aeroporto>();
            Voos = new List<Voo>();
            CartoesEmbarque = new List<CartaoEmbarque>();
            _logger = log;
            _logger.RegistraLog($"Agência inicializada.");
        }

        public void RegistraLog(string registro)
        {
            Log log = new Log();
            log.RegistraLog($"Dados do Sistema - {registro}");
        }

        public void CriarCliente(Funcionario funcionarioResponsavelPelaCriacao)
        {
            if (funcionarioResponsavelPelaCriacao.AcessoSistema)
            {
                var cliente = new Cliente("Joao", "12361213229", "12123123", "john.doe@email.com", "994360123", false);
                Clientes.Add(cliente);
                _logger.RegistraLog($"Cliente criado. {cliente.Nome}, {cliente.CPF}, {cliente.Email}");
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
            _logger.RegistraLog($"Funcionario cadastrado: {funcionario.CPF}, {funcionario.Email}.");
        }

        public bool ExcluirFuncionario(string cpf)
        {
            Funcionario? funcionarioEncontrado = Funcionarios.Find(c => c.CPF == cpf);

            if (funcionarioEncontrado != null)
            {
                Funcionarios.Remove(funcionarioEncontrado);
                Console.WriteLine("Funcionário(a) excluído com sucesso!");
                _logger.RegistraLog($"Funcionário(a) excluído com sucesso: {funcionarioEncontrado.CPF}, {funcionarioEncontrado.Email}.");
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
                _logger.RegistraLog($"Login efetuado com sucesso: {funcionarioLogin.CPF}, {funcionarioLogin.Email}.");
                return true;
            }
            else
            {
                _logger.RegistraLog($"Houeve um problema ao efetuar o login do funcionario!");
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
                _logger.RegistraLog($"ERR: Não foi possível criar as companhias aereas!");
                return;
            }
            else
            {
                Console.WriteLine("\nCompanhia Aerea criada com sucesso!");
                _logger.RegistraLog($"Companhias aereas criadas com sucesso.");
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
            Aeroportos.Add(new Aeroporto("Aeroporto Internacional de Confins", "CNF", "Belo Horizonte", "BH", "Brasil", 19, 43));
            Aeroportos.Add(new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil", 23, 46));

            // Exibição do status
            if (Aeroportos.Count == 0)
            {
                Console.WriteLine("\nNenhum aeroporto criado.");
                _logger.RegistraLog($"ERR: Não foi possível criar os aeroportos!");
            }
            else
            {
                Console.WriteLine("\nAeroportos criados com sucesso!");
                _logger.RegistraLog($"nAeroportos criados com sucesso.");
                foreach (var aeroporto in Aeroportos)
                {
                    aeroporto.Exibir();
                }
            }

            // Criação das aeronaves
            var aeronave1 = new Aeronave("Boeing 737", 250, 250, 30, 850f);
            var aeronave2 = new Aeronave("Airbus A320", 150, 150, 45, 850f);
            var aeronave3 = new Aeronave("Embraer E195-E2", 150, 150, 43, 850f);

            
            // Adiciona as aeronaves aos aeroportos
            Aeroportos[0].AdicionarAeronave(aeronave1);
            Aeroportos[0].AdicionarAeronave(aeronave2);
            Aeroportos[1].AdicionarAeronave(aeronave3);
        }


        public void CriarPassagem()
        {
            var aeroportoOrigem = Aeroportos.FirstOrDefault(a => a.Sigla == "CNF");
            var aeroportoDestino = Aeroportos.FirstOrDefault(a => a.Sigla == "GRU");

            if (aeroportoOrigem == null || aeroportoDestino == null)
            {
                Console.WriteLine("Aeroporto de origem ou destino não encontrado.");
                _logger.RegistraLog($"ERR: Aeroporto de origem ou destino não encontrado!");
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

            voo.DataChegada = voo.CalculaHorarioPrevistoChegada();

            var passagem = new Passagem(
                _logger,
                Passagem.GerarCodigoRota(),
                aeroportoOrigem,
                aeroportoDestino,
                voo.CiaAerea,
                voo.DataPartida,
                voo.DataChegada,
                "BRL",
                15.0,
                20.0,
                18.0,
                TipoPassagemEnum.Nacional,
                listaVoosPassagem,
                StatusEnum.Ativo
            );

            Passagens.Add(passagem);
            Console.WriteLine($"\nPassagem criada com sucesso: {passagem.Codigo}");
            _logger.RegistraLog($"Passagem criada com sucesso: {passagem.Codigo}.");
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
            int quantidade = 5;
            int bagagemExtra = cliente.IsVip ? 0 : 1;

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                _logger.RegistraLog($"ERR: Cliente não encontrado!");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                Console.WriteLine("\nPassagem não encontrada.");
                _logger.RegistraLog($"ERR: nPassagem não encontrada!");
                return;
            }

            passagemComprada.Bagagem = quantidade;
            passagemComprada.BagagensExtras = bagagemExtra;

            // Console.WriteLine("\nQual será a quantidade de bagagens?");
            // int quantidade = int.Parse(Console.ReadLine());

            // Verificar se a passagem tem um AeroportoOrigem válido
            if (passagemComprada.AeroportoOrigem != null)
            {
                List<Aeronave> aeronaves = passagemComprada.AeroportoOrigem.ObterAeronaves();

                if(cliente.IsVip = true)
                {
                    // Verificar se a lista de aeronaves não é nula ou vazia
                    if (aeronaves != null && aeronaves.Count > 0)
                    {
                        Aeronave aeronave = aeronaves.First();

                        Console.WriteLine("\nSuas bagagens adicionais serão incluídas sem custo extra.");

                        int bagagemAdicional = aeronave.CadastrarBagagens(quantidade, bagagemExtra);

                        passagemComprada.BagagensExtras = bagagemAdicional;
                        // aeronave.CadastrarBagagens(quantidade);
                    }
                    else
                    {
                        Console.WriteLine("\nNão há aeronaves disponíveis para este voo.");
                        _logger.RegistraLog($"ERR:Não há aeronaves disponíveis para este voo!");
                    }
                }
                
                _logger.RegistraLog($"Reservando assemnto para passageiro...");
                // Agora, com aeronaves válidas, você pode reservar o assento
                ReservarAssentoParaPassageiro(cliente, passagemComprada.AeroportoOrigem.Sigla, aeronaves);
            }
            else
            {
                _logger.RegistraLog($"ERR: Aeroporto de origem não encontrado na passagem!");
                Console.WriteLine("\nAeroporto de origem não encontrado na passagem.");
            }

            cliente.AdicionarPassagemComprada(passagemComprada);
            // cliente.AdicionarVooAoHistorico(passagemComprada.Voos);
            // passagemComprada.ExibirPassagem();
            _logger.RegistraLog($"Exibindo passagem comprada...");
            passagemComprada.ExibirPassagemFinal(cliente.IsVip);

            _logger.RegistraLog($"Enviando notificação para comprador...");
            Notificacao notifica = new Notificacao();
            notifica.EnviarEmail(cliente.Email);
        }

        public void ExibirClientes(List<Cliente> clientes)
        {
            if (clientes == null || clientes.Count == 0)
            {
                _logger.RegistraLog($"ERR: Nenhum cliente encontrado!");
                Console.WriteLine("\nNenhum cliente encontrado.");
                return;
            }
            
            _logger.RegistraLog($"Exibindo lista de clientes...");
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
                _logger.RegistraLog($"ERR: Cliente não encontrado!");
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemBilhete = cliente.PassagensCompradas.FirstOrDefault(p => p.Codigo == codigoPassagem);

            cliente.AdicionarPassagemComprada(passagemBilhete);

            // Verifica se a passagem foi encontrada
            if (passagemBilhete == null)
            {
                _logger.RegistraLog($"ERR: Passagem não encontrada entre as passagens compradas pelo cliente!");
                Console.WriteLine("\nPassagem não encontrada entre as passagens compradas pelo cliente.");
                return;
            }

            _logger.RegistraLog($"Emitindo bilhete...");
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
                Console.WriteLine($"Duração do Voo: {(passagemBilhete.DataChegada - passagemBilhete.DataPartida):hh\\:mm}");
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
                _logger.RegistraLog($"ERR: Tipo de passagem inválida!");
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
            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);
            var voo = Voos.FirstOrDefault(x => x.Codigo == CodigoVoo);
            var aeronave = voo?.Aeronave;

            if (voo != null)
            {
                if (voo.Status == StatusEnum.Ativo)
                {
                    voo.Status = StatusEnum.Cancelado;
                    _logger.RegistraLog($"Voo foi cancelado com sucesso.");
                    Console.WriteLine($"\nO voo {CodigoVoo} foi cancelado com sucesso!");

                    for (int i = 0; i < Clientes.Count; i++)
                    {
                        var cliente = Clientes[i];

                        for (int j = 0; j < cliente.PassagensCompradas.Count; j++)
                        {
                            var passagem = cliente.PassagensCompradas[j];

                            if (passagem.Voos.Contains(voo) && passagem.Codigo == codigoPassagem)
                            {
                                _logger.RegistraLog($"Cancelando passagem...");
                                cliente.CancelarPassagem(passagem.Codigo);

                                if (aeronave != null)
                                {
                                    _logger.RegistraLog($"Removendo bagagens...");
                                    aeronave.RemoverBagagens(passagem.Bagagem, passagem.BagagensExtras);
                                }
                            }
                        }
                    }
                }
                else
                {
                    _logger.RegistraLog($"Voo {voo.Codigo} já estava cancelado.");
                    Console.WriteLine($"\nO voo {CodigoVoo} já estava cancelado.");
                }
            }
            else
            {
                _logger.RegistraLog($"ERR: Voo não encontrado!");
                Console.WriteLine($"\nVoo {CodigoVoo} não encontrado.");
            }
        }

        public void ListarClientes()
        {
            if (Clientes.Count == 0)
            {
                 _logger.RegistraLog($"ERR: Nenhum cliente cadastrado!");
                Console.WriteLine("\nNenhum cliente cadastrado!");
                return;
            }

            _logger.RegistraLog($"Cliente cadastrado com sucesso.");
            Console.WriteLine("\nCliente cadastrado com sucesso!");
            foreach (var cliente in Clientes)
            {
                cliente.Exibir();
            }
        }

        public void ListarPassagens(string cpfCliente)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                _logger.RegistraLog($"ERR: Cliente não encontrado!");   
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            if (Passagens.Count == 0)
            {
                _logger.RegistraLog($"ERR: Não há passagens disponíveis!"); 
                Console.WriteLine("\nNão há passagens disponíveis.");
                return;
            }

            foreach (var passagem in Passagens)
            {
                // passagem.ExibirPassagem();
                _logger.RegistraLog($"Exibindo passagem..."); 
                passagem.ExibirBuscaPassagem(cliente.IsVip);
            }
        }

        public void ListarFuncionario()
        {
            if (Funcionarios.Count == 0)
            {
                _logger.RegistraLog($"ERR: Nenhum funcionário(a) cadastrado!");
                Console.WriteLine("\nNenhum funcionário(a) cadastrado!");
                return;
            }

            _logger.RegistraLog($"Funcionário(a) cadastrado com sucesso.");
            Console.WriteLine("\nFuncionário(a) cadastrado com sucesso!");
            foreach (var funcionario in Funcionarios)
            {
                funcionario.Exibir();
            }
        }

        public void CriarVoosPadrao()
        {
            _logger.RegistraLog($"Verificando aeroportos e aeronaves associadas...");
            Console.WriteLine("\nVerificando aeroportos e aeronaves associadas...");
            foreach (var aeroporto in Aeroportos)
            {
                Console.WriteLine($"\nAeroporto: {aeroporto.Nome}");
                var aeronaves = aeroporto.ObterAeronaves();
                Console.WriteLine($"Número de aeronaves associadas: {aeronaves.Count}");
                foreach (var aviao in aeronaves)
                {
                    Console.WriteLine($" - {aviao.Nome}");
                }
            }
            
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

            if (aeronave.Count < 2)
            {
                Console.WriteLine("Erro: Não há aeronaves suficientes no aeroporto de origem para criar os voos.");
                return;
            }

            CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "08:00", aeronave[0]);
            CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "15:00", aeronave[1]);
        }

        public void CriarVoo(Aeroporto origem, Aeroporto destino, CiaAerea ciaAerea, List<DayOfWeek> diasFrequencia, string horaPartida, Aeronave aeronave)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataFinal = dataAtual.AddDays(10);

            // TimeSpan duracaoTimeSpan = duracao.TimeOfDay;

            for (DateTime data = dataAtual; data <= dataFinal; data = data.AddDays(1))
            {
                if (diasFrequencia.Contains(data.DayOfWeek))
                {
                    DateTime dataPartida = data.Date + TimeSpan.Parse(horaPartida);
                    // DateTime dataChegada = dataPartida.Add(duracaoTimeSpan);

                    Voo novoVoo = new Voo(
                        origem,
                        destino,
                        ciaAerea,
                        dataPartida,
                        // dataChegada,
                        diasFrequencia,
                        horaPartida,
                        StatusEnum.Ativo,
                        aeronave
                    );

                    float tempoViagemHoras = novoVoo.CalculaTempoViagem();
                    TimeSpan tempoViagem = TimeSpan.FromHours(tempoViagemHoras);
                    novoVoo.DataChegada = dataPartida.Add(tempoViagem);

                    _logger.RegistraLog($"Adicionando voos...");
                    Voos.Add(novoVoo);
                    _logger.RegistraLog($"Exibindo voos...");
                    novoVoo.Exibir();
                }
            }
        }

        public void ReservarAssentoParaPassageiro(Cliente passageiro, string aeroportoId, List<Aeronave> aeronaveId)
        {
            var assentoEscolhido = "1A";
            var aeroporto = Aeroportos.FirstOrDefault(a => a.Sigla == aeroportoId);
            if (aeroporto == null)
            {
                _logger.RegistraLog($"ERR: Aeroporto não encontrado!");
                Console.WriteLine("\nAeroporto não encontrado.");
                return;
            }

            var aeronave = aeroporto.Aeronaves.FirstOrDefault(a => aeronaveId.Any(ai => ai.Nome == a.Nome));
            if (aeronave == null)
            {
                _logger.RegistraLog($"ERR: Aeronave não encontrada!");
                Console.WriteLine("\nAeronave não encontrada.");
                return;
            }
            
            _logger.RegistraLog($"Exibindo assentos disponíveis...");
            aeronave.ExibirAssentosDisponiveis();
            // Console.WriteLine("\nDigite o número do assento que deseja reservar:");
            // string assentoEscolhido = Console.ReadLine();

            _logger.RegistraLog($"Reservando assento escolhido...");
            aeronave.ReservarAssento(assentoEscolhido, passageiro);
        }

        public void PromoverClienteParaVip(string cpfCliente, string vip)
        {
            // Console.WriteLine("\nGostaria de se torna um cliente VIP? (Escreva apenas S ou N)");
            // string vip = Console.ReadLine().Trim();
            _logger.RegistraLog($"Verificando se o cliente é VIP...");

            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);
            var ClienteStatusVip = cliente.IsVip;

            if (vip == "S")
            {
                ClienteStatusVip = true;
                cliente.TornarVip(ClienteStatusVip);
            }
            else if (vip == "N")
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
            _logger.RegistraLog($"Realizando Check In...");
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                 _logger.RegistraLog($"ERR: Cliente não encontrado!");
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                _logger.RegistraLog($"ERR: Passagem não encontrada!");
                Console.WriteLine("\nPassagem não encontrada.");
                return;
            }

            // Verificar se a passagem está ativa
            if (passagemComprada.Status != StatusEnum.Ativo)
            {
                _logger.RegistraLog($"ERR: Passagem está inativa!");
                Console.WriteLine("\nA passagem não está ativa. Verifique o status da passagem.");
                return;
            }
            _logger.RegistraLog($"Iniciando Check In...");
            passagemComprada.RealizaCheckIn();

            // passagemComprada.VerificaNoShow();

        }

        public void FazerCartaoEmbarque(string cpfCliente, string codigoPassagem)
        {
            _logger.RegistraLog($"Gerando cartão de embarque...");
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                _logger.RegistraLog($"ERR: Cliente não encontrado!");
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                _logger.RegistraLog($"ERR: nPassagem não encontrada!");
                Console.WriteLine("\nPassagem não encontrada.");
                return;
            }

            // passagemComprada.GerarCartaoEmbarque();
        }

    }
}
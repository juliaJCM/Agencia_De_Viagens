using System.Globalization;
using System;

namespace Agencia_De_Viagens
{
    public class Agencia
    {
        public List<CiaAerea> CompanhiasAereas { get; set; }
        public List<Aeroporto> Aeroportos { get; set; }
        public List<Passagem> Passagens { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Voo> Voos { get; set; }
        public Aeronave Aeronave { get; set; }

        public Agencia()
        {
            CompanhiasAereas = new List<CiaAerea>();
            Passagens = new List<Passagem>();
            Funcionarios = new List<Funcionario>();
            Clientes = new List<Cliente>();
            Aeroportos = new List<Aeroporto>();
            Voos = new List<Voo>();
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
            var aeronave1 = new Aeronave("Boeing 737", 180, 200, 6);
            var aeronave2 = new Aeronave("Airbus A320", 150, 180, 6);

            // Adiciona as aeronaves aos aeroportos
            Aeroportos[0].AdicionarAeronave(aeronave1);
            Aeroportos[1].AdicionarAeronave(aeronave2);
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

        // public void ComprarPassagens(string cpfCliente, string codigoPassagem, string email, string mensagem)
        public void ComprarPassagens(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);
            cliente.AdicionarPassagemComprada(passagemComprada);

            if (passagemComprada == null)
            {
                Console.WriteLine("Passagem não encontrada.");
                return;
            }
            else
            {
                passagemComprada.ExibirPassagem();
            }
            Console.WriteLine("Qual será a quantidade de bagagens?");
            int quantidade = int.Parse(Console.ReadLine());

            Aeronave.CadastrarBagagens(quantidade);

            cliente.AdicionarPassagemComprada(passagemComprada);

            passagemComprada.ExibirPassagem();

            List<Aeronave> aeronaves = passagemComprada.AeroportoOrigem.ObterAeronaves();

            ReservarAssentoParaPassageiro(cliente, passagemComprada.AeroportoOrigem.Sigla, aeronaves);

            Notificacao notifica = new Notificacao();
            // notifica.EnviarEmail(email, mensagem);
        }

        public void ExibirClientes(List<Cliente> clientes)
        {
            if (clientes == null || clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente encontrado.");
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
            Console.WriteLine(cpfCliente);
            Console.WriteLine(codigoPassagem);

            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var passagemBilhete = cliente.PassagensCompradas.FirstOrDefault(p => p.Codigo == codigoPassagem);

            cliente.AdicionarPassagemComprada(passagemBilhete);

            Console.WriteLine(passagemBilhete);

            // Verifica se a passagem foi encontrada
            if (passagemBilhete == null)
            {
                Console.WriteLine("Passagem não encontrada entre as passagens compradas pelo cliente.");
                return;
            }

            if (passagemBilhete.TipoPassagem == TipoPassagemEnum.Nacional)
            {
                Console.WriteLine("Emitindo bilhete para voo doméstico:");
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
            }
            else if (passagemBilhete.TipoPassagem == TipoPassagemEnum.Internacional)
            {
                Console.WriteLine("Emitindo bilhete para voo internacional:");
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
            }
            else
            {
                Console.WriteLine("Tipo de passagem desconhecido.");
            }
        }
        public List<Passagem> BuscarVoos(string origem, string destino, DateTime data)
        {
            return Passagens.Where(v =>
                v.AeroportoOrigem.Sigla == origem &&
                v.AeroportoDestino.Sigla == destino &&
                v.DataPartida.DayOfWeek == data.DayOfWeek
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
            var voo = Voos.FirstOrDefault(x => x.Codigo == CodigoVoo);
            if (voo != null)
            {
                if (voo.Status == StatusEnum.Ativo)
                {
                    voo.Status = StatusEnum.Cancelado;
                    Console.WriteLine($"O voo {CodigoVoo} foi cancelado com sucesso.");

                    foreach (var cliente in Clientes)
                    {
                        foreach (var passagem in cliente.PassagensCompradas)
                        {
                            if (passagem.Voos.Contains(voo) && passagem.Codigo == codigoPassagem)
                            {
                                cliente.CancelarPassagem(passagem.Codigo);

                                Console.WriteLine("Quantas bagagens foram inseridas?");
                                int quantidade = int.Parse(Console.ReadLine());

                                // Remove as bagagens usando o método RemoverBagagens
                                Aeronave.RemoverBagagens(quantidade);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"O voo {CodigoVoo} já estava cancelado.");
                }
            }
            else
            {
                Console.WriteLine($"Voo {CodigoVoo} não encontrado.");
            }
        }
        public void ListarClientes()
        {
            if (Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
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
                Console.WriteLine("Nenhum funcionário(a) cadastrado!");
                return;
            }

            Console.WriteLine("Funcionário(a) cadastrado com sucesso!");
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

        TimeSpan duracaoVoo = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(10));

        CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "08:00", duracaoVoo);
        CriarVoo(Aeroportos.First(), Aeroportos.Last(), CompanhiasAereas.First(), diasVoo, "15:00", duracaoVoo);
        }

        public void CriarVoo(Aeroporto origem, Aeroporto destino, CiaAerea ciaAerea, List<DayOfWeek> diasFrequencia, string horaPartida, TimeSpan duracao)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataFinal = dataAtual.AddDays(30);

            for (DateTime data = dataAtual; data <= dataFinal; data = data.AddDays(1))
            {
                if (diasFrequencia.Contains(data.DayOfWeek))
                {
                    DateTime dataPartida = data.Date + TimeSpan.Parse(horaPartida);
                    DateTime dataChegada = dataPartida.Add(duracao);
                    Voo novoVoo = new Voo(
                        origem,
                        destino,
                        ciaAerea,
                        dataPartida,
                        dataChegada,
                        diasFrequencia,
                        horaPartida,
                        StatusEnum.Ativo
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
                Console.WriteLine("Aeroporto não encontrado.");
                return;
            }

            var aeronave = aeroporto.Aeronaves.FirstOrDefault(a => aeronaveId.Any(ai => ai.Nome == a.Nome));
            if (aeronave == null)
            {
                Console.WriteLine("Aeronave não encontrada.");
                return;
            }

            aeronave.ExibirAssentosDisponiveis();
            Console.WriteLine("Digite o número do assento que deseja reservar:");
            string assentoEscolhido = Console.ReadLine();

            aeronave.ReservarAssento(assentoEscolhido, passageiro);
        }
        public void PromoverClienteParaVip(string cpfCliente)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente != null)
            {
                // Lógica de promoção, por exemplo, baseado em histórico de voos
                if (cliente.HistoricoDeVoos.Count >= 5)
                {
                    cliente.TornarVip();
                }
                else
                {
                    Console.WriteLine("Cliente não atende aos requisitos para ser promovido a VIP.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

    }
}
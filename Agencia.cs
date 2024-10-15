namespace Agencia_De_Viagens
{
    public class Agencia
    {
        public List<CiaAerea> CompanhiasAereas { get; private set; }
        public List<Passagem> Passagens { get; private set; }
        public List<Cliente> Clientes { get; set; }
        public List<Funcionario> Funcionarios { get; private set; }
        public List<Aeroporto> Aeroportos { get; private set; }

        public Agencia()
        {
            CompanhiasAereas = new List<CiaAerea>();
            Passagens = new List<Passagem>();
            Funcionarios = new List<Funcionario>();
            Clientes = new List<Cliente>();
            Aeroportos = new List<Aeroporto>();
        }
        public void CriarCliente(Funcionario funcionarioResponsavelPelaCriacao)
        {
            if (funcionarioResponsavelPelaCriacao.AcessoSistema)
            {
                var cliente = new Cliente("Joao", "12361213229", "12123123", "john.doe@email.com", "passaporte");
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
                Console.WriteLine("Funcionário excluído com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado!");
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
        }
        public void CriarAeroporto()
        {
            // Adiciona um aeroporto à lista
            Aeroportos.Add(new Aeroporto("Aeroporto Internacional de Confins", "CNF", "Belo Horizonte", "BH", "Brasil"));
            Aeroportos.Add(new Aeroporto("Aeroporto de Guarulhos", "GRU", "São Paulo", "SP", "Brasil"));
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

            var passagem = new Passagem(
                Passagem.GerarCodigoRota(),
                aeroportoOrigem,
                aeroportoDestino,
                new CiaAerea("LATAM", 123, "Brasil", "São Paulo", 1000.0, 1500.0),
                new DateTime(2024, 10, 11, 20, 0, 0), // data de partida
                new DateTime(2024, 10, 12, 8, 0, 0),  // data de chegada
                "BRL",
                15.0,
                16.0,
                18.0,
                TipoPassagemEnum.Nacional,
                aeroportoDestino);

            Passagens.Add(passagem);
        }

        public void ComprarPassagens(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var passagemComprada = Passagens.FirstOrDefault(p => p.Codigo == codigoPassagem);

            if (passagemComprada == null)
            {
                Console.WriteLine("Passagem não encontrada.");
                return;
            }

            cliente.AdicionarPassagemComprada(passagemComprada);
        }

        public void EmitirBilhete(string cpfCliente, string codigoPassagem)
        {
            var cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var passagemBilhete = cliente.PassagensCompradas.FirstOrDefault(p => p.Codigo == codigoPassagem);

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
                Console.WriteLine("Nenhum funcionário cadastrado!");
                return;
            }

            Console.WriteLine("Clientes Funcionarios:");
            foreach (var funcionario in Funcionarios)
            {
                funcionario.Exibir();
            }
        }
    }
}
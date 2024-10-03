using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Agencia_De_Viagens
{
    public class Funcionario
    {
        // Lista estática para armazenar os funcionários
        static List<Funcionario> Funcionarios = new List<Funcionario>();

        // Propriedades públicas para acesso externo, se necessário
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public bool AcessoSistema { get; private set; } = false;
        public string? Login { get; private set; }
        public string? Senha { get; private set; }

        // Método para criar um novo funcionário
        public bool CriarFuncionario(string nome, string cpf, string email, string login, string senha)
        {
            if (Funcionarios.Exists(c => c.CPF == cpf))
            {
                Console.WriteLine("Funcionario com o mesmo CPF já existe!");
                return false;
            }

            Funcionario novoFuncionario = new Funcionario
            {
                Nome = nome,
                CPF = cpf,
                Email = email,
                Login = login,
                Senha = senha
            };

            Funcionarios.Add(novoFuncionario);
            Console.WriteLine("Funcionário criado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        // Método para criar acesso ao sistema para o funcionário
        public void CriarAcessoSistema(string login, string senha)
        {
            Login = login;
            Senha = senha;
            AcessoSistema = true;
        }

        // Método para listar todos os funcionários
         public void ListarFuncionario()
        {
            if (Funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado!");
                return;
            }

            Console.WriteLine("Clientes cadastrados:");
            foreach (var funcionario in Funcionarios)
            {
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"CPF: {funcionario.CPF}");
                Console.WriteLine($"Email: {funcionario.Email}");
                Console.WriteLine($"Login: {funcionario.Login}");
                Console.WriteLine($"Senha: {funcionario.Senha}");
                Console.WriteLine(new string('-', 30));
            }
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
    }
}

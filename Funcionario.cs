using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
    public void CriarFuncionario(string nome, string cpf, string email, string login, string senha)
    {
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
    }

    // Método para criar acesso ao sistema para o funcionário
    public void CriarAcessoSistema(string login, string senha)
    {
        Login = login;
        Senha = senha;
        AcessoSistema = true;
    }

    // Método para listar todos os funcionários
    public void ListarFuncionarios()
    {
        if (Funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado!");
            return;
        }

        foreach (var funcionario in Funcionarios)
        {
            Console.WriteLine($"Nome: {funcionario.Nome}");
            Console.WriteLine($"CPF: {funcionario.CPF}");
            Console.WriteLine($"Email: {funcionario.Email}");
            Console.WriteLine($"Acesso ao sistema: {funcionario.AcessoSistema}");
            Console.WriteLine($"Login: {funcionario.Login}");
            Console.WriteLine($"Senha: {funcionario.Senha}");
            Console.WriteLine(new string('-', 30));
        }
    }

    public bool ExcluirFuncionario(string cpf)
    {
        // Procura o funcionário com o CPF fornecido
        Funcionario? funcionarioEncontrado = Funcionarios.Find(f => f.CPF == cpf);

        // Verifica se encontrou o funcionário
        if (funcionarioEncontrado != null)
        {
            Funcionarios.Remove(funcionarioEncontrado);
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool LoginFuncionario(string senha, string login)
    {
        // Busca o funcionário na lista de funcionários pelo login e senha
        Funcionario? funcionarioLogin = Funcionarios
            .FirstOrDefault(f => f.Login == login && f.Senha == senha);

        if (funcionarioLogin != null)
        {
            Console.WriteLine("Login realizado com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Login ou senha incorretos. Tente novamente.");
            return false;
        }
    }
}

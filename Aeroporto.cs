using System;

public class Aeroporto
{
    public string Nome { get; set; }
    public char Sigla { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }

    // Construtor opcional
    public Aeroporto(string nome, char sigla, string cidade, string estado, string pais)
    {
        this.Nome = nome;
        this.Sigla = sigla;
        this.Cidade = cidade;
        this.Estado = estado;
        this.Pais = pais;
    }

    // Método para criar um aeroporto
    public bool CriarAeroporto(string nome, char sigla, string estado, string pais)
    {
        // Validação básica
        if (string.IsNullOrEmpty(nome) || char.IsWhiteSpace(sigla) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(pais))
        {
            Console.WriteLine("Dados inválidos. Aeroporto não criado.");
            return false;
        }

        // Atribuindo valores passados aos atributos da instância
        this.Nome = nome;
        this.Sigla = sigla;
        this.Estado = estado;
        this.Pais = pais;

        // Aqui poderia haver lógica adicional, como salvar no banco de dados
        Console.WriteLine("Aeroporto criado com sucesso!");
        return true;
    }
}

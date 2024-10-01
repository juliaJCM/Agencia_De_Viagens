using System;

public class CiaAerea
{
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string RazaoSocial { get; set; }
    public string CNPJ { get; set; }
    public float ValorPrimeiraBagagem { get; set; }
    public float ValorDemaisBagagens { get; set; }

    // Construtor opcional
    public CiaAerea(string nome, int codigo, string razaoSocial, string cnpj, float valorPrimeiraBagagem, float valorDemaisBagagens)
    {
        this.Nome = nome;
        this.Codigo = codigo;
        this.RazaoSocial = razaoSocial;
        this. CNPJ = cnpj;
        this.ValorPrimeiraBagagem = valorPrimeiraBagagem;
        this.ValorDemaisBagagens = valorDemaisBagagens;
    }

    // Método para criar a companhia aérea
    public bool CriarCiaAerea(string nome, int codigo, string razaoSocial, string cnpj)
    {
        // Validação básica
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(razaoSocial) || string.IsNullOrEmpty(cnpj) || codigo <= 0)
        {
            Console.WriteLine("Dados inválidos. Companhia aérea não criada.");
            return false;
        }

        // Atribuindo valores passados aos atributos da instância
        this.Nome = nome;
        this.Codigo = codigo;
        this.RazaoSocial = razaoSocial;
        this.CNPJ = cnpj;

        // Aqui poderia haver lógica adicional, como salvar no banco de dados
        Console.WriteLine("Companhia aérea criada com sucesso!");
        return true;
    }
}

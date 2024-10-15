using System;

namespace Agencia_De_Viagens
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma nova agência
            Agencia agencia = new Agencia();

            // Criando funcionários
            agencia.CriarFuncionario("Maria", "12345678900", "maria@email.com");
            agencia.CriarFuncionario("Carlos", "09876543211", "carlos@email.com");

            // Listando funcionários
            agencia.ListarFuncionario();

            // Criando companhias aéreas
            agencia.CriarCompaniaAerea();

            // Criando aeroportos
            agencia.CriarAeroporto();

            // Criando clientes
            Funcionario funcionario = agencia.Funcionarios[0]; // teste com Primeiro
            agencia.CriarCliente(funcionario);

            // Listando clientes
            agencia.ListarClientes();

            // Criando passagens
            agencia.CriarPassagem();

            // Listando passagens
            agencia.ListarPassagens();

            // Comprando passagens
            string cpfCliente = agencia.Clientes[0].CPF; // teste com Primeiro
            string codigoPassagem = agencia.Passagens[0].Codigo; // teste com Primeiro
            agencia.ComprarPassagens(cpfCliente, codigoPassagem);

            // Emitindo bilhete
            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            // Buscando voos
            var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11));
            Console.WriteLine("Voos encontrados:");
            foreach (var voo in voosEncontrados)
            {
                voo.ExibirPassagem();
            }

            // Excluindo funcionário
            agencia.ExcluirFuncionario("12345678900");
            agencia.ListarFuncionario();
        }
    }
}

using System;

namespace Agencia_De_Viagens
{
    class Program
    {
        static void Main(string[] args)
        {
            Agencia agencia = new Agencia();

            agencia.CriarFuncionario("Maria", "12345678900", "maria@email.com");
            agencia.CriarFuncionario("Carlos", "09876543211", "carlos@email.com");

            agencia.ListarFuncionario();

            agencia.CriarCompaniaAerea();

            agencia.CriarAeroporto();

            Funcionario funcionario = agencia.Funcionarios[0]; // teste com Primeiro
            agencia.CriarCliente(funcionario);

            agencia.ListarClientes();


            agencia.CriarVoosPadrao();


            agencia.CriarPassagem();

            // agencia.ListarPassagens();


            string cpfCliente = agencia.Clientes[0].CPF; // teste com Primeiro
            string codigoPassagem = agencia.Passagens[0].Codigo; // teste com Primeiro

            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            // Buscando voos
            var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11));
            Console.WriteLine("Voos encontrados:");
            foreach (var voo in voosEncontrados)
            {
                voo.ExibirPassagem();
            }
            agencia.ComprarPassagens(cpfCliente, codigoPassagem);


            // agencia.CancelarVoo(); passar no parametro codigoVooCliente e codigoPassagemCliente
            // agencia.ExcluirFuncionario("12345678900");
            // agencia.ListarFuncionario();
        }
    }
}
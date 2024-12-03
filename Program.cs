using System;
using System.Security.Cryptography;

namespace Agencia_De_Viagens
{
    class Program
    {
        static void Main(string[] args)
        {
            Agencia agencia = new Agencia();

            agencia.CriarFuncionario("Maria Moreira", "12345678900", "maria@email.com");
            agencia.ListarFuncionario();

            Funcionario funcionario = agencia.Funcionarios[0];
            agencia.CriarCliente(funcionario);
            agencia.ListarClientes();

            agencia.CriarCompaniaAerea();
            agencia.CriarAeroporto();

            agencia.CriarVoosPadrao();

            agencia.CriarPassagem();
            agencia.ListarPassagens();

            string cpfCliente = agencia.Clientes[0].CPF; 
            string codigoPassagem = agencia.Passagens[0].Codigo; 

            //Buscando voos
            var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11), "LATAM");
            Console.WriteLine("\nVOOS ENCONTRADOS");
            foreach (var voo in voosEncontrados)
            {
                voo.ExibirPassagem();
            }

            agencia.ComprarPassagens(cpfCliente, codigoPassagem);
            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            agencia.PromoverClienteParaVip(cpfCliente);

            agencia.FazerCheckIn(cpfCliente, codigoPassagem);

            agencia.FazerCartaoEmbarque(cpfCliente, codigoPassagem);

            // agencia.CancelarVoo(codigoVoo, codigoPassagem);
            // agencia.ExcluirFuncionario("12345678900");
            // agencia.ListarFuncionario();
        }
    }
}
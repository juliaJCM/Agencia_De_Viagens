using System;
using System.Security.Cryptography;

namespace Agencia_De_Viagens
{
    class Program
    {
        
        
        //------------------CENÁRIO 2----------------\\
        public static void PrimeiroCenarioTeste()
        {
            ILog log = new Log("system_log.txt");
            Agencia agencia = new Agencia(log);
            
            // Criar um funcionário
            agencia.CriarFuncionario("Maria Moreira", "12345678900", "maria@email.com");
            agencia.ListarFuncionario();

            // Criar um cliente associado ao funcionário
            Funcionario funcionario = agencia.Funcionarios[0];
            agencia.CriarCliente(funcionario);
            agencia.ListarClientes();

            // Criar um aeroporto
            agencia.CriarAeroporto();

            // Criar uma companhia aérea
            agencia.CriarCompaniaAerea();

            // Criar voos padrão
            agencia.CriarVoosPadrao();

            // Criar uma passagem
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
            agencia.PromoverClienteParaVip(cpfCliente);

            agencia.ComprarPassagens(cpfCliente, codigoPassagem);
                        
            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            agencia.FazerCheckIn(cpfCliente, codigoPassagem);
        }

        static void Main(string[] args)
        {
            PrimeiroCenarioTeste();

            // agencia.CriarFuncionario("Maria Moreira", "12345678900", "maria@email.com");
            // agencia.ListarFuncionario();

            // Funcionario funcionario = agencia.Funcionarios[0];
            // agencia.CriarCliente(funcionario);
            // agencia.ListarClientes();

            // agencia.CriarAeroporto();
            // agencia.CriarCompaniaAerea();

            // agencia.CriarVoosPadrao();

            // agencia.CriarPassagem();
            // agencia.ListarPassagens();

            // string cpfCliente = agencia.Clientes[0].CPF; 
            // string codigoPassagem = agencia.Passagens[0].Codigo; 

            // //Buscando voos
            // var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11), "LATAM");
            // Console.WriteLine("\nVOOS ENCONTRADOS");
            // foreach (var voo in voosEncontrados)
            // {
            //     voo.ExibirPassagem();
            // }

            // agencia.ComprarPassagens(cpfCliente, codigoPassagem);

            // agencia.FazerCheckIn(cpfCliente, codigoPassagem);

            // agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            // agencia.PromoverClienteParaVip(cpfCliente);

            // agencia.FazerCartaoEmbarque(cpfCliente, codigoPassagem);

            // agencia.CancelarVoo(codigoVoo, codigoPassagem);
            // agencia.ExcluirFuncionario("12345678900");
            // agencia.ListarFuncionario();
        }
        
    }
}
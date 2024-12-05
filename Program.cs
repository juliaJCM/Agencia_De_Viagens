using System;
using System.Security.Cryptography;

namespace Agencia_De_Viagens
{
    class Program
    {
        
        
        //------------------CENÁRIO 1----------------\\
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

            string cpfCliente = agencia.Clientes[0].CPF; 
            string codigoPassagem = agencia.Passagens[0].Codigo; 

            agencia.ListarPassagens(cpfCliente);

            //Buscando voos
            // var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11), "LATAM");
            // Console.WriteLine("\nVOOS ENCONTRADOS");
            // foreach (var voo in voosEncontrados)
            // {
            //     voo.ExibirPassagemFinal();
            // }

            agencia.ComprarPassagens(cpfCliente, codigoPassagem);
                        
            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            agencia.FazerCheckIn(cpfCliente, codigoPassagem);
        }
        
        //------------------CENÁRIO 2----------------\\
        public static void SegundoCenarioTeste()
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

            string cpfCliente = agencia.Clientes[0].CPF; 
            string codigoPassagem = agencia.Passagens[0].Codigo;
            string codigoVoo = agencia.Passagens[0].Voos[0].Codigo;

            agencia.PromoverClienteParaVip(cpfCliente, "S");

            agencia.ListarPassagens(cpfCliente);

            //Buscando voos
            // var voosEncontrados = agencia.BuscarVoos("CNF", "GRU", new DateTime(2024, 10, 11), "LATAM");
            // Console.WriteLine("\nVOOS ENCONTRADOS");

            // foreach (var voo in voosEncontrados)
            // {
            //     voo.ExibirPassagem();
            // }
            
            agencia.ComprarPassagens(cpfCliente, codigoPassagem);
                        
            agencia.EmitirBilhete(cpfCliente, codigoPassagem);

            agencia.CancelarVoo(codigoVoo, codigoPassagem);
        }

        static void Main(string[] args)
        {
            //------------------CENÁRIOS PARA TESTES SOLICITADOS NA SPRINT 4----------------\\
            // PrimeiroCenarioTeste();
            SegundoCenarioTeste();


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
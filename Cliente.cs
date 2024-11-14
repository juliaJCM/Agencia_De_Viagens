using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Passaporte { get; set; }
        public List<Passagem> PassagensCompradas { get; set; }
        public List<Passagem> PassagensCanceladas { get; set; }
        public Aeronave Aeronave { get; set; }
        public List<Voo> HistoricoDeVoos { get; private set; } = new List<Voo>();
        public bool IsVip { get; set; }

        public Cliente(string nome, string cpf, string rg, string email, string passaporte)
        {
            Nome = nome;
            CPF = cpf;
            RG = rg;
            Email = email;
            Passaporte = passaporte;
            PassagensCompradas = new List<Passagem>();
            PassagensCanceladas = new List<Passagem>();

        }

        // Método para criar um novo registro de cliente

        public void AdicionarPassagemComprada(Passagem passagemComprada)
        {
            PassagensCompradas.Add(passagemComprada);
            Console.WriteLine("Passagem comprada com susesso!");
        }
        public void CancelarPassagem(string codigoPassagem)
        {
            var passagem = PassagensCompradas.FirstOrDefault(p => p.Codigo == codigoPassagem);
            if (passagem != null)
            {
                passagem.Status = StatusEnum.Cancelado;
                PassagensCompradas.Remove(passagem);
                PassagensCanceladas.Add(passagem);

                // Aeronave.LiberarAssento(); //deveria ter assento do cliente em passagem

                Console.WriteLine($"A passagem {codigoPassagem} foi cancelada com sucesso!");
            }
            else
            {
                Console.WriteLine($"Passagem {codigoPassagem} não encontrada.");
            }
        }

        public void Exibir()
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"RG: {RG}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Passaporte: {Passaporte}");
            Console.WriteLine(new string('-', 30));
        }

        public void AdicionarVooAoHistorico(Voo voo)
        {
            // Adiciona o voo ao histórico
            HistoricoDeVoos.Add(voo);

            // Ordena os voos por data de partida (ordem cronológica)
            HistoricoDeVoos = HistoricoDeVoos.OrderBy(v => v.DataPartida).ToList();
        }

        public void ExibirHistoricoDeVoos()
        {
            if (HistoricoDeVoos.Count == 0)
            {
                Console.WriteLine("O cliente não possui nenhum voo registrado.");
                return;
            }

            Console.WriteLine("Histórico de Voos:");
            foreach (var voo in HistoricoDeVoos)
            {
                // Exibe as informações de cada voo (método da classe Voo)
                voo.ExibirVoo(); 
            }
        }
        
            public void TornarVip()
        {
            if (!IsVip)
            {
                IsVip = true;
                Console.WriteLine($"Parabéns! Você agora é um Passageiro VIP!");
                // Benefícios VIP podem ser ativados aqui, por exemplo, isenção de taxas.
            }
            else
            {
                Console.WriteLine($"Você já é um Passageiro VIP.");
            }
        }

        // Benefícios de Passageiro VIP: alteração e cancelamento de voo sem custo
        public void AlterarOuCancelarVoo(Passagem passagem, bool isAlteracao)
        {
            if (IsVip)
            {
                Console.WriteLine($"Voo {passagem.Codigo} alterado ou cancelado sem custos.");
                passagem.Status = isAlteracao ? StatusEnum.Ativo : StatusEnum.Cancelado;
            }
            else
            {
                Console.WriteLine("Somente clientes VIP podem alterar ou cancelar voos sem custos.");
            }
        }

        // Franquia de bagagem gratuita
        public void VerificarFranquiaBagagem()
        {
            if (IsVip)
            {
                Console.WriteLine("1 franquia de bagagem gratuita.");
            }
            else
            {
                Console.WriteLine("Verifique as franquias de bagagem padrão.");
            }
        }

        // Desconto nas franquias adicionais
        public void VerificarDescontoBagagemAdicional()
        {
            if (IsVip)
            {
                Console.WriteLine("Você possui desconto de 50% nas franquias de bagagem adicionais.");
            }
            else
            {
                Console.WriteLine("Verifique as tarifas de bagagem adicionais.");
            }
        }
    }
}


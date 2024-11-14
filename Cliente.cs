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
        public List<Voo> HistoricoDeVoos { get; set; } = new List<Voo>();
        public bool IsVip { get; set; }
        public StatusEnum status {get; set;}

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

        public void AdicionarPassagemComprada(Passagem passagemComprada)
        {
            PassagensCompradas.Add(passagemComprada);
            Console.WriteLine("\nPassagem comprada com sucesso!");
        }

        public void EmissaoBilhete(Passagem passagemBilhete)
        {
            PassagensCompradas.Add(passagemBilhete);
            Console.WriteLine("\nBilhete emitido com sucesso!");
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

                Console.WriteLine($"\nA passagem {codigoPassagem} foi cancelada com sucesso!");
            }
            else
            {
                Console.WriteLine($"\nPassagem {codigoPassagem} não encontrada.");
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

        public void AdicionarVooAoHistorico(List<Voo> voos)
        {
            if (status == StatusEnum.Embarque_Realizado)
            {
                // Adiciona o voo ao histórico
                foreach (var voo in voos)
                {
                    HistoricoDeVoos.Add(voo);
                }

                // Ordena os voos por data de partida (ordem cronológica)
                HistoricoDeVoos = HistoricoDeVoos.OrderBy(v => v.DataPartida).ToList();
                Console.WriteLine($"\nVoo {voos} adicionado ao histórico.");
            }
            else
            {
                Console.WriteLine("\nO voo não pode ser adicionado ao histórico porque o status do cliente não é 'Embarque_Realizado'.");
            }
        }

        public void ExibirHistoricoDeVoos()
        {
            if (HistoricoDeVoos.Count == 0)
            {
                Console.WriteLine("\nO cliente não possui nenhum voo registrado.");
                return;
            }

            Console.WriteLine("Histórico de Voos:");
            foreach (var voo in HistoricoDeVoos)
            {
                // Exibe as informações de cada voo (método da classe Voo)
                voo.Exibir(); 
            }
        }
        
            public void TornarVip()
        {
            if (!IsVip)
            {
                IsVip = true;
                Console.WriteLine("\n" + new string('-', 30));
                Console.WriteLine($"PARABÉNS! Você agora é um Passageiro VIP!");
                Console.WriteLine("\nEstes são os seu benefícios:");
                Console.WriteLine("Alteração e cancelamento de vôo sem custo");
                Console.WriteLine("1 franquia de passagem gratuita por viagem");
                Console.WriteLine("Franquias adicionais com desconto de 50%");
                Console.WriteLine(new string('-', 30));
            }
            else
            {
                Console.WriteLine($"\nVocê já é um Passageiro VIP");
            }
        }

        // Benefícios de Passageiro VIP: alteração e cancelamento de voo sem custo
        public void AlterarOuCancelarVoo(Passagem passagem, bool isAlteracao)
        {
            if (IsVip)
            {
                Console.WriteLine($"\nVoo {passagem.Codigo} alterado ou cancelado sem custos.");
                passagem.Status = isAlteracao ? StatusEnum.Ativo : StatusEnum.Cancelado;
            }
            else
            {
                Console.WriteLine("\nSomente clientes VIP podem alterar ou cancelar voos sem custos.");
            }
        }

        // Franquia de bagagem gratuita
        public void VerificarFranquiaBagagem()
        {
            if (IsVip)
            {
                Console.WriteLine("\n1 franquia de bagagem gratuita.");
            }
            else
            {
                Console.WriteLine("\nVerifique as franquias de bagagem padrão.");
            }
        }

        // Desconto nas franquias adicionais
        public void VerificarDescontoBagagemAdicional()
        {
            if (IsVip)
            {
                Console.WriteLine("\nVocê possui desconto de 50% nas franquias de bagagem adicionais.");
            }
            else
            {
                Console.WriteLine("\nVerifique as tarifas de bagagem adicionais.");
            }
        }
    }
}


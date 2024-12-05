using System;
using System.Collections.Generic;
using Agencia_De_Viagens;



public class Aeronave
{
    public string Nome { get; set; }
    public int CapacidadePassageiros { get; set; }
    public int CapacidadeBagagens { get; set; }
    public List<Cliente> PassageirosEmbarcados { get; set; }
    public List<string> Assentos { get; private set; }
    public int TotalBagagens { get; set; }
    public List<string> AssentosReservados { get; private set; }
    public StatusEnum status {get; set;}

    //-----ATRIBUTOS RELACIONADOS À SPRINT 4-----//
    public float VelocidadeMedia { get; set; }

    public Aeronave(string nome, int capacidadePassageiros, int capacidadeBagagens, int numeroFileiras, float velocidadeMedia)
    {
        Nome = nome;
        CapacidadePassageiros = capacidadePassageiros;
        CapacidadeBagagens = capacidadeBagagens;
        PassageirosEmbarcados = new List<Cliente>();
        Assentos = GerarAssentos(numeroFileiras);
        AssentosReservados = new List<string>();
        VelocidadeMedia = velocidadeMedia;

    }

    private List<string> GerarAssentos(int numeroFileiras)
    {
        List<string> assentos = new List<string>();
        char[] letrasAssento = { 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 1; i <= numeroFileiras; i++)
        {
            foreach (char letra in letrasAssento)
            {
                assentos.Add($"{i}{letra}");
            }
        }
        return assentos;
    }
    
    public void ExibirAssentosDisponiveis()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("ASSENTOS DISPONÍVEIS:");

        // Itera sobre cada linha de assentos (considerando que as linhas têm 6 assentos)
        for (int i = 0; i < Assentos.Count; i += 6)
        {
            // Primeira linha (assentos A, B, C, D)
            var primeiraLinha = Assentos.Skip(i).Take(4).ToList();
            // Segunda linha (assentos E, F)
            var segundaLinha = Assentos.Skip(i + 4).Take(2).ToList();

            // Exibe a primeira linha
            Console.Write("Linha " + ((i / 6) + 1) + ": ");
            foreach (var assento in primeiraLinha)
            {
                if (!AssentosReservados.Contains(assento))
                    Console.Write(assento + " ");
            }
            Console.WriteLine();  // Pula uma linha após exibir cada linha de assentos
        }
         Console.WriteLine(new string('-', 30));
    }   

    // public void ExibirAssentosDisponiveis()
    // {
    //     Console.WriteLine("\nASSENTOS DISPONÍVEIS:");
    //     foreach (var assento in Assentos)
    //     {
    //         if (!AssentosReservados.Contains(assento))
    //         {
    //             Console.WriteLine(assento);
    //         }
    //     }
    // }

    public bool ReservarAssento(string assento, Cliente passageiro)
    {
        if (!Assentos.Contains(assento))
        {
            Console.WriteLine("\nAssento inválido.");
            return false;
        }

        if (AssentosReservados.Contains(assento))
        {
            Console.WriteLine("\nAssento já reservado.");
            return false;
        }

        AssentosReservados.Add(assento);
        Console.WriteLine($"\nAssento {assento} reservado com sucesso para {passageiro.Nome}!");
        // InserirPassageiro(passageiro);
        return true;
    }

    public void LiberarAssento(string assento)
    {
        if (AssentosReservados.Contains(assento))
        {
            AssentosReservados.Remove(assento);
            Console.WriteLine($"\nAssento {assento} liberado para novas reservas.");
        }
        else
        {
            Console.WriteLine($"\nAssento {assento} não está reservado, não é possível liberá-lo.");
        }
    }
    public int CadastrarBagagens(int quantidade, int bagagemExtra)
    {
        if (TotalBagagens + quantidade <= CapacidadeBagagens)
        {
            TotalBagagens += quantidade;
            // Console.WriteLine($"\nDeseja incluir bagagens extras? Se sim, quantas?");
            if(bagagemExtra > 0 )
            {
                if(TotalBagagens + bagagemExtra <= CapacidadeBagagens)
                {
                    TotalBagagens += bagagemExtra;
                }
                else
                {
                    Console.WriteLine($"\nNão há capacidade suficiente para as bagagens extras.");
                    bagagemExtra = 0;
                }
            }
            // Console.ReadLine($"\nDeseja incluir bagagens extras? Se sim, quantas?");
            // int BagagemExtra = int.Parse(Console.ReadLine());

            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine($"INFORMAÇÕES DE BAGAGENS");
            Console.WriteLine($"Quantidade de bagagens principais: {quantidade}");
            if(bagagemExtra > 0)
            {
                 Console.WriteLine($"Bagagens extras: {bagagemExtra}");
                 Console.WriteLine($"Total: {quantidade + bagagemExtra}");
                 Console.WriteLine(new string('-', 30)); Console.WriteLine("");
                 return bagagemExtra;
            }
            else 
            {
                Console.WriteLine($"Total de bagagens: {quantidade}");
                Console.WriteLine(new string('-', 30)); Console.WriteLine("");
                return 0;
            }
        }
        else
        {
            Console.WriteLine("\nCapacidade de bagagens atingida. Não é possível adicionar mais.");
            return 0;
        }
    }

    public void RemoverBagagens(int quantidade, int bagagemExtra)
    {
        if (TotalBagagens - quantidade - bagagemExtra >= 0)
        {
            if(bagagemExtra > 0 )
            {
                var QtdeBagagem = quantidade += bagagemExtra;
                TotalBagagens -= QtdeBagagem;
                Console.WriteLine($"\n{quantidade} bagagens removidas.");
            }
            else 
            {
                TotalBagagens -= quantidade;
                Console.WriteLine($"\n{quantidade} bagagens removidas.");
            }
        }
        else
        {
            Console.WriteLine("\nNão é possível remover mais bagagens do que as atualmente registradas.");
        }
    }

    public void InserirPassageiro(Cliente passageiro)
    {
        if (PassageirosEmbarcados.Count < CapacidadePassageiros)
        {
            PassageirosEmbarcados.Add(passageiro);
            Console.WriteLine($"\nPassageiro {passageiro.Nome} embarcado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nCapacidade de passageiros atingida.");
        }
    }
}

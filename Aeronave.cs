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
    public Aeronave(string nome, int capacidadePassageiros, int capacidadeBagagens, int numeroFileiras)
    {
        Nome = nome;
        CapacidadePassageiros = capacidadePassageiros;
        PassageirosEmbarcados = new List<Cliente>();
        CapacidadeBagagens = capacidadeBagagens;
        Assentos = GerarAssentos(numeroFileiras);
        AssentosReservados = new List<string>();
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
        Console.WriteLine("Assentos disponíveis:");
        foreach (var assento in Assentos)
        {
            if (!AssentosReservados.Contains(assento))
            {
                Console.WriteLine(assento);
            }
        }
    }
    public bool ReservarAssento(string assento, Cliente passageiro)
    {
        if (!Assentos.Contains(assento))
        {
            Console.WriteLine("Assento inválido.");
            return false;
        }

        if (AssentosReservados.Contains(assento))
        {
            Console.WriteLine("Assento já reservado.");
            return false;
        }

        AssentosReservados.Add(assento);
        InserirPassageiro(passageiro);
        Console.WriteLine($"Assento {assento} reservado com sucesso para {passageiro.Nome}!");
        return true;
    }
    public void LiberarAssento(string assento)
    {
        if (AssentosReservados.Contains(assento))
        {
            AssentosReservados.Remove(assento);
            Console.WriteLine($"Assento {assento} liberado para novas reservas.");
        }
        else
        {
            Console.WriteLine($"Assento {assento} não está reservado, não é possível liberá-lo.");
        }
    }
    public void InserirPassageiro(Cliente passageiro)
    {
        if (PassageirosEmbarcados.Count < CapacidadePassageiros)
        {
            PassageirosEmbarcados.Add(passageiro);
            Console.WriteLine($"Passageiro {passageiro.Nome} embarcado com sucesso!");
        }
        else
        {
            Console.WriteLine("Capacidade de passageiros atingida.");
        }
    }

    public void CadastrarBagagens(int quantidade)
    {
        if (TotalBagagens + quantidade <= CapacidadeBagagens)
        {
            TotalBagagens += quantidade;
            Console.WriteLine($"{quantidade} bagagens adicionadas.");
        }
        else
        {
            Console.WriteLine("Capacidade de bagagens atingida.");
        }
    }
}

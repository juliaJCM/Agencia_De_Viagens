using System;
using System.Collections.Generic;
using System.Linq;

namespace Agencia_De_Viagens
{
    public class Passagem
    {
        public List<Voo> Voos { get; set; }

        // Construtor
        public Passagem()
        {
            Voos = new List<Voo>();
        }

        // public float CalcularTarifaTotal()
        // {
        //     return Voos.Sum(v => v.Tarifa);
        // }

        public static List<Voo> PesquisarVoos(List<Voo> listaVoos, string origem, string destino, DateTime data)
        {
            var voosEncontrados = listaVoos.Where(v =>
                v.AeroportoOrigem.Sigla == origem &&
                v.AeroportoDestino.Sigla == destino &&
                v.DataPartida.DayOfWeek == data.DayOfWeek
            ).ToList();

            return voosEncontrados;
        }

        // Método para adicionar voos à passagem
        public void AdicionarVoo(Voo voo)
        {
            if (Voos.Count < 2)
            {
                Voos.Add(voo);
            }
            else
            {
                Console.WriteLine("Já existem dois voos nesta passagem. Não é possível adicionar mais.");
            }
        }
    }
}

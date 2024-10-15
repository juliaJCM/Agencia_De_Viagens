using System;
using System.Collections.Generic;

namespace Agencia_De_Viagens
{
    public class Tarifa
    {
        public double TarifaBasica { get; private set; }
        public double TarifaPremium { get; private set; }
        public double TarifaBusiness { get; private set; }

        public Tarifa(double tarifaBasica, double tarifaPremium, double tarifaBusiness)
        {
            TarifaBasica = tarifaBasica;
            TarifaPremium = tarifaPremium;
            TarifaBusiness = tarifaBusiness;
        }
    }
}
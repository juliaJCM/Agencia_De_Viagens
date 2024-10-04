namespace Agencia_De_Viagens
{
    public class Passagem
    {
        public List<Voo> Voos { get; set; }

        public float CalcularTarifaTotal()
        {
            return Voos.Sum(v => v.ValorTarifaBasica);
        }
    }
}
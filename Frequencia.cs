namespace Agencia_De_Viagens
{
    public class Frequencia
    {
        public List<DayOfWeek> Dias { get; private set; }
        public string Hora { get; private set; }
        public Frequencia(List<DayOfWeek> dias, string hora)
        {
            Dias = dias;
            Hora = hora;
        }
    }
}
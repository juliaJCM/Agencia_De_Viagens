using System;

using Agencia_De_Viagens;
public class Notificacao
{
    public Passagem passagem { get; set; }
    public void EnviarNotificacao(Passagem passagem)
    {
        Cliente cliente = passagem.cliente;  

        EnviarEmail(cliente.Email);
    }

    public void EnviarEmail(string destinatario)
    {
        Console.WriteLine($"\nUm e-mail confirmando sua compra foi enviado para: {destinatario}");
    }
}
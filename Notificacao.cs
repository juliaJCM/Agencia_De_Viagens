using System;

using Agencia_De_Viagens;
public class Notificacao
{
    public Passagem passagem { get; set; }
    public void EnviarNotificacao(Passagem passagem)
    {
        Cliente cliente = passagem.cliente;  

        string mensagem = "Compra efetuada com sucesso!";

        EnviarEmail(cliente.Email, mensagem);
    }

    public void EnviarEmail(string destinatario, string mensagem)
    {
        // Exemplo de pseudocódigo:
        Console.WriteLine($"Enviando e-mail para: {destinatario}\nAssunto: {mensagem}");
    }
}
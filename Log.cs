using System;
using System.IO;

public class Log : ILog
{
    // private static readonly string FilePath = "system.log.txt";
    private readonly string FilePath;

    public Log(string filePath = "system_log.txt")
    {
        FilePath = filePath;
    }

    public void RegistraLog(string registro)
    {
        try{
            string mensagem = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {registro}";
            File.AppendAllText(FilePath, mensagem + Environment.NewLine);
        }
        catch (Exception er)
        {
            Console.WriteLine($"Erro ao resgitrar o log: {er.Message}");
        }
    }
}
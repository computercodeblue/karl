namespace Karl.Transport.Smtp;

public class SmtpTransportOptions
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 25;
    public string SecurityMode { get; set; } = "StartTlsRequired";
    public string? Username { get; set; }
    public string? Password { get; set; }
}

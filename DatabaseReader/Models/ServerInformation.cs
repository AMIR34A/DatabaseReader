namespace DatabaseReader.Models;

public class ServerInformation
{
    public string Server { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public AuthenticationMode AuthenticationMode { get; set; }
}

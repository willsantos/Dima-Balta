

namespace WS.Dima.Core.Models.Account;

public class User
{
    public string Email { get; set; } = String.Empty;
    public bool IsEmailConfirmed { get; set; }
    public Dictionary<string, string> Claims { get; set; } = [];

}
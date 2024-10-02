using WS.Dima.Core.Requests.Account;
using WS.Dima.Core.Responses;

namespace WS.Dima.Core.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}
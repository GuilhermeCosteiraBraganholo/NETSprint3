using Nous.Management.Api.Models;

namespace Nous.Management.Api.Services;

public interface IAuthService
{
    LoginResponse? Login(LoginRequest request);
}

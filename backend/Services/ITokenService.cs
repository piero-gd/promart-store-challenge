namespace PromartStore.API.Services;

public interface ITokenService
{
    string GenerateToken(string username);
}

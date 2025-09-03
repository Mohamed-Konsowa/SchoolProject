using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        Task<JwtAuthResult> GetJWTToken(User user);
        Task<JwtAuthResult> GetRefreshToken(string accessToken, string refreshToken);
        Task<string> ValidateToken(string accessToken);
    }
}

using Microsoft.AspNetCore.Identity;
using TrainingLine.Models;

namespace TrainingLine.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SighUpUserModel user);
        Task<SignInResult> PasswordSignInAsync(signIn signIn);
        Task SignOutAsync();

    }
}
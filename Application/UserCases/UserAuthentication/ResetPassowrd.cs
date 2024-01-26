using Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace Application.UserCases.UserAuthentication;

public class ResetPassowrd
{
    private UserManager<User> _user;
    public ResetPassowrd(UserManager<User> user)
    {
        _user = user;
    }
    public async Task<string> Reset(string email, string NewPassorwd)
    {
        var userFound = _user.Users.FirstOrDefault(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        var token = await _user.GeneratePasswordResetTokenAsync(userFound);
        var resultReset = await _user.ChangePasswordAsync(userFound, token, NewPassorwd);
        if (!resultReset.Succeeded)
        {
            return default;
        }
        return resultReset.Succeeded.ToString();
    }
}

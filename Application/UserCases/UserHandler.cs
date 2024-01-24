using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCases;

public class UserHandler
{
    private UserManager<User> _user;
    private SignInManager<User> _signinManager;
    private IMapper _mapper;
    public UserHandler(UserManager<User> user, SignInManager<User> signinManager,IMapper mapper)
    {
        _user = user;
        _signinManager = signinManager;
        _mapper = mapper;
    }
    public async Task<string> RegisterUser(CreateLoginRequest createLoginRequest)
    {
        User user = _mapper.Map<User>(createLoginRequest);

        IdentityResult result = await _user.CreateAsync(user,createLoginRequest.Password);
        
        if(!result.Succeeded) { throw new Exception("Falha ao criar cadastro"); }
        
        return result.Succeeded.ToString();
    }
    public async Task<string> LoginUser(LoginUserRequest loginUser)
    {
        var result = await _signinManager.PasswordSignInAsync(loginUser);
        
        if(!result.Succeeded) { throw new ApplicationException("Falha ao realizar o login"); }

        var user=_signinManager.UserManager.Users.FirstOrDefaultAsync(user=>user.Email.Equals(loginUser.email,StringComparison.OrdinalIgnoreCase));

        var token = _tokenService.GerenrateToken(usuario);
    }
}

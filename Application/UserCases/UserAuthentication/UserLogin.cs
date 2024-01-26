using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCases.UserAuthentication;

public class UserLogin : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private UserManager<User> _user;
    private SignInManager<User> _signinManager;
    private IMapper _mapper;
    private IToken _tokenService;
    public UserLogin(UserManager<User> user, SignInManager<User> signinManager, IMapper mapper, IToken tokenService)
    {
        _user = user;
        _signinManager = signinManager;
        _mapper = mapper;
        _tokenService = tokenService;

    }
    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _signinManager.PasswordSignInAsync(request.email, request.password, false, false);

        if (!result.Succeeded)
        {
            throw new Exception("Falha ao realizar o login");
        }

        User user = await _signinManager.UserManager.Users.FirstOrDefaultAsync(user => user.Email.Equals(request.email, StringComparison.OrdinalIgnoreCase));


        var token = _tokenService.GenerateToken(user);

        return _mapper.Map<LoginUserResponse>(token);
    }
}

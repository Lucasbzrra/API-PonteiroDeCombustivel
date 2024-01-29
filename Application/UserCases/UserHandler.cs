using Application.UserCases.Command;
using Application.UserCases.Query;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCases;

public class UserHandler :IRequestHandler<CreateLoginRequest, CreateLoginResponse>,
                         IRequestHandler<DeleteLoginRequest, DeleteLoginResponse>,
                         IRequestHandler<UpdateLoginRequest, UpdateLoginResponse>,
                         IRequestHandler<ReadLoginRequest,ReadLoginResponse>
{
    private UserManager<User> _user;
    private IMapper _mapper;
    public UserHandler(UserManager<User> user, SignInManager<User> signinManager, IMapper mapper)
    {
        _user = user;
        _mapper = mapper;
    }

    public async Task<CreateLoginResponse> Handle(CreateLoginRequest request, CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request);

        IdentityResult result = await _user.CreateAsync(user,request.Password);

        Console.WriteLine(result);
        if (!result.Succeeded)
        {
            throw new Exception("Falha ao criar cadastro");
        }

        return _mapper.Map<CreateLoginResponse>(user);
    }

    public async Task<DeleteLoginResponse> Handle(DeleteLoginRequest request, CancellationToken cancellationToken)
    {
        var LoginFound = _user.Users.FirstOrDefaultAsync(x => x.Email.Equals(request.email, StringComparison.OrdinalIgnoreCase));
        User user = _mapper.Map<User>(LoginFound);
        IdentityResult identityResult = await _user.DeleteAsync(user);
        if (!identityResult.Succeeded) { return default; }
        return _mapper.Map<DeleteLoginResponse>(user);
    }

    public async Task<UpdateLoginResponse> Handle(UpdateLoginRequest request, CancellationToken cancellationToken)
    {
        var LoginFound = await _user.Users.FirstOrDefaultAsync(x => x.Email.Equals(request.email, StringComparison.OrdinalIgnoreCase));
        User user= _mapper.Map<User>(LoginFound);
        IdentityResult identity= await _user.UpdateAsync(user);
        if (!identity.Succeeded) { return default; }
        return _mapper.Map<UpdateLoginResponse>(user);

    }

   public async Task<ReadLoginResponse> Handle(ReadLoginRequest request, CancellationToken cancellationToken)
    {
        var loginFound= await _user.Users.FirstOrDefaultAsync(login=>login.Email.Equals(request.email,StringComparison.OrdinalIgnoreCase));
        return _mapper.Map<ReadLoginResponse>(loginFound);

    }
}

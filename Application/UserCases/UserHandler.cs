using Application.UserCases.Command;
using Application.UserCases.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UserCases;

public class UserHandler :IRequestHandler<CreateLoginRequest, CreateLoginResponse>,
                         IRequestHandler<DeleteLoginRequest, DeleteLoginResponse>,
                         IRequestHandler<UpdateLoginRequest, UpdateLoginResponse>,
                         IRequestHandler<ReadLoginRequest,ReadLoginResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UserHandler(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateLoginResponse> Handle(CreateLoginRequest request, CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request);

    
        IdentityResult result = await _userManager.CreateAsync(user,request.Password);

        Console.WriteLine(result);
        if (!result.Succeeded)
        {
            throw new Exception("Falha ao criar cadastro");
        }

        return _mapper.Map<CreateLoginResponse>(user);
    }

    public async Task<DeleteLoginResponse> Handle(DeleteLoginRequest request, CancellationToken cancellationToken)
    {
        var LoginFound = _userManager.Users.FirstOrDefault(x => x.Email==request.email);
        User user = _mapper.Map<User>(LoginFound);
        IdentityResult identityResult = await _userManager.DeleteAsync(user);
        if (!identityResult.Succeeded) { return default; }
        return _mapper.Map<DeleteLoginResponse>(user);
    }

    public async Task<UpdateLoginResponse> Handle(UpdateLoginRequest request, CancellationToken cancellationToken)
    {
        var LoginFound = _userManager.Users.FirstOrDefault(x => x.Email==request.email);
        User user= _mapper.Map(request, LoginFound);
        IdentityResult identity= await _userManager.UpdateAsync(user);
        if (!identity.Succeeded) { return default; }
        return _mapper.Map<UpdateLoginResponse>(user);

    }

   public async Task<ReadLoginResponse> Handle(ReadLoginRequest request, CancellationToken cancellationToken)
    {
        var loginFound=   _userManager.Users.FirstOrDefault(lo=>lo.Email==request.email);
        Console.WriteLine(loginFound);
        var result=_mapper.Map<ReadLoginResponse>(loginFound);
        return result;

    }
}

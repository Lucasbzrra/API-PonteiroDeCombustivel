using MediatR;

namespace Application.UserCases;

public sealed record  LoginUserRequest(string email, string senha):IRequest<LoginUserResponse>;
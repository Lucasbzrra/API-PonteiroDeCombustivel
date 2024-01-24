using MediatR;

namespace Application.UserCases;

public sealed record  CreateLoginRequest(string Username, string Email, string Password, string Repassword) : IRequest<CreateLoginResponse>;
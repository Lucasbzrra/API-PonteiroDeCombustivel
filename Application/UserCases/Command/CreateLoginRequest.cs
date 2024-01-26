using Application.UserCases.Query;
using MediatR;

namespace Application.UserCases.Command;

public sealed record CreateLoginRequest(string Username, string Email, string Password, string Repassword) : IRequest<CreateLoginResponse>;
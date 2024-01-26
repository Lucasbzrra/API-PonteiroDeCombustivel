using Application.UserCases.Query;
using MediatR;

namespace Application.UserCases.Command;
public sealed record UpdateLoginRequest(string cpf, string email) : IRequest<UpdateLoginResponse>;
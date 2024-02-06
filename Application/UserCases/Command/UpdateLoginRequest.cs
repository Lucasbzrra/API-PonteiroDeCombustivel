using Application.UserCases.Query;
using MediatR;

namespace Application.UserCases.Command;
public sealed record UpdateLoginRequest(string username, string email) : IRequest<UpdateLoginResponse>;
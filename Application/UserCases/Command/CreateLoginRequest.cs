using Application.UserCases.Query;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.UserCases.Command;

public sealed record CreateLoginRequest(string UserName, string Email,  string Password, string RePassword) : IRequest<CreateLoginResponse>;
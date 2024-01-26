using Application.UserCases.Query;
using MediatR;

namespace Application.UserCases.Command;

public sealed record DeleteLoginRequest(string email) : IRequest<DeleteLoginResponse>;
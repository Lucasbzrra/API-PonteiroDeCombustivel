
using Application.UserCases.Query;
using MediatR;

namespace Application.UserCases.UserAuthentication;

public sealed record LoginUserRequest(string email, string password) : IRequest<LoginUserResponse>;
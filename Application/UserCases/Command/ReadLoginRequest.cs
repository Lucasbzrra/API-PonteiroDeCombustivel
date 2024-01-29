using MediatR;

namespace Application.UserCases.Command;

public sealed record class ReadLoginRequest(string email) : IRequest<ReadLoginResponse>;
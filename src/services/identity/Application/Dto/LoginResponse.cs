using IdentityApi.Domain.Entities;

namespace IdentityApi.Application.Dto;

public record LoginResponse(User User, string AccessToken);
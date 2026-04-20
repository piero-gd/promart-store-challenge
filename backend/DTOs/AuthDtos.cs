using System.ComponentModel.DataAnnotations;

namespace PromartStore.API.DTOs;

public record LoginRequestDto(
    [Required] string Username,
    [Required] string Password
);

public record LoginResponseDto(
    string Token,
    string Username
);

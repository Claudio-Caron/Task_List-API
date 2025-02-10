using System.ComponentModel.DataAnnotations;

namespace TaskList.Responses;

public record TaskResponse(int Id, string? Nome, string? Description, DateOnly Date, bool IsCompleted);

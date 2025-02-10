using System.ComponentModel.DataAnnotations;

namespace TaskList.Requests;

public record TaskRequestEdit([Required]int Id, bool IsCompleted, [Required]string Nome, string Description, DateOnly Date):
    TaskRequest(Nome, Description, Date);

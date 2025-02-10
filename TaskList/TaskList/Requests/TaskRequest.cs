using System.ComponentModel.DataAnnotations;

namespace TaskList.Requests;

public record TaskRequest([Required]string Name,string Description, DateOnly Date);

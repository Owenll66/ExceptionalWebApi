using System.ComponentModel.DataAnnotations;

namespace ExceptionTestWebApi.Requests;

public class RequestsForValidations
{
    [Required]
    public string Text { get; set; } = default!;

    [Range(0, 10)]
    public int number { get; set; }
}

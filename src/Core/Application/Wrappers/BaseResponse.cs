namespace Application.Wrappers;

public class BaseResponse
{
    public Guid Id { get; set; } = new Guid();

    public string Message { get; set; }

    public bool IsSuccess { get; set; }
}
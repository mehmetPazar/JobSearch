namespace Application.Wrappers;

public abstract class BaseResponse : RestModelBase
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Message { get; set; }

    public bool IsSuccess { get; set; }
}
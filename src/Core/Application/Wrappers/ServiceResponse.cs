namespace Application.Wrappers;

public class ServiceResponse<T> : BaseResponse
{
    public T Data { get; set; }

    public ServiceResponse(T data)
    {
        Data = data;
    }
}
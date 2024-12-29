using System.Net;

namespace ExpenseTrackerApi.Entities;

public class Payload<T>
{
    public Payload(T? content = default, int errCode = 0, object errMsg = null)
    {
        if (content == null && errMsg == null)
            throw new Exception($"At least {nameof(content)} or error message should has value");

        Content = content;
        Error = errMsg;
        ErrorCode = errCode;
        Success = content != null;
    }

    public bool Success { get; set; }
    public object Error { get; }
    public int ErrorCode { get; }
    public T? Content { get; }

    public static Payload<T> NotFound(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.NotFound, string.IsNullOrEmpty(message) ? "Item not found!" : message);
    }

    public static Payload<T> BadRequest(string message = "")
    {
        return new Payload<T>(default, (int)HttpStatusCode.BadRequest, string.IsNullOrEmpty(message) ? "Bad Request!" : message);
    }

    public static Payload<T> Dublicated(T data, string message = "")
    {
        return new Payload<T>(data, (int)HttpStatusCode.Ambiguous, string.IsNullOrEmpty(message) ? "Duplicated data!" : message);
    }

    public static Payload<T> Successfully(T data, string message = "")
    {
        return new Payload<T>(data, (int)HttpStatusCode.OK, string.IsNullOrEmpty(message) ? "OK" : message);
    }

    public static Payload<string> Successfully(string message = "")
    {
        return new Payload<string>("OK", (int)HttpStatusCode.OK, string.IsNullOrEmpty(message) ? "OK" : message);
    }
    public static Payload<T> ValidateModel(T data, object message = null)
    {
        return new Payload<T>(data, (int)HttpStatusCode.BadRequest, message);
    }
    public static Payload<List<T>> SuccessfullyLists(List<T> newUser)
    {
        return new Payload<List<T>>(newUser, (int)HttpStatusCode.ExpectationFailed, "OK");
    }

    public static Payload<T> CreatedFail(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.ExpectationFailed, string.IsNullOrEmpty(message) ? "Created Fail!" : message);
    }

    public static Payload<T> UpdatedFail(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.ExpectationFailed, string.IsNullOrEmpty(message) ? "Updated Fail!" : message);
    }

    public static Payload<T> DeletedFail(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.ExpectationFailed, string.IsNullOrEmpty(message) ? "Deleted Fail!" : message);
    }

    public static Payload<T> RequestInvalid(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.BadRequest, string.IsNullOrEmpty(message) ? "Request invalid!" : message);
    }

    public static Payload<T> ErrorInProcessing(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.InternalServerError, string.IsNullOrEmpty(message) ? "Error in processing!" : message);
    }

    public static Payload<T> DataValidationFail(string message = "", object data = null)
    {
        return new Payload<T>((T?)data, (int)HttpStatusCode.ExpectationFailed, string.IsNullOrEmpty(message) ? "Data Validation Fail!" : message);
    }
    public static Payload<string> NotModified(string message = "")
    {
        return new Payload<string>("Not Modified", (int)HttpStatusCode.NotModified, string.IsNullOrEmpty(message) ? "Not Modified" : message);
    }
    public static Payload<string> Unauthorized(string message = "")
    {
        return new Payload<string>("Unauthorized", (int)HttpStatusCode.Unauthorized, string.IsNullOrEmpty(message) ? "Unauthorized" : message);
    }
}

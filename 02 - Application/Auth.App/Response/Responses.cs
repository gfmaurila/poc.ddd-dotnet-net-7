namespace Auth.App.Response;

public static class Responses
{
    public static ResponseDefault ApplicationErrorMessage()
    {
        return new ResponseDefault
        {
            Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
            Success = false,
            Data = null
        };
    }

    public static ResponseDefault DomainErrorMessage(string message)
    {
        return new ResponseDefault
        {
            Message = message,
            Success = false,
            Data = null
        };
    }

    public static ResponseDefault DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResponseDefault
        {
            Message = message,
            Success = false,
            Data = errors
        };
    }

    public static ResponseDefault UnauthorizedErrorMessage()
    {
        return new ResponseDefault
        {
            Message = "A combinação de login e senha está incorreta!",
            Success = false,
            Data = null
        };
    }
}

public class ResponseDefault
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
}

public class ResponsePageDefault
{
    public dynamic Data { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
}

public class ResponseErrorMessages
{
    public ResponseErrorMessages()
    {
        Messages = new List<string>();
    }

    public List<string> Messages { get; set; }
}

public class ResponseResult
{
    public ResponseResult()
    {
        Errors = new ResponseErrorMessages();
    }

    public string Title { get; set; }
    public int Status { get; set; }
    public ResponseErrorMessages Errors { get; set; }
}
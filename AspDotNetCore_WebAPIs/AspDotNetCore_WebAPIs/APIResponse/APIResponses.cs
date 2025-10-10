namespace AspDotNetCore_WebAPIs.APIResponse
{
    public class APIResponses<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }

        public static APIResponses<T> SuccessResponse(T? data)
        {
            return new APIResponses<T>
            {
                Data = data,
                IsSuccess = true,
            };
        }

        public static APIResponses<T> FailureResponse(string? error)
        {
            return new APIResponses<T>
            {
                IsSuccess = false,
                Error = error
            };
        }
       
    }
}

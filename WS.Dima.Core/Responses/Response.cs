using System.Text.Json.Serialization;

namespace WS.Dima.Core.Responses
{
    public class Response<TData>
    {

        private readonly int _code;
        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;

        public Response(TData? data, int code = 200, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }

        [JsonIgnore]
        public bool IsSucess
            => _code is >= 200 and <= 299;
    }
}

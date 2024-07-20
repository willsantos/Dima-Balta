using System.Text.Json.Serialization;

namespace WS.Dima.Core.Requests.Categories
{
    public class UpdateCategoryRequest : CreateCategoryRequest
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WS.Dima.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Titulo é obrigatório")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Description { get; set; } = string.Empty;
    }
}

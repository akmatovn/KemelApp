using System.ComponentModel.DataAnnotations;
using Kemel.BLL.Models;

namespace Kemel.WEB.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public AuthorViewModel(){}

        public AuthorViewModel(AuthorBusinessModel model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}
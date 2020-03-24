using System.ComponentModel.DataAnnotations;
using Kemel.BLL.Models;

namespace Kemel.WEB.Models
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public PublisherViewModel() { }

        public PublisherViewModel(PublisherBusinessModel model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}
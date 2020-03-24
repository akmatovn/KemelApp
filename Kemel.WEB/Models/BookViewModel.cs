using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kemel.BLL.Models;
using Kemel.Common.Resources;

namespace Kemel.WEB.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [UIHint("PublisherEditor")]
        public string PublisherName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        [UIHint("Currency")]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = nameof(ResourceRU.PublishedDate))]
        [UIHint("Date")]
        public DateTime PublishedAt { get; set; }
        [UIHint("AuthorEditor")]
        public string AuthorName { get; set; }
        [Required]
        public List<int> Authors { get; set; }

        public BookViewModel()
        {
            Authors = new List<int>();
        }

        public BookViewModel(BookBusinessModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            PublisherId = model.PublisherId;
            PublisherName = model.PublisherName;
            Price = model.Price;
            PublishedAt = model.PublishedAt;
            AuthorName = model.AuthorName;
            Authors = model.Authors;
        }

        public BookBusinessModel ToModel()
        {
            return new BookBusinessModel
            {
                Id = Id,
                Name = Name,
                Description = Description,
                PublisherId = PublisherId,
                PublishedAt = PublishedAt,
                Price = Price,
                Authors = Authors
            };
        }
    }
}
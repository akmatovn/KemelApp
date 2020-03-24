using System.Linq;
using AutoMapper;
using Kemel.BLL.Models;
using Kemel.DAL.Entity;

namespace Kemel.BLL
{
    public class AutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());
            Mapper.AssertConfigurationIsValid();
        }
    }

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region Author

            CreateMap<Author, AuthorBusinessModel>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name));

            CreateMap<AuthorBusinessModel, Author>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Books, x => x.Ignore());

            #endregion

            #region Publisher

            CreateMap<Publisher, PublisherBusinessModel>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name));

            CreateMap<PublisherBusinessModel, Publisher>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Books, x => x.Ignore());

            #endregion

            #region Book

            CreateMap<Book, BookBusinessModel>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Description, x => x.MapFrom(m => m.Description))
                .ForMember(x => x.PublisherId, x => x.MapFrom(m => m.PublisherId))
                .ForMember(x => x.PublisherName, x => x.MapFrom(m => m.Publisher.Name))
                .ForMember(x => x.Price, x => x.MapFrom(m => m.Price))
                .ForMember(x => x.PublishedAt, x => x.MapFrom(m => m.PublishedAt))
                .ForMember(x => x.Authors, x => x.MapFrom(m => m.Authors.Select(c => c.Id).ToList()))
                .ForMember(x => x.AuthorName, x => x.MapFrom(m =>
                    string.Join(", ", m.Authors.Select(p => p.Name).ToList())));

            CreateMap<BookBusinessModel, Book>()
                    .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                    .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                    .ForMember(x => x.Description, x => x.MapFrom(m => m.Description))
                    .ForMember(x => x.PublisherId, x => x.MapFrom(m => m.PublisherId))
                    .ForMember(x => x.Price, x => x.MapFrom(m => m.Price))
                    .ForMember(x => x.PublishedAt, x => x.MapFrom(m => m.PublishedAt))
                .ForMember(x => x.Publisher, x => x.Ignore())
                .ForMember(x => x.Authors, x => x.Ignore());

            #endregion
        }
    }
}

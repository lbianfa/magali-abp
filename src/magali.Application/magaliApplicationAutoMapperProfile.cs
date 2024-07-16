using AutoMapper;
using magali.Authors;
using magali.Books;
using System;

namespace magali;

public class magaliApplicationAutoMapperProfile : Profile
{
    public magaliApplicationAutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();

        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        CreateMap<CreateUpdateBookDto, Book>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<BookType>(src.Type)));
    }
}

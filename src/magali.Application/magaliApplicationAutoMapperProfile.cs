using AutoMapper;
using magali.Authors;

namespace magali;

public class magaliApplicationAutoMapperProfile : Profile
{
    public magaliApplicationAutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();
    }
}

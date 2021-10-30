namespace Entity.Profiles
{
    using AutoMapper;
    using Entity.DTOs;

    public class BookmarkProfile : Profile
    {
        public BookmarkProfile()
        {
            CreateMap<Bookmark, BookmarkDTO>();
        }
    }
}

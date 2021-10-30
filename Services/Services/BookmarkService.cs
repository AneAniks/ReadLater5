namespace Services
{
    using AutoMapper;
    using Data;
    using Entity.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class BookmarkService : IBookmarkService
    {
        private readonly IMapper _mapper;
        private readonly IBookmarkRepository _bookmarkRepo;
        private readonly ReadLaterDataContext _readContext;
        public BookmarkService(ReadLaterDataContext readContext, IBookmarkRepository bookmarkRepo, IMapper mapper)
        {
            this._readContext = readContext;
            this._bookmarkRepo = bookmarkRepo;
            this._mapper = mapper;
        }
        public IEnumerable<BookmarkDTO> GetBookmarks()
        {
            return _bookmarkRepo.GetBookmarks();
        }
        public IEnumerable<BookmarkDTO> GetBookmark(int id)
        {
            return _bookmarkRepo.GetBookmark(id);
        }
        public BookmarkDTO CreateBookmark(BookmarkDTO bookmark)
        {
            return _bookmarkRepo.CreateBookmark(bookmark);
        }
        public BookmarkDTO UpdateBookmark(int id, BookmarkDTO bookmark)
        {
            return _bookmarkRepo.UpdateBookmark(id, bookmark);
        }
        public bool DeleteBookmark(int id)
        {
            return _bookmarkRepo.DeleteBookmark(id);
        }
        public BookmarkDTO GetCatrgoryById(int? categoryId)
        {
            var bookmark = _readContext.Bookmark.Where(x => x.CategoryId == categoryId);
            return _mapper.Map<BookmarkDTO>(bookmark);
        }
    }
}

namespace Services.Repositorys
{
    using AutoMapper;
    using Data;
    using Entity;
    using Entity.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly IMapper _mapper;
        private readonly ReadLaterDataContext _readContext;
        public BookmarkRepository(ReadLaterDataContext readContext, IMapper mapper)
        {
            this._readContext = readContext;
            this._mapper = mapper;
        }
        public IEnumerable<BookmarkDTO> GetBookmarks()
        {
            return _readContext.Bookmark
            .AsEnumerable()
            .Select(b => new BookmarkDTO()
            {
                Id = b.ID,
                URL = b.URL,
                ShortDescription = b.ShortDescription,
                CategoryId = b.CategoryId,
                CreateDate = b.CreateDate
            }).ToList();
        }
        public IEnumerable<BookmarkDTO> GetBookmark(int id)
        {
            var bookmark = _readContext.Bookmark.Where(x => x.ID == id);
            return _mapper.Map<IEnumerable<BookmarkDTO>>(bookmark);
        }
        public BookmarkDTO CreateBookmark(BookmarkDTO bookmark)
        {
            var newBookmark = _mapper.Map<Bookmark>(bookmark);

            _readContext.Bookmark.Add(newBookmark);
            _readContext.SaveChanges();

            return _mapper.Map<BookmarkDTO>(newBookmark);
        }
        public BookmarkDTO UpdateBookmark(int id, BookmarkDTO bookmark)
        {
            var b = _readContext.Bookmark.FirstOrDefault(x => x.ID == id);
            if (b == null)
            {
                throw new Exception("Ticket not found");
            }

            bookmark.Id = id;
            b = _mapper.Map<Bookmark>(bookmark);
            _readContext.SaveChanges();

            return _mapper.Map<BookmarkDTO>(b);
        }
        public bool DeleteBookmark(int id)
        {
            var bookmark = _readContext.Bookmark.FirstOrDefault(x => x.ID == id);

            if (bookmark == null)
            {
                return false;
            }

            _readContext.Bookmark.Remove(bookmark);
            _readContext.SaveChanges();
            return true;
        }
    }
}

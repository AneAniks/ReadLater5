namespace Services.Repositorys
{
    using Data;
    using Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class BookmarkRepository : IBookmarkRepository
    {
        private ReadLaterDataContext _readContext;
        public BookmarkRepository(ReadLaterDataContext readContext)
        {
            this._readContext = readContext;
        }
        public List<Bookmark> GetBookmarks()
        {
            return _readContext.Bookmark
            .AsEnumerable()
            .Select(b => new Bookmark()
            {
                ID = b.ID,
                URL = b.URL,
                ShortDescription = b.ShortDescription,
                CategoryId = b.CategoryId,
                CreateDate = b.CreateDate
            }).ToList();
        }
        public Bookmark GetBookmark(int id)
        {
            var bookmark = _readContext.Bookmark.Where(x => x.ID == id);
            return bookmark.FirstOrDefault();
        }
        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _readContext.Bookmark.Add(bookmark);
            _readContext.SaveChanges();

            return bookmark;
        }
        public void UpdateBookmark(Bookmark bookmark)
        {
            _readContext.Update(bookmark);
            _readContext.SaveChanges();
        }
        public void DeleteBookmark(Bookmark bookmark)
        {
            _readContext.Bookmark.Remove(bookmark);
            _readContext.SaveChanges();
        }
    }
}

namespace Services
{
    using Data;
    using Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class BookmarkService : IBookmarkService
    {
        private  IBookmarkRepository _bookmarkRepo;
        private  ReadLaterDataContext _readContext;
        public BookmarkService(ReadLaterDataContext readContext, IBookmarkRepository bookmarkRepo)
        {
            this._readContext = readContext;
            this._bookmarkRepo = bookmarkRepo;
        }
        public List<Bookmark> GetBookmarks()
        {
            return _bookmarkRepo.GetBookmarks();
        }
        public Bookmark GetBookmark(int id)
        {
            return _bookmarkRepo.GetBookmark(id);
        }
        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _bookmarkRepo.CreateBookmark(bookmark);
            return bookmark;
        }
        public void UpdateBookmark(Bookmark bookmark)
        {
           _bookmarkRepo.UpdateBookmark(bookmark);
        }
        public void DeleteBookmark(Bookmark bookmark)
        {
            _bookmarkRepo.DeleteBookmark(bookmark);
        }
        public Bookmark GetCatrgoryById(int? categoryId)
        {
            var bookmark = _readContext.Bookmark.Where(x => x.CategoryId == categoryId);
            return bookmark.FirstOrDefault();
        }
    }
}

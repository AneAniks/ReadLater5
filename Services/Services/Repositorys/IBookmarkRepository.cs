namespace Services
{
    using Entity.DTOs;
    using System.Collections.Generic;

    public interface IBookmarkRepository
    {
        IEnumerable<BookmarkDTO> GetBookmarks();
        IEnumerable<BookmarkDTO> GetBookmark(int id);
        BookmarkDTO CreateBookmark(BookmarkDTO bookmark);
        void UpdateBookmark(BookmarkDTO bookmark);
        void DeleteBookmark(BookmarkDTO bookmark);
    }
}

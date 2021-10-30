namespace Services
{
    using Entity.DTOs;
    using System.Collections.Generic;

    public interface IBookmarkService
    {
        IEnumerable<BookmarkDTO> GetBookmarks();
        IEnumerable<BookmarkDTO> GetBookmark(int id);
        BookmarkDTO CreateBookmark(BookmarkDTO bookmark);
        BookmarkDTO UpdateBookmark(int id, BookmarkDTO bookmark);
        bool DeleteBookmark(int id);

        BookmarkDTO GetCatrgoryById(int? categoryId);
    }
}

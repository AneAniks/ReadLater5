namespace Services
{
    using Entity.DTOs;
    using System.Collections.Generic;

    public interface IBookmarkService
    {
        IEnumerable<BookmarkDTO> GetBookmarks();
        IEnumerable<BookmarkDTO> GetBookmark(int id);
        BookmarkDTO CreateBookmark(BookmarkDTO bookmark);
        void UpdateBookmark(BookmarkDTO bookmark);
        void DeleteBookmark(BookmarkDTO bookmark);

        BookmarkDTO GetCatrgoryById(int? categoryId);
        IEnumerable<BookmarkDTO> GetByCategory(int categoryId, int id);
    }
}

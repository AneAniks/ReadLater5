namespace Services
{
    using Entity;
    using System.Collections.Generic;

    public interface IBookmarkService
    {
        List<Bookmark> GetBookmarks();
        Bookmark GetBookmark(int id);
        Bookmark CreateBookmark(Bookmark bookmark);
        void UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);

        Bookmark GetCatrgoryById(int? categoryId);
    }
}

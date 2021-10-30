namespace ReadLater5.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Services;
    using AutoMapper;
    using Entity.DTOs;
    using Microsoft.AspNetCore.Identity;

    public class BookmarksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookmarkService _bookmarkService;
       // private readonly UserManager<IdentityUser> _userManager;

        public BookmarksController(IBookmarkService bookmarkService, IMapper mapper)
        {
            _bookmarkService = bookmarkService;
            _mapper = mapper;
        }

        // GET: Bookmarks
        public IActionResult Index()
        {
            return View(_bookmarkService.GetBookmarks());
        }

        // GET: Bookmarks/Details/5
        public IActionResult Details(int id)
        {
            var bookmark = _bookmarkService.GetBookmark(id);
           
            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookmarkDTO bookmarkDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(bookmarkDTO);
            }
            _bookmarkService.CreateBookmark(bookmarkDTO);
            return View(_bookmarkService.CreateBookmark(bookmarkDTO));
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookmarkDTO bookmark)
        {
            if (id != bookmark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(id, bookmark);
                return RedirectToAction(nameof(Index));
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public bool DeleteConfirmed(int id)
        {
            var bookmark = _bookmarkService.DeleteBookmark(id);
            return bookmark;
        }

        public IActionResult GetCatrgoryById(int? categoryId)
        {
            return View(_bookmarkService.GetCatrgoryById(categoryId));
        }
    }
}

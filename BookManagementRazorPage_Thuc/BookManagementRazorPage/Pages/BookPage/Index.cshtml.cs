using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;
using System.Drawing.Printing;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookManagementRazorPage.Pages.BookPage
{
    public class IndexModel : PageModel
    {
        private readonly IBooksRespository _booksRespository;

        public IndexModel(IBooksRespository booksRespository)
        {
            _booksRespository = booksRespository;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchAuthor { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public const int PageSize = 3; 

        public async Task OnGetAsync()
        {
            var books = _booksRespository.GetAllBook();

            if (!string.IsNullOrEmpty(SearchTitle) || !string.IsNullOrEmpty(SearchAuthor))
            {
                books = books
                    .Where(b =>
                        (string.IsNullOrEmpty(SearchTitle) || b.Title.Contains(SearchTitle, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(SearchAuthor) || b.Author.Contains(SearchAuthor, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            TotalPages = (int)Math.Ceiling(books.Count() / (double)PageSize);
            Book = books.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}

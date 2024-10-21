using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.BookPage
{
    public class DeleteModel : PageModel
    {
        private readonly IBooksRespository _booksRespository;

        public DeleteModel(IBooksRespository booksRespository)
        {
            _booksRespository = booksRespository;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }

            var book =  _booksRespository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                _booksRespository.DeleteBook(id);
                TempData["Message"] = "Book Deleted!";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }
}

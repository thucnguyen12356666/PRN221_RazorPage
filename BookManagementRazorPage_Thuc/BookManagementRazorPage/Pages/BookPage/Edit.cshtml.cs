using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.BookPage
{
    public class EditModel : PageModel
    {
        private readonly IBooksRespository _booksRespository;

        public EditModel(IBooksRespository booksRespository)
        {
            _booksRespository = booksRespository;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _booksRespository.GetBookById(id);
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _booksRespository.UpdateBook(Book);
                TempData["Message"] = "Job Posting Updated!";
                return RedirectToPage("./Index");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _booksRespository.GetBookById(id) == null;
        }
    }
}

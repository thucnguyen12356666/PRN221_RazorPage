using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.BookPage
{
    public class CreateModel : PageModel
    {
        private readonly IBooksRespository _booksRespository;

        public CreateModel(IBooksRespository booksRespository)
        {
            _booksRespository = booksRespository;
        }

      

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _booksRespository.AddBook(Book);
            return RedirectToPage("./Index");
        }
    }
}

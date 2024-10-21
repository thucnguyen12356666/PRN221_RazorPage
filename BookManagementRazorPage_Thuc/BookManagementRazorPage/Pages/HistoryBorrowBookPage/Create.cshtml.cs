using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookManangementBO;

namespace BookManagementRazorPage.Pages.HistoryBorrowBookPage
{
    public class CreateModel : PageModel
    {
        private readonly BookManangementBO.LibraryContext _context;

        public CreateModel(BookManangementBO.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password");
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            return Page();
        }

        [BindProperty]
        public BorrowingHistory BorrowingHistory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BorrowingHistories.Add(BorrowingHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

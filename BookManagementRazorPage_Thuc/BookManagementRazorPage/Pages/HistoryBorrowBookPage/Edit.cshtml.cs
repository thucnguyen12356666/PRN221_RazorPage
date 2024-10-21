using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;

namespace BookManagementRazorPage.Pages.HistoryBorrowBookPage
{
    public class EditModel : PageModel
    {
        private readonly BookManangementBO.LibraryContext _context;

        public EditModel(BookManangementBO.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowingHistory BorrowingHistory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowinghistory =  await _context.BorrowingHistories.FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrowinghistory == null)
            {
                return NotFound();
            }
            BorrowingHistory = borrowinghistory;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password");
           ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BorrowingHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingHistoryExists(BorrowingHistory.BorrowId))
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

        private bool BorrowingHistoryExists(int id)
        {
            return _context.BorrowingHistories.Any(e => e.BorrowId == id);
        }
    }
}

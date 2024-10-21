using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;

namespace BookManagementRazorPage.Pages.HistoryBorrowBookPage
{
    public class DetailsModel : PageModel
    {
        private readonly BookManangementBO.LibraryContext _context;

        public DetailsModel(BookManangementBO.LibraryContext context)
        {
            _context = context;
        }

        public BorrowingHistory BorrowingHistory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowinghistory = await _context.BorrowingHistories.FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrowinghistory == null)
            {
                return NotFound();
            }
            else
            {
                BorrowingHistory = borrowinghistory;
            }
            return Page();
        }
    }
}

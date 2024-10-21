using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly IBooksRespository _context;
        private readonly IAccountRespository _accountRespository;
        private readonly IBorrowingHisRespository _borrowingHisRespository;

        public IndexModel(IBooksRespository context, IBorrowingHisRespository borrowingHisRespository,IAccountRespository accountRespository)
        {
            _context = context;
            _borrowingHisRespository = borrowingHisRespository;
            _accountRespository = accountRespository;
        }

        public IList<Book> Book { get;set; } = default!;
        public int TotalPages { get; set; }

        public const int PageSize = 7;
        public async Task OnGetAsync()
        {
            int? accountID = HttpContext.Session.GetInt32("AccountID");

            if (accountID.HasValue)
            {
                Book = _context.GetAvailableBooksForAccount(accountID.Value).ToList();
            }
            else
            {
                throw new InvalidOperationException("RoleID not found in session. Please log in.");
            }
        }
        public async Task<IActionResult> OnPostBorrowAsync(int id)
        {
            int? accountID = HttpContext.Session.GetInt32("AccountID");

            if (accountID == null)
            {
                return RedirectToPage("/Login"); 
            }

            var book =  _context.GetBookById(id);
            if (book == null || book.Quantity <= 0)
            {
                return NotFound("Book not available for borrowing.");
            }
            _borrowingHisRespository.BorrowBook(accountID.Value, id);
            book.Quantity -= 1;
            _context.UpdateBook(book);
            Book = _context.GetAvailableBooksForAccount(accountID.Value).ToList();

            return RedirectToPage();
        }
    }
}

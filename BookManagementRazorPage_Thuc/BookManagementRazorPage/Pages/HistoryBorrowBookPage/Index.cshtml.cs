using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;
using Microsoft.Identity.Client;

namespace BookManagementRazorPage.Pages.HistoryBorrowBookPage
{
    public class IndexModel : PageModel
    {
        private readonly IBorrowingHisRespository _context;

        public IndexModel(IBorrowingHisRespository context)
        {
            _context = context;
        }

        public IList<BorrowingHistory> BorrowingHistory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            int? accountId = HttpContext.Session.GetInt32("AccountID");
            if (accountId != null)
            {
                BorrowingHistory =  _context.GetBorrowingHisByAccountID(accountId.Value);
            }

        }
    }
}

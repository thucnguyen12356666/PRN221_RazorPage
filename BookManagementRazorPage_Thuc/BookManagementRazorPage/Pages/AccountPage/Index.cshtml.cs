using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRespository _accountRespository;

        public IndexModel(IAccountRespository accountRespository)
        {
           _accountRespository = accountRespository;
        }

        public IList<Account> Account { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public const int PageSize = 3;
        public async Task OnGetAsync()
        {
            var accounts = _accountRespository.GetAllAccounts();

            if (!string.IsNullOrEmpty(SearchTitle))
            {
                accounts = accounts
                    .Where(b =>
                        (string.IsNullOrEmpty(SearchTitle) || b.Username.Contains(SearchTitle, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            TotalPages = (int)Math.Ceiling(accounts.Count() / (double)PageSize);
            Account = accounts.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}

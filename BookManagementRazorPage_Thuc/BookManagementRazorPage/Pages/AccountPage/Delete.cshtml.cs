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
    public class DeleteModel : PageModel
    {
        private readonly IAccountRespository _accountRespository;

        public DeleteModel(IAccountRespository accountRespository)
        {
            _accountRespository = accountRespository;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var account = _accountRespository.getAccountById(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
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

                _accountRespository.deleteAccount(id);
                TempData["Message"] = "Account Deleted!";

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

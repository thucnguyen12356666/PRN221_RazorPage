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

namespace BookManagementRazorPage.Pages.AccountPage
{
    public class EditModel : PageModel
    {
        private readonly IAccountRespository _accountRespository;

        public EditModel(IAccountRespository accountRespository)
        {
            _accountRespository = accountRespository;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
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
                Account = account ;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _accountRespository.updateAccount(Account);
                TempData["Message"] = "Account Updated!";
                return RedirectToPage("./Index");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.AccountId))
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

        private bool AccountExists(int id)
        {
            return _accountRespository.getAccountById(id) == null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookManangementBO;
using BookRespository;

namespace BookManagementRazorPage.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRespository _accountRespository;

        public CreateModel(IAccountRespository accountRespository)
        {
            _accountRespository = accountRespository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _accountRespository.addAccount(Account);

            return RedirectToPage("./Index");
        }
    }
}

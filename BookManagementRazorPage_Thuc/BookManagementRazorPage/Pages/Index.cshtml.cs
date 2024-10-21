using BookRespository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace BookManagementRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        private readonly IAccountRespository _accountRespository;
        public IndexModel(IAccountRespository accountRespository)
        {
            
            _accountRespository = accountRespository;
        }


        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = _accountRespository.GetAccount(username,password);
                if (account != null && (account.RoleId == 1))
                {
                    TempData["Message"] = "Login success";
                    Console.WriteLine("Login success");
                    HttpContext.Session.SetInt32("RoleID", account.RoleId);
                    return RedirectToPage("/BookPage/Index");

                }
                else
                {
                    Console.WriteLine("Login success");
                    if (account == null || account.AccountId == 0)
                    {
                        
                        throw new InvalidOperationException("No valid account found. Unable to set RoleID in session.");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("AccountID", account.AccountId);
                    }
                    return RedirectToPage("/CustomerPage/Index");
                }

            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return Page();
            }

        }
    }
}

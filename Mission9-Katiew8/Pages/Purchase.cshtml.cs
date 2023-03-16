using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_Katiew8.Infrastructure;
using Mission9_Katiew8.Models;

namespace Mission9_Katiew8.Pages
{
    public class PurchaseModel : PageModel
    {
        private Repository repo { get; set; }

        public PurchaseModel (Repository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
       
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";        
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Bookz.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == bookId).Books);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mission9_Katiew8.Migrations;
using Mission9_Katiew8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Controllers
{
    public class PurchaseController : Controller
    {
        
        private PurchaseRepository repo { get; set;}
        private Basket basket { get; set; }
        
        public PurchaseController(PurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;

        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Models.Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Models.Purchase purchase)
        {

            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your Cart is Empty!");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/Confirmation");

            }
            else
            {
                return View();
            }


        }
    }

}

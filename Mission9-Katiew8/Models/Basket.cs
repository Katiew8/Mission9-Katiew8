﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Books bk, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Books.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }



        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);
            return sum;
        }
    }

   

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Books { get; set; }

        public int Quantity { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopping.Data;
using PizzaShopping.Models;

namespace PizzaShopping.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly PizzaShopping.Data.PizzaContext _context;

        public DeleteModel(PizzaShopping.Data.PizzaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            int type = HttpContext.Session.GetInt32("ROLE") == null ? -1 : (int)HttpContext.Session.GetInt32("ROLE");
            if (type != 1)
            {
                return Unauthorized();
            }

            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            int type = HttpContext.Session.GetInt32("ROLE") == null ? -1 : (int)HttpContext.Session.GetInt32("ROLE");
            if (type == -1)
            {
                return Unauthorized();
            }
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                Customer = customer;
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

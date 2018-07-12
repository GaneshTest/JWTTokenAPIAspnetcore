using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPattern.Data;

namespace RepositoryPattern.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Student");
          //  _db.Customers.Add(Customer);
            //await _db.SaveChangesAsync();
            //Message = $"Customer {Customer.Name} added";
            //return RedirectToPage("./Index");
        }
    }
}
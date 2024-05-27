using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TareasPendientes.Data;
using TareasPendientes.Models;

namespace TareasPendientes.Pages.Tareas
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarea Tarea { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tareas.Add(Tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TareasPendientes.Data;
using TareasPendientes.Models;

namespace TareasPendientes.Pages.Tareas
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarea Tarea { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Tarea = await _context.Tareas.FindAsync(id);

            if (Tarea == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Tarea = await _context.Tareas.FindAsync(id);

            if (Tarea != null)
            {
                _context.Tareas.Remove(Tarea);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

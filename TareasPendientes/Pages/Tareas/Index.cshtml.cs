﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareasPendientes.Data;
using TareasPendientes.Models;

namespace TareasPendientes.Pages.Tareas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tarea> Tareas { get; set; }

        public async Task OnGetAsync()
        {
            Tareas = await _context.Tareas.ToListAsync();
        }
    }
}

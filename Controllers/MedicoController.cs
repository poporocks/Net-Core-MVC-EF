using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class MedicoController : Controller
    {
        private readonly TurnosContext _context;
        public MedicoController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Medico.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();

            var medico = await _context.Medico.FirstOrDefaultAsync(m => m.IdMedico == id);

            if(medico == null) return NotFound();

            return View(medico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico, Nombre, Apellido, Direccion, Telefono, Email, HorarioAtencionDesde, HorarioAtencionHasta")] Medico medico)
        {
            if(ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();
            var medico = await _context.Medico.FindAsync(id);
            if(medico == null) return NotFound();
            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico, Nombre, Apellido, Direccion, Telefono, Email, HorarioAtencionDesde, HorarioAtencionHasta")] Medico medico)
        {
            if (id != medico.IdMedico) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();
            var medico = await _context.Medico.FirstOrDefaultAsync(m => m.IdMedico == id);
            if(medico == null) return NotFound();
            return View(medico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null) return NotFound();
            var medico = await _context.Medico.FindAsync(id);
            if(medico == null) return NotFound();
            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.IdMedico == id);
        }
    }
}

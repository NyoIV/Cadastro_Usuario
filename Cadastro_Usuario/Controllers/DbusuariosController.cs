using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro_Usuario.Models;

namespace Cadastro_Usuario.Controllers
{
    public class DbusuariosController : Controller
    {
        private readonly Context _context;

        public DbusuariosController(Context context)
        {
            _context = context;
        }

        // GET: Dbusuarios
        public async Task<IActionResult> Index()
        {
              return _context.usuario != null ? 
                          View(await _context.usuario.ToListAsync()) :
                          Problem("Entity set 'Context.usuario'  is null.");
        }

        // GET: Dbusuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbusuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbusuario == null)
            {
                return NotFound();
            }

            return View(dbusuario);
        }

        // GET: Dbusuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dbusuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,mensagem")] Dbusuario dbusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbusuario);
        }

        // GET: Dbusuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbusuario = await _context.usuario.FindAsync(id);
            if (dbusuario == null)
            {
                return NotFound();
            }
            return View(dbusuario);
        }

        // POST: Dbusuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,datanascimento,sexo,rua,numero,cep,cidade,estado,mensagem")] Dbusuario dbusuario)
        {
            if (id != dbusuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbusuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbusuarioExists(dbusuario.id))
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
            return View(dbusuario);
        }

        // GET: Dbusuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbusuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbusuario == null)
            {
                return NotFound();
            }

            return View(dbusuario);
        }

        // POST: Dbusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usuario == null)
            {
                return Problem("Entity set 'Context.usuario'  is null.");
            }
            var dbusuario = await _context.usuario.FindAsync(id);
            if (dbusuario != null)
            {
                _context.usuario.Remove(dbusuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbusuarioExists(int id)
        {
          return (_context.usuario?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

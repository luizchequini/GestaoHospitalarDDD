using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data_GestaoHospitalar.ORM;
using Domain_GestaoHospitalar.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web_GestaoHospitalar.Controllers
{
    [Authorize]
    public class PacientesController : Controller
    {
        private readonly GestaoHospitalarDbContext _context;

        public PacientesController(GestaoHospitalarDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var gestaoHospitalarDbContext = _context.Pacientes.Include(p => p.EstadoPaciente).AsNoTracking();
            return View(await gestaoHospitalarDbContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.EstadoPaciente).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["EstadoPacienteId"] = new SelectList(_context.EstadoPacientes, "Id", "Descricao");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoPacienteId,Nome,DataNascimento,DataInternacao,Email,Ativo,Cpf,TipoPaciente,Sexo,Rg,RgOrgao,RgDataEmissao,Id")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.Id = Guid.NewGuid();
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoPacienteId"] = new SelectList(_context.EstadoPacientes, "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["EstadoPacienteId"] = new SelectList(_context.EstadoPacientes, "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EstadoPacienteId,Nome,DataNascimento,DataInternacao,Email,Ativo,Cpf,TipoPaciente,Sexo,Rg,RgOrgao,RgDataEmissao,Id")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
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
            ViewData["EstadoPacienteId"] = new SelectList(_context.EstadoPacientes, "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.EstadoPaciente).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}

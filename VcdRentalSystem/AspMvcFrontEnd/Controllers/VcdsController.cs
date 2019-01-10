using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspMvcFrontEnd.DAL;
using AspMvcFrontEnd.Models;

namespace AspMvcFrontEnd.Controllers
{
    public class VcdsController : Controller
    {
        private readonly VcdRentalContext _context;

        public VcdsController(VcdRentalContext context)
        {
            _context = context;
        }

        // GET: Vcds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vcds.ToListAsync());
        }

        // GET: Vcds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vcdModel = await _context.Vcds
                .FirstOrDefaultAsync(m => m.VcdId == id);
            if (vcdModel == null)
            {
                return NotFound();
            }

            return View(vcdModel);
        }

        // GET: Vcds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vcds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VcdId,VcdName,VcdBoughtDate")] VcdModel vcdModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vcdModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vcdModel);
        }

        // GET: Vcds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vcdModel = await _context.Vcds.FindAsync(id);
            if (vcdModel == null)
            {
                return NotFound();
            }
            return View(vcdModel);
        }

        // POST: Vcds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VcdId,VcdName,VcdBoughtDate")] VcdModel vcdModel)
        {
            if (id != vcdModel.VcdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vcdModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VcdModelExists(vcdModel.VcdId))
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
            return View(vcdModel);
        }

        // GET: Vcds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vcdModel = await _context.Vcds
                .FirstOrDefaultAsync(m => m.VcdId == id);
            if (vcdModel == null)
            {
                return NotFound();
            }

            return View(vcdModel);
        }

        // POST: Vcds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vcdModel = await _context.Vcds.FindAsync(id);
            _context.Vcds.Remove(vcdModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VcdModelExists(int id)
        {
            return _context.Vcds.Any(e => e.VcdId == id);
        }
    }
}

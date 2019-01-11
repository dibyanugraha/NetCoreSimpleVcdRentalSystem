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
    public class RentalPackagesController : Controller
    {
        private readonly VcdRentalContext _context;

        public RentalPackagesController(VcdRentalContext context)
        {
            _context = context;
        }

        // GET: RentalPackages
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalPackageModel.ToListAsync());
        }

        // GET: RentalPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPackageModel = await _context.RentalPackageModel
                .FirstOrDefaultAsync(m => m.RentalPackageId == id);
            if (rentalPackageModel == null)
            {
                return NotFound();
            }

            return View(rentalPackageModel);
        }

        // GET: RentalPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalPackageId,PackageName,CostPerMonth,MaxVcdRental")] RentalPackageModel rentalPackageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalPackageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPackageModel);
        }

        // GET: RentalPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPackageModel = await _context.RentalPackageModel.FindAsync(id);
            if (rentalPackageModel == null)
            {
                return NotFound();
            }
            return View(rentalPackageModel);
        }

        // POST: RentalPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalPackageId,PackageName,CostPerMonth,MaxVcdRental")] RentalPackageModel rentalPackageModel)
        {
            if (id != rentalPackageModel.RentalPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalPackageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPackageModelExists(rentalPackageModel.RentalPackageId))
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
            return View(rentalPackageModel);
        }

        // GET: RentalPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPackageModel = await _context.RentalPackageModel
                .FirstOrDefaultAsync(m => m.RentalPackageId == id);
            if (rentalPackageModel == null)
            {
                return NotFound();
            }

            return View(rentalPackageModel);
        }

        // POST: RentalPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalPackageModel = await _context.RentalPackageModel.FindAsync(id);
            _context.RentalPackageModel.Remove(rentalPackageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalPackageModelExists(int id)
        {
            return _context.RentalPackageModel.Any(e => e.RentalPackageId == id);
        }
    }
}

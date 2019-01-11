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
    public class RentalLedgerEntriesController : Controller
    {
        private readonly VcdRentalContext _context;

        public RentalLedgerEntriesController(VcdRentalContext context)
        {
            _context = context;
        }

        // GET: RentalLedgerEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalLedgerEntries.ToListAsync());
        }

        // GET: RentalLedgerEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalLedgerEntryModel = await _context.RentalLedgerEntries
                .FirstOrDefaultAsync(m => m.EntryNo == id);
            if (rentalLedgerEntryModel == null)
            {
                return NotFound();
            }

            return View(rentalLedgerEntryModel);
        }

        // GET: RentalLedgerEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalLedgerEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryNo,VcdId,TenantId,RentalOrderId,RentDate,ReturnDate,DueDate,Quantity")] RentalLedgerEntryModel rentalLedgerEntryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalLedgerEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalLedgerEntryModel);
        }

        // GET: RentalLedgerEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalLedgerEntryModel = await _context.RentalLedgerEntries.FindAsync(id);
            if (rentalLedgerEntryModel == null)
            {
                return NotFound();
            }
            return View(rentalLedgerEntryModel);
        }

        // POST: RentalLedgerEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntryNo,VcdId,TenantId,RentalOrderId,RentDate,ReturnDate,DueDate,Quantity")] RentalLedgerEntryModel rentalLedgerEntryModel)
        {
            if (id != rentalLedgerEntryModel.EntryNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalLedgerEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalLedgerEntryModelExists(rentalLedgerEntryModel.EntryNo))
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
            return View(rentalLedgerEntryModel);
        }

        // GET: RentalLedgerEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalLedgerEntryModel = await _context.RentalLedgerEntries
                .FirstOrDefaultAsync(m => m.EntryNo == id);
            if (rentalLedgerEntryModel == null)
            {
                return NotFound();
            }

            return View(rentalLedgerEntryModel);
        }

        // POST: RentalLedgerEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalLedgerEntryModel = await _context.RentalLedgerEntries.FindAsync(id);
            _context.RentalLedgerEntries.Remove(rentalLedgerEntryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalLedgerEntryModelExists(int id)
        {
            return _context.RentalLedgerEntries.Any(e => e.EntryNo == id);
        }
    }
}

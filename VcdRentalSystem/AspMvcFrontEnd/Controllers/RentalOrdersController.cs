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
    public class RentalOrdersController : Controller
    {
        private readonly VcdRentalContext _context;

        public RentalOrdersController(VcdRentalContext context)
        {
            _context = context;
        }

        // GET: RentalOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalOrders.ToListAsync());
        }

        // GET: RentalOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalOrderModel = await _context.RentalOrders
                .FirstOrDefaultAsync(m => m.RentalOrderId == id);
            if (rentalOrderModel == null)
            {
                return NotFound();
            }

            return View(rentalOrderModel);
        }

        // GET: RentalOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalOrderId,OrderNo,OrderDate,DueDate,TotalCost")] RentalOrderModel rentalOrderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalOrderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalOrderModel);
        }

        // GET: RentalOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalOrderModel = await _context.RentalOrders.FindAsync(id);
            if (rentalOrderModel == null)
            {
                return NotFound();
            }
            return View(rentalOrderModel);
        }

        // POST: RentalOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalOrderId,OrderNo,OrderDate,DueDate,TotalCost")] RentalOrderModel rentalOrderModel)
        {
            if (id != rentalOrderModel.RentalOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalOrderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalOrderModelExists(rentalOrderModel.RentalOrderId))
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
            return View(rentalOrderModel);
        }

        // GET: RentalOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalOrderModel = await _context.RentalOrders
                .FirstOrDefaultAsync(m => m.RentalOrderId == id);
            if (rentalOrderModel == null)
            {
                return NotFound();
            }

            return View(rentalOrderModel);
        }

        // POST: RentalOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalOrderModel = await _context.RentalOrders.FindAsync(id);
            _context.RentalOrders.Remove(rentalOrderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalOrderModelExists(int id)
        {
            return _context.RentalOrders.Any(e => e.RentalOrderId == id);
        }
    }
}

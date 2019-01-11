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
    public class TenantsController : Controller
    {
        private readonly VcdRentalContext _context;

        public TenantsController(VcdRentalContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenants.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantModel = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenantModel == null)
            {
                return NotFound();
            }

            return View(tenantModel);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantId,RegistrationDate,FullName,PhoneNumber,Age,IdentityNumber,IsMemberOfAnotherRental,Reference")] TenantModel tenantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenantModel);
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantModel = await _context.Tenants.FindAsync(id);
            if (tenantModel == null)
            {
                return NotFound();
            }
            return View(tenantModel);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenantId,RegistrationDate,FullName,PhoneNumber,Age,IdentityNumber,IsMemberOfAnotherRental,Reference")] TenantModel tenantModel)
        {
            if (id != tenantModel.TenantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantModelExists(tenantModel.TenantId))
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
            return View(tenantModel);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantModel = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenantModel == null)
            {
                return NotFound();
            }

            return View(tenantModel);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenantModel = await _context.Tenants.FindAsync(id);
            _context.Tenants.Remove(tenantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantModelExists(int id)
        {
            return _context.Tenants.Any(e => e.TenantId == id);
        }
    }
}

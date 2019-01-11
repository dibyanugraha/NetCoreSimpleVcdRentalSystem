using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspMvcFrontEnd.Models;

namespace AspMvcFrontEnd.Controllers
{
    public class TenantContactController : Controller
    {
        List<TenantModel> tenants = new List<TenantModel>();
        List<ContactModel> contacts = new List<ContactModel>();

        public IActionResult Index()
        {
            var joinedTable = from tenant in tenants
                                   join contact in contacts on tenant.TenantId equals contact.TenantId into newTable
                                   from contact in newTable.DefaultIfEmpty()
                                   select new TenantContactModel { Contact = contact, Tenant = tenant };
            return View(joinedTable);
        }
    }
}
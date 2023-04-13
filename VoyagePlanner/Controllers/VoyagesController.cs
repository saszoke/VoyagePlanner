using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VoyagePlanner.Data;
using VoyagePlanner.Models;
using VoyagePlanner.Models.DTOs;

namespace VoyagePlanner.Controllers
{
    public class VoyagesController : Controller
    {
        private readonly VoyagePlannerContext _context;

        public VoyagesController(VoyagePlannerContext context)
        {
            _context = context;
        }

        // GET: Voyages
        public async Task<IActionResult> Index()
        {
            return _context.Voyages != null ?
                        View(await _context.Voyages.ToListAsync()) :
                        Problem("Entity set 'VoyagePlannerContext.Voyage'  is null.");
        }

        // GET: Voyages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voyages == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        public async Task<IActionResult> Discover(int id)
        {
            ViewBag.Country = await _context.Countries.FindAsync(id);
            IEnumerable<Destination> destinations = await _context.Destinations.Where(d => d.Country.Id == id).ToListAsync();
            return View("Destinations", destinations);
        }

        public async Task<IActionResult> Countries() {
            IEnumerable<Country> countries = await _context.Countries.ToListAsync();
            return View("Countries", countries); 
        }

        public async Task<IActionResult> InitiateBooking(int destinationId)
        {

            var travelTypes = await _context.TravelTypes.Select(tt => tt.Name).ToListAsync();  //from travelType in _context.TravelTypes.AsEnumerable() select travelType.Name;
            Destination destination = await _context.Destinations.FindAsync(destinationId);
            ViewBag.dropdown = TravelTypeList(travelTypes);
            ViewBag.destination = destination;

            //VoyageDTO voyage = new VoyageDTO();
            //voyage.TravelTypeList = TravelTypeList(travelTypes);
            return View("VoyageForm");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoyageHandler(VoyageDTO voyage)
        {
            if (ModelState.IsValid)
            {
                TravelType tType = await _context.TravelTypes.FirstOrDefaultAsync(tt => tt.Name.Equals(voyage.TravelType));
                Destination d = await _context.Destinations.FindAsync(Int32.Parse(voyage.DestinationId));
                Voyage newVoyage = new Voyage();
                newVoyage.StartDate = voyage.StartDate;
                newVoyage.EndDate = voyage.EndDate;
                newVoyage.TravelType = tType;
                newVoyage.Destination = d;
                _context.Voyages.Add(newVoyage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Options", newVoyage);
            }
            return RedirectToAction("VoyageHandler");
        }

        // GET: Voyages/Edit/5
        public async Task<IActionResult> Options(Voyage voyage)
        {
            var extras = await _context.ExtraDetail.ToListAsync();

            List<string> names = new List<string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(new ExtraDetail()))
                {
                    names.Add(property.Name);
                }
            ViewBag.extras = extras;
            ViewBag.names = names;
            return View("Options",voyage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncrementHandler([FromBody] JsonElement data)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(data.GetRawText());

            int id = (int) obj.extraId;
            int quantity = (int) obj.extraQuantity;
            var item = await _context.ExtraDetail.FindAsync(id);
            Extra extra = new Extra();
            extra.ExtraDetail = item;
            extra.Quantity = ++quantity;
            return PartialView("~/Views/Partial/Increment.cshtml", extra);

        }

        // POST: Voyages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfVoyage")] Voyage voyage)
        //{
        //    if (id != voyage.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(voyage);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!VoyageExists(voyage.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(voyage);
        //}

        // GET: Voyages/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    var voyage = await _context.Voyage
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(voyage);
        //}

        //// POST: Voyages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Voyage == null)
        //    {
        //        return Problem("Entity set 'VoyagePlannerContext.Voyage'  is null.");
        //    }
        //    var voyage = await _context.Voyage.FindAsync(id);
        //    if (voyage != null)
        //    {
        //        _context.Voyage.Remove(voyage);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool VoyageExists(int id)
        //{
        //    return (_context.Voyage?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        private SelectList TravelTypeList(List<string> travelTypes)
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            travelTypes.ForEach(travelType =>
            {
                countries.Add(new SelectListItem { Text = travelType, Value = travelType });
            });
            SelectList items = new SelectList(countries, "Value", "Text");
            return items;
        }
    }
    
}

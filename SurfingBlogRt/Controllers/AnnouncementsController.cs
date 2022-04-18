using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;

namespace SurfingBlogRt.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly DataContext _context;

        public AnnouncementsController()
        {
            _context = new DataContext();
        }

        // GET: Announcements
        public async Task<IActionResult> Show(string type, int? id, string theme, string location)
        {
            var announcements = await 
                getAnnouncementsFiltered(type,theme,location)
                .ToListAsync();
            ViewData["Type"] = type;

            int page = id ?? 0;
            //здесь данные для фильтров
                //ViewData["Themes"] = getThemeFilterData(type);
                //ViewData["Locations"] = getLocationFilterData(type);
                //ViewData["Formats"] = getFormatFilterData(type);
                return View(announcements);          
        }

        //мб надо будет
        public bool IsAjaxRequest()
        {
            if (Request == null)
                throw new ArgumentNullException("Request is null");
            if (Request.Headers != null)
                return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public IQueryable<Vacancy> getAnnouncementsFiltered(string type, string phone, string company)
        {
            IQueryable<Vacancy> filteredAnnouncementsQuery = null;

            if(phone != null)
            {
                filteredAnnouncementsQuery = _context.Announcements.Where(a => a.Phone.Equals(phone));
            }

            if(company != null)
            {
                filteredAnnouncementsQuery = _context.Announcements.Where(a => a.Company.Equals(company));
            }

            return filteredAnnouncementsQuery;
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Company,Region,City,Address,Phone,Email,Obeys,Requirements,Conditions")] Vacancy announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),announcement);
            }
            return View(announcement);
        }
/*
        public SelectList getThemeFilterData(string type)
        {
            return new SelectList(
                _context.Announcements
                .Where(a => a.Type.TypeName.Equals(type))
                .Select(a => a.Theme)
                .Distinct());
        }

        public SelectList getLocationFilterData(string address)
        {
            return new SelectList(
                _context.Announcements
                .Where(a => a.Address.Equals(address))
                .Select(a => a.Location)
                .Distinct());
        }

        public SelectList getFormatFilterData(string type)
        {
            return new SelectList(
                _context.Announcements
                .Include(a => a.Type)
                .Where(a => a.Type.TypeName.Equals(type))
                .Select(a => a.Format)
                .Distinct());
        }

        public SelectList getAnnouncementTypeDataEditing(int typeId)
        {
            return new SelectList(_context.AnnoucementTypes, "Id", "TypeName", typeId);
        }

        public SelectList getAnnouncementTypeData()
        {
            return new SelectList(_context.AnnoucementTypes, "Id", "TypeName");
        }
*/
       

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}

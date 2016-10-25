using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonApplicationDll;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonWebApp.Controllers
{
    public class PersonsController : Controller
    {
        private IManager<Person> _pm = new DllFacade().GetPersonManager();
        private IManager<Wish> _wm = new DllFacade().GetWishManager();
        private IManager<PersonStatus> _psm = new DllFacade().GetPersonStatusManager();

        // GET: Persons
        public ActionResult Index()
        {
            return View(_pm.Read());
        }

        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _pm.Read(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            ViewBag.PersonStatusId = new SelectList(_psm.Read(), "Id", "Name");
            ViewBag.Wishes = new MultiSelectList(_wm.Read(), "Id", "Name");
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PersonStatusId, WishesIds")] Person person, int[] wishesIds)
        {
            if (ModelState.IsValid)
            {
                person.Wishes = new List<Wish>();
                foreach (var wish in wishesIds)
                {
                    person.Wishes.Add(new Wish() {Id = wish});
                }
                _pm.Create(person);
                return RedirectToAction("Index");
            }

            ViewBag.PersonStatusId = new SelectList(_psm.Read(), "Id", "Name", person.PersonStatusId);
            ViewBag.Wishes = new MultiSelectList(_wm.Read(), "Id", "Name", person.Wishes);
            return View(person);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _pm.Read(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonStatusId = new SelectList(_psm.Read(), "Id", "Name", person.PersonStatusId);

            ViewBag.Wishes = new MultiSelectList(_wm.Read(), "Id", "Name", person.Wishes.Select(p => p.Id).ToArray());
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PersonStatusId, WishesIds")] Person person, int[] wishesIds)
        {
            if (ModelState.IsValid)
            {
                person.Wishes = new List<Wish>();
                foreach (var wish in wishesIds)
                {
                    person.Wishes.Add(new Wish() { Id = wish });
                }
                _pm.Update(person);
                return RedirectToAction("Index");
            }
            ViewBag.PersonStatusId = new SelectList(_psm.Read(), "Id", "Name", person.PersonStatusId);
            ViewBag.Wishes = new MultiSelectList(_wm.Read(), "Id", "Name", person.Wishes.Select(p => p.Id).ToArray());
            return View(person);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _pm.Read(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _pm.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}

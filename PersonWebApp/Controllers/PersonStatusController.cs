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
    public class PersonStatusController : Controller
    {
        private IManager<PersonStatus> _psm = new DllFacade().GetPersonStatusManager();


        // GET: PersonStatus
        public ActionResult Index()
        {
            return View(_psm.Read());
        }

        // GET: PersonStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonStatus personStatus = _psm.Read(id.Value);
            if (personStatus == null)
            {
                return HttpNotFound();
            }
            return View(personStatus);
        }

        // GET: PersonStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PersonStatus personStatus)
        {
            if (ModelState.IsValid)
            {
                _psm.Create(personStatus);
                return RedirectToAction("Index");
            }

            return View(personStatus);
        }

        // GET: PersonStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonStatus personStatus = _psm.Read(id.Value);
            if (personStatus == null)
            {
                return HttpNotFound();
            }
            return View(personStatus);
        }

        // POST: PersonStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PersonStatus personStatus)
        {
            if (ModelState.IsValid)
            {
                _psm.Update(personStatus);
                return RedirectToAction("Index");
            }
            return View(personStatus);
        }

        // GET: PersonStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonStatus personStatus = _psm.Read(id.Value);
            if (personStatus == null)
            {
                return HttpNotFound();
            }
            return View(personStatus);
        }

        // POST: PersonStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _psm.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}

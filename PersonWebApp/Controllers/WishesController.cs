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
    public class WishesController : Controller
    {
        private IServiceGateway<Wish> wm = new DllFacade().GetWishManager();
        // GET: Wishes
        public ActionResult Index()
        {
            return View(wm.Read());
        }

        // GET: Wishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = wm.Read(id.Value);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // GET: Wishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                wm.Create(wish);
                return RedirectToAction("Index");
            }

            return View(wish);
        }

        // GET: Wishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = wm.Read(id.Value);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // POST: Wishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                wm.Update(wish);
                return RedirectToAction("Index");
            }
            return View(wish);
        }

        // GET: Wishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = wm.Read(id.Value);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // POST: Wishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wm.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektRaport.Models;

namespace ProjektRaport.Controllers
{
    public class ChangesController : Controller
    {
        private ReportModel db = new ReportModel();


        public ActionResult Index()
        {
            List<Changes> model = db.Changes.ToList();
            return View(model);
        }
        // GET: Changes
        public ActionResult ChangeView(long id)
        {
            var changes = db.Changes.FirstOrDefault(x => x.ID == id);

            return View(changes);
        }

        public ActionResult EditReport(long id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditReport(Report report)
        {

            db.Report.Add(report);
            return RedirectToAction("Index");
        }

        // GET: Changes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            return View(changes);
        }

        // GET: Changes/Create
        public ActionResult Create()
        {
            ViewBag.FristWorker = new SelectList(db.Workers, "Id", "FirstName");
            ViewBag.SecondWorker = new SelectList(db.Workers, "Id", "FirstName");
            return View();
        }

        // POST: Changes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FristWorker,SecondWorker,TimeRange,Date")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                db.Changes.Add(changes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FristWorker = new SelectList(db.Workers, "Id", "FirstName", changes.FristWorker);
            ViewBag.SecondWorker = new SelectList(db.Workers, "Id", "FirstName", changes.SecondWorker);
            return View(changes);
        }

        // GET: Changes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            ViewBag.FristWorker = new SelectList(db.Workers, "Id", "FirstName", changes.FristWorker);
            ViewBag.SecondWorker = new SelectList(db.Workers, "Id", "FirstName", changes.SecondWorker);
            return View(changes);
        }

        // POST: Changes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FristWorker,SecondWorker,TimeRange,Date")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FristWorker = new SelectList(db.Workers, "Id", "FirstName", changes.FristWorker);
            ViewBag.SecondWorker = new SelectList(db.Workers, "Id", "FirstName", changes.SecondWorker);
            return View(changes);
        }

        // GET: Changes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            return View(changes);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Changes changes = db.Changes.Find(id);
            db.Changes.Remove(changes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult CreateWorker()
        {
            Workers worker = new Workers();
            worker.UserId = TempData["UserId"].ToString();

            return View(worker);
        }

        [HttpPost]
        public ActionResult CreateWorker( Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(workers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult CreateChange()
        {

            var workers = db.Workers.ToList();

            IEnumerable<SelectListItem> workersDDL = from w in workers
                                                     select new SelectListItem
                                                     {
                                                         Text = w.FirstName + " " + w.LastName,
                                                         Value = w.Id.ToString()
                                                     };

            ViewBag.Workers = new SelectList(workersDDL, "Value", "Text");
            return View();

        }
        [HttpPost]
        public ActionResult CreateChange(Changes changes)
        {

            if (ModelState.IsValid)
            {
                db.Changes.Add(changes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(changes);
        }
    }
}

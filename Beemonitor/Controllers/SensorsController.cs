using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Beemonitor.Models;

namespace Beemonitor.Controllers
{
    public class SensorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sensors
        public ActionResult Index()
        {
            var sensors = db.Sensors.Include(s => s.SensorType);
            return View(sensors.ToList());
        }

        // GET: Sensors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        // GET: Sensors/Create
        public ActionResult Create()
        {
            ViewBag.SensorTypeId = new SelectList(db.SensorTypes, "SensorTypeId", "TypeDescription");
            return View();
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SensorName,SensorTypeId")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Sensors.Add(sensor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SensorTypeId = new SelectList(db.SensorTypes, "SensorTypeId", "TypeDescription", sensor.SensorTypeId);
            return View(sensor);
        }

        // GET: Sensors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//          Sensor sensor = db.Sensors.Find(id);
            var sensor = db.Sensors.SingleOrDefault(c => c.SensorName == id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            ViewBag.SensorTypeId = new SelectList(db.SensorTypes, "SensorTypeId", "TypeDescription", sensor.SensorTypeId);
            return View(sensor);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SensorName,SensorTypeId")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SensorTypeId = new SelectList(db.SensorTypes, "SensorTypeId", "TypeDescription", sensor.SensorTypeId);
            return View(sensor);
        }

        // GET: Sensors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sensor sensor = db.Sensors.Find(id);
            db.Sensors.Remove(sensor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSample.Core.BLL;
using EFSample.Models;
using EFSample.DBContext;

namespace EFSample.App.Controllers
{
    public class TraineeController : Controller
    {
        TraineeManager _traineeManager = new TraineeManager();
        InstitutionManager institutionManager = new InstitutionManager();
        // GET: /Trainee/
        public ActionResult Index()
        {
            var trainee =_traineeManager.GetAll();
            return View(trainee.ToList());
        }

        // GET: /Trainee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = _traineeManager.GetById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: /Trainee/Create
        public ActionResult Create()
        {
            var instituions = institutionManager.GetAll();
            ViewBag.InstitutionId = new SelectList(instituions, "Id", "Name");
            return View();
        }

        // POST: /Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,SEID,EnrollDate,Address,InstitutionId,IsDeleted")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeManager.Add(trainee);
                return RedirectToAction("Index");
            }

            var institutions = _traineeManager.GetAll();
            ViewBag.InstitutionId = new SelectList(institutions, "Id", "Name", trainee.InstitutionId);
            return View(trainee);
        }

        // GET: /Trainee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = _traineeManager.GetById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            var institutions = institutionManager.GetAll();
            ViewBag.InstitutionId = new SelectList(institutions, "Id", "Name", trainee.InstitutionId);
            return View(trainee);
        }

        // POST: /Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,SEID,EnrollDate,Address,InstitutionId,IsDeleted")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeManager.Update(trainee);
                return RedirectToAction("Index");
            }
            var institutions = institutionManager.GetAll();
            ViewBag.InstitutionId = new SelectList(institutions, "Id", "Name", trainee.InstitutionId);
            return View(trainee);
        }

        // GET: /Trainee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = _traineeManager.GetById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: /Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = _traineeManager.GetById(id);
            _traineeManager.Delete(trainee);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

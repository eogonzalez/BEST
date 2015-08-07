using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEST.Models;

namespace BEST.Controllers
{
    public class TipoSuscripcionController : Controller
    {
        private BESTDBEntities db = new BESTDBEntities();

        // GET: /TipoSuscripcion/
        public ActionResult Index()
        {
            return View(db.G_C_Tipo_Suscripcion.ToList());
        }

        // GET: /TipoSuscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Tipo_Suscripcion g_c_tipo_suscripcion = db.G_C_Tipo_Suscripcion.Find(id);
            if (g_c_tipo_suscripcion == null)
            {
                return HttpNotFound();
            }
            return View(g_c_tipo_suscripcion);
        }

        // GET: /TipoSuscripcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoSuscripcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_tipo_suscripcion,nombre,descripcion,estado")] G_C_Tipo_Suscripcion g_c_tipo_suscripcion)
        {
            if (ModelState.IsValid)
            {
                db.G_C_Tipo_Suscripcion.Add(g_c_tipo_suscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(g_c_tipo_suscripcion);
        }

        // GET: /TipoSuscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Tipo_Suscripcion g_c_tipo_suscripcion = db.G_C_Tipo_Suscripcion.Find(id);
            if (g_c_tipo_suscripcion == null)
            {
                return HttpNotFound();
            }
            return View(g_c_tipo_suscripcion);
        }

        // POST: /TipoSuscripcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_tipo_suscripcion,nombre,descripcion,estado")] G_C_Tipo_Suscripcion g_c_tipo_suscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_c_tipo_suscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(g_c_tipo_suscripcion);
        }

        // GET: /TipoSuscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Tipo_Suscripcion g_c_tipo_suscripcion = db.G_C_Tipo_Suscripcion.Find(id);
            if (g_c_tipo_suscripcion == null)
            {
                return HttpNotFound();
            }
            return View(g_c_tipo_suscripcion);
        }

        // POST: /TipoSuscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_C_Tipo_Suscripcion g_c_tipo_suscripcion = db.G_C_Tipo_Suscripcion.Find(id);
            db.G_C_Tipo_Suscripcion.Remove(g_c_tipo_suscripcion);
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

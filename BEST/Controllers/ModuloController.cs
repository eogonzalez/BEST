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
    public class ModuloController : Controller
    {
        private BESTDBEntities db = new BESTDBEntities();

        // GET: /Modulo/
        public ActionResult Index()
        {
            return View(db.G_C_Modulos.ToList());
        }

        // GET: /Modulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Modulos g_c_modulos = db.G_C_Modulos.Find(id);
            if (g_c_modulos == null)
            {
                return HttpNotFound();
            }
            return View(g_c_modulos);
        }

        // GET: /Modulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Modulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_modulo,nombre,descripcion,path,estado")] G_C_Modulos g_c_modulos)
        {
            if (ModelState.IsValid)
            {
                db.G_C_Modulos.Add(g_c_modulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(g_c_modulos);
        }

        // GET: /Modulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Modulos g_c_modulos = db.G_C_Modulos.Find(id);
            if (g_c_modulos == null)
            {
                return HttpNotFound();
            }
            return View(g_c_modulos);
        }

        // POST: /Modulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_modulo,nombre,descripcion,path,estado")] G_C_Modulos g_c_modulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_c_modulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(g_c_modulos);
        }

        // GET: /Modulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Modulos g_c_modulos = db.G_C_Modulos.Find(id);
            if (g_c_modulos == null)
            {
                return HttpNotFound();
            }
            return View(g_c_modulos);
        }

        // POST: /Modulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_C_Modulos g_c_modulos = db.G_C_Modulos.Find(id);
            db.G_C_Modulos.Remove(g_c_modulos);
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

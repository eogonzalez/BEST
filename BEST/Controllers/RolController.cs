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
    public class RolController : Controller
    {
        private BESTDBEntities db = new BESTDBEntities();

        // GET: /Rol/
        public ActionResult Index()
        {
            return View(db.G_C_Roles.ToList());
        }

        // GET: /Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Roles g_c_roles = db.G_C_Roles.Find(id);
            if (g_c_roles == null)
            {
                return HttpNotFound();
            }
            return View(g_c_roles);
        }

        // GET: /Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Rol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_rol,nombre,descripcion,fecha_registro,rol_del_sistema,estado")] G_C_Roles g_c_roles)
        {
            if (ModelState.IsValid)
            {
                db.G_C_Roles.Add(g_c_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(g_c_roles);
        }

        // GET: /Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Roles g_c_roles = db.G_C_Roles.Find(id);
            if (g_c_roles == null)
            {
                return HttpNotFound();
            }
            return View(g_c_roles);
        }

        // POST: /Rol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_rol,nombre,descripcion,fecha_registro,rol_del_sistema,estado")] G_C_Roles g_c_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_c_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(g_c_roles);
        }

        // GET: /Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Roles g_c_roles = db.G_C_Roles.Find(id);
            if (g_c_roles == null)
            {
                return HttpNotFound();
            }
            return View(g_c_roles);
        }

        // POST: /Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_C_Roles g_c_roles = db.G_C_Roles.Find(id);
            db.G_C_Roles.Remove(g_c_roles);
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

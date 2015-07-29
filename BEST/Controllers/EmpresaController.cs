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
    public class EmpresaController : Controller
    {
        private BESTDBEntities db = new BESTDBEntities();

        // GET: /Empresa/
        public ActionResult Index()
        {
            return View(db.G_C_Empresa.ToList());
        }

        // GET: /Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id);
            if (g_c_empresa == null)
            {
                return HttpNotFound();
            }
            return View(g_c_empresa);
        }

        // GET: /Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Empresa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_empresa,razon_social,nombre_comercial,direccion,email,telefono,fecha_registro,estado")] G_C_Empresa g_c_empresa)
        {
            if (ModelState.IsValid)
            {
                db.G_C_Empresa.Add(g_c_empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(g_c_empresa);
        }

        // GET: /Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id);
            if (g_c_empresa == null)
            {
                return HttpNotFound();
            }
            return View(g_c_empresa);
        }

        // POST: /Empresa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_empresa,razon_social,nombre_comercial,direccion,email,telefono,fecha_registro,estado")] G_C_Empresa g_c_empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_c_empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(g_c_empresa);
        }

        // GET: /Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id);
            if (g_c_empresa == null)
            {
                return HttpNotFound();
            }
            return View(g_c_empresa);
        }

        // POST: /Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id);
            db.G_C_Empresa.Remove(g_c_empresa);
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

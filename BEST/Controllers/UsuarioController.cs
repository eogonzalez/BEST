﻿using System;
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
    public class UsuarioController : Controller
    {
        private BESTDBEntities db = new BESTDBEntities();

        // GET: /Usuario/
        public ActionResult Index()
        {
            //var query = from usuarios in db.G_C_Usuario
            //            where usuarios.estado.Equals("A")
            //            select usuarios;

            var g_c_usuario = from usuario in db.G_C_Usuario.Include(g => g.G_C_Empresa)
                                  where usuario.estado.Equals("A")
                                  select usuario;

            return View(g_c_usuario.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id_usuario, int? id_empresa)
        {
            if ((id_usuario == null) && (id_empresa == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Usuario g_c_usuario = db.G_C_Usuario.Find(id_usuario, id_empresa);
            //G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id_empresa);
            if (g_c_usuario == null)
            {
                return HttpNotFound();
            }
            return View(g_c_usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_empresa = new SelectList(db.G_C_Empresa, "id_empresa", "razon_social");
            return View();
        }

        // POST: /Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(G_C_Usuario g_c_usuario)
        {
            if (ModelState.IsValid)
            {
                g_c_usuario.id_usuario = g_c_usuario.ObtenerCorrelativo(g_c_usuario.id_empresa);
                g_c_usuario.fecha_registro = DateTime.Now;
                g_c_usuario.estado = "A";

                db.G_C_Usuario.Add(g_c_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empresa = new SelectList(db.G_C_Empresa, "id_empresa", "razon_social", g_c_usuario.id_empresa);
            return View(g_c_usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id_empresa, int? id_usuario)
        {
            if ((id_usuario == null) && (id_empresa == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Usuario g_c_usuario = db.G_C_Usuario.Find(id_empresa, id_usuario);
            //G_C_Empresa g_c_empresa = db.G_C_Empresa.Find(id_usuario);
            if (g_c_usuario == null)
            {
                return HttpNotFound(); 
            }
            ViewBag.id_empresa = new SelectList(db.G_C_Empresa, "id_empresa", "razon_social", g_c_usuario.id_empresa);
            return View(g_c_usuario);
        }

        // POST: /Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_empresa,id_usuario,nombre,correo,fecha_registro,estado")] G_C_Usuario g_c_usuario)
        {
            if (ModelState.IsValid)
            {
                g_c_usuario.fecha_registro = DateTime.Now;
                g_c_usuario.estado = "A";

                db.Entry(g_c_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empresa = new SelectList(db.G_C_Empresa, "id_empresa", "razon_social", g_c_usuario.id_empresa);
            return View(g_c_usuario);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id_empresa, int? id_usuario)
        {
            if ((id_usuario == null) && (id_empresa == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_C_Usuario g_c_usuario = db.G_C_Usuario.Find(id_empresa, id_usuario);
            if ((g_c_usuario == null) && (id_empresa == null))
            {
                return HttpNotFound();
            }
            return View(g_c_usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id_empresa, int id_usuario)
        {

            G_C_Usuario g_c_usuario = db.G_C_Usuario.Find(id_empresa, id_usuario);
            
            g_c_usuario.fecha_registro = DateTime.Now;
            g_c_usuario.estado = "B";

            //db.G_C_Usuario.Remove(g_c_usuario);
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

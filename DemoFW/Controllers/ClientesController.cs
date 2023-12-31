﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoFW.Models;

namespace DemoFW.Controllers {
    [Authorize]

    public class ClientesController : Controller {
        private AWEntities db = new AWEntities();

        // GET: Clientes
        [AllowAnonymous]
        public ActionResult Index(int page = 0, int size = 20) {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.numRows = (double)db.Customers.Count();
            ViewBag.numPages = Math.Ceiling((double)ViewBag.numRows / size);
            return View();
//            return View(db.Customers.OrderBy(m => m.FirstName + m.MiddleName + m.LastName).Skip(page * size).Take(size).ToList());
        }

        // GET: Clientes
        [AllowAnonymous]
        public ActionResult List(int page = 0, int size = 20) {
            ViewBag.page = page;
            ViewBag.size = size;
            return PartialView("_list", db.Customers.OrderBy(m => m.FirstName + m.MiddleName + m.LastName).Skip(page * size).Take(size).ToList());
        }
        [AllowAnonymous]
        public ActionResult Datos(int page = 0, int size = 20) {
            ViewBag.page = page;
            ViewBag.size = size;
            var data = db.Customers.OrderBy(m => m.FirstName + m.MiddleName + m.LastName)
                .Skip(page * size).Take(size)
                .Select(e => new { id = e.CustomerID, nombre = e.FirstName, apellidos= e.LastName })
                .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Grid(int page = 0, int rows = 20) {
            return Datos(page, rows);
        }

        // GET: Clientes/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Where(item => item.CustomerID == id).Include("CustomerAddresses").Include("CustomerAddresses.Address").FirstOrDefault();
            if(customer == null) {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Clientes/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,NameStyle,Title,FirstName,MiddleName,LastName,Suffix,CompanyName,SalesPerson,EmailAddress,Phone,PasswordHash,PasswordSalt,rowguid,ModifiedDate")] Customer customer) {
            if(ModelState.IsValid) {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if(customer == null) {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,NameStyle,Title,FirstName,MiddleName,LastName,Suffix,CompanyName,SalesPerson,EmailAddress,Phone,PasswordHash,PasswordSalt,rowguid,ModifiedDate")] Customer customer) {
            //if(customer.ModifiedDate > DateTime.Now) {
            //    ModelState.AddModelError("ModifiedDate", "Tiene que ser una fecha pasada");
            //}
            if(ModelState.IsValid) {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if(customer == null) {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

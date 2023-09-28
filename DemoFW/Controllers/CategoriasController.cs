using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DemoFW.Models;

namespace DemoFW.Controllers {
    public class Categoria {
        public int ProductCategoryID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public static ProductCategory from(Categoria item) {
            return new ProductCategory() { ProductCategoryID = item.ProductCategoryID, Name = item.Name };
        }
        public static Categoria from(ProductCategory item) {
            return new Categoria() { ProductCategoryID = item.ProductCategoryID, Name = item.Name };
        }

    }
    public class CategoriasController : ApiController {
        private AWEntities db = new AWEntities();

        // GET: api/Categorias
        public IQueryable<Categoria> GetProductCategories(int page = 0, int size = 20) {
            return db.ProductCategories
                .Where(e => e.ParentProductCategoryID == null)
                .OrderBy(m => m.Name).Skip(page * size).Take(size)
                .Select(item => new Categoria() { ProductCategoryID = item.ProductCategoryID, Name = item.Name });
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult GetProductCategory(int id) {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if(productCategory == null) {
                return NotFound();
            }

            return Ok(Categoria.from(productCategory));
        }
        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        [HttpGet()]
        [Route("api/categorias/{id}/sub")]
        public IQueryable<Categoria> GetSubCategory(int id) {
            return db
                .ProductCategories.Where(e => e.ParentProductCategoryID == id)
                .Include("ProductCategory1")
                .Select(item => new Categoria() { ProductCategoryID = item.ProductCategoryID, Name = item.Name });
        }

        // POST: api/Categorias
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult PostProductCategory(Categoria productCategory) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newItem = db.ProductCategories.Add(Categoria.from(productCategory));
            newItem.ModifiedDate = DateTime.Now;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newItem.ProductCategoryID }, Categoria.from(newItem));
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductCategory(int id, Categoria productCategory) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if(id != productCategory.ProductCategoryID) {
                return BadRequest("No coinciden los identificadores");
            }

            var newItem = Categoria.from(productCategory);
            newItem.ModifiedDate = DateTime.Now;
            db.Entry(newItem).State = EntityState.Modified;

            try {
                db.SaveChanges();
            } catch(DbUpdateConcurrencyException) {
                if(!ProductCategoryExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProductCategory(int id) {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if(productCategory == null) {
                return NotFound();
            }

            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id) {
            return db.ProductCategories.Count(e => e.ProductCategoryID == id) > 0;
        }
    }
}
using SpiderFoodStore.Data;
using SpiderFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.UI.WebControls;

namespace SpiderFoodStore.Areas.QWRtaW5TcGlkZXI.Controllers
{
    public class ListImagesController : Controller
    {
        SpiderFoodStoreContext db = new SpiderFoodStoreContext();
        // GET: QWRtaW5TcGlkZXI/ListImages
        public ActionResult Index(int? productId)
        {
            if(productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.FirstOrDefault(n => n.Id == productId);
            if(product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Product = product;
            List<ListImages> list = db.ListImages.Where(n => n.ProductId == productId).ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase ImageFile, FormCollection frm)
        {
            int id = int.Parse(frm["id"].ToString());
            if (ImageFile == null)
            {
                ViewBag.Message = "Please choose file image";
                return RedirectToAction("Index", "ListImages", new {productId=id});
            }
            ListImages list = new ListImages();
            list.ProductId = id;
            string fileName = Path.GetFileName(ImageFile.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
            if (!System.IO.File.Exists(path))
            {
                ImageFile.SaveAs(path);
            }
            list.ImagePath = fileName;
            db.ListImages.Add(list);
            db.SaveChanges();
            ViewBag.Message = "Upload successfull";
            return RedirectToAction("Index", "ListImages", new { productId = id });
        }
        public ActionResult Delete(int? id, int productId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListImages list = db.ListImages.FirstOrDefault(n => n.Id == id);
            if(list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ProductId = productId;
            return View(list);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int productId)
        {
            ListImages list = db.ListImages.Find(id);
            db.ListImages.Remove(list);
            db.SaveChanges();
            return RedirectToAction("Index", new {productId = productId});
        }
    }
}
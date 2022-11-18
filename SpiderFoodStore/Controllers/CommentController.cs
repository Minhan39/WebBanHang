using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using SpiderFoodStore.Data;
using SpiderFoodStore.Models;

namespace SpiderFoodStore.Controllers
{
    public class CommentController : Controller
    {
        private SpiderFoodStoreContext db = new SpiderFoodStoreContext();

        private List<CommentCustomer> GetList(int id)
        {
            return (from Comments in db.Comments
                    join Customers in db.Customers on new { Id = Comments.CustomerId } equals new { Id = Customers.Id }
                    where Comments.ProductId == id
                    select new CommentCustomer
                    {
                        Id = Comments.Id,
                        ProductId = Comments.ProductId,
                        Content = Comments.Content,
                        Parent = Comments.Parent,
                        Firstname = Customers.Firstname,
                        Lastname = Customers.Lastname,
                        ImagePath = Customers.ImagePath
                    }).ToList();
        }

        public ActionResult ParentComment(int id)
        {
            List<CommentCustomer> list = GetList(id);
            list = list.Where(n => n.Parent == -1).ToList();
            ViewBag.ProductId = id;
            return PartialView("ParentComment",list);
        }
        [ChildActionOnly]
        public ActionResult ChildComment(int id,int parentId)
        {
            List<CommentCustomer> list = GetList(id);
            list = list.Where(n => n.Parent.Equals(parentId) && n.Parent > -1).ToList();
            ViewBag.ProductId = id;
            return PartialView("ChildComment", list);
        }
        [HttpPost]
        public ActionResult NewComment(FormCollection frm)
        {
            string content = frm["content"].ToString();
            int id = int.Parse(frm["id"].ToString());
            int parent = int.Parse(frm["parent"].ToString());
            if (Session["Customer"] == null)
            {
                return RedirectToAction("Details", "Product", new { id=id });
            }
            Customer customer = Session["Customer"] as Customer;
            Comment comment = new Comment();
            comment.ProductId = id;
            comment.CustomerId = customer.Id;
            comment.Content = content;
            comment.Parent = parent;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Product", new {id=id});
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class TheLoaiSPController : Controller
    {
        // GET: TheLoaiSP
        DataClasses1DataContext data = new DataClasses1DataContext("localhost8080");
        public ActionResult Index()
        {
            var all_theloai = from tt in data.TheLoaiSPs select tt;
            return View(all_theloai);
        }

        public ActionResult Detail(int id)
        {
            var D_theloai = data.TheLoaiSPs.Where(m => m.maloaisp == id).First();
            return View(D_theloai);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TheLoaiSP tl)
        {
            var ten = collection["tenloaisp"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tenloaisp = ten;
                data.TheLoaiSPs.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
  
        public ActionResult Edit(int id)
        {
            var E_category = data.TheLoaiSPs.First(m => m.maloaisp == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.TheLoaiSPs.First(m => m.maloaisp == id);
            var E_tenloai = collection["tenloaisp"];
            theloai.maloaisp = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenloaisp = E_tenloai;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_theloai = data.TheLoaiSPs.First(m => m.maloaisp == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.TheLoaiSPs.Where(m => m.maloaisp == id).First();
            data.TheLoaiSPs.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}
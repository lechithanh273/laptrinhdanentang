using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        DataClasses1DataContext data = new DataClasses1DataContext("alhost8080");
        public ActionResult Index()
        {
            var all_theloai = from tt in data.SanPhams select tt;
            return View(all_theloai);
        }

        //---------------Detail----------------
        public ActionResult Detail(int id)
        {
            var D_sach = data.SanPhams.Where(m => m.masp == id).First();
            return View(D_sach);
        }

        //---------------Create----------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham s)
        {
            var E_tensach = collection["tensp"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngay = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_sl = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tensp = E_tensach.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_giaban;
                s.ngaycapnhat = E_ngay;
                s.soluongton = E_sl;
                data.SanPhams.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }


        //---------------Edit----------------
        public ActionResult Edit(int id)
        {
            var E_sach = data.SanPhams.First(m => m.masp == id);
            return View(E_sach);
        }
        [HttpPost]

        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.SanPhams.First(m => m.masp == id);
            var E_tensach = collection["tensp"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sach.masp = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Không được bỏ trống!";
            }
            else
            {
                E_sach.tensp = E_tensach;
                E_sach.hinh = E_hinh;
                E_sach.giaban = E_giaban;
                E_sach.ngaycapnhat = E_ngaycapnhat;
                E_sach.soluongton = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        //---------------Delete----------------
        public ActionResult Delete(int id)
        {
            var D_sach = data.SanPhams.First(m => m.masp == id);
            return View(D_sach);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.SanPhams.Where(m => m.masp == id).First();
            data.SanPhams.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}
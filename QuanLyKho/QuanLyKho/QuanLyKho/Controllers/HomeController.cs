using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace QuanLyKho.Controllers
{
    public class HomeController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext("localhost8080");
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_sach = (from s in data.SanPhams select s).OrderBy(m => m.masp);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

    }
}
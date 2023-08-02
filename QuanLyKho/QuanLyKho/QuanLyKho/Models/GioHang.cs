using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QuanLyKho.Models;

namespace QuanLyKho.Models
{
    public class GioHang
    {
        DataClasses1DataContext data = new DataClasses1DataContext("localhost8080");
        public int masp { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string tensp { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }

        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * giaban; }
        }

        public GioHang(int id)
        {
            masp = id;
            SanPham truyen = data.SanPhams.Single(n => n.masp == masp);
            tensp = truyen.tensp;
            hinh = truyen.hinh;
            giaban = double.Parse(truyen.giaban.ToString());
            iSoluong = 1;
        }

    }
}

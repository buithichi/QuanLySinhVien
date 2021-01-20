using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace QuanLyRenLuyen.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index(SinhVien sv)
        {
            if(sv != null)
            {
                var SinhVien = new SinhVienDao();
                SinhVien.XoaSV(sv.MaSV);
            }
            var SinhVienDao = new SinhVienDao();
            ViewBag.ListSinhVien = SinhVienDao.ListSinhVien();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string search_text)
        {
            
            var SinhVienDao = new SinhVienDao();
            var list = SinhVienDao.ListSinhVienSearch(search_text);
            ViewBag.ListSinhVien = list;
            ViewBag.SoLuongKQ = "Có "+list.Count()+" kết quả được tìm thấy!";
            return View();
        }

        [HttpGet]
        public ActionResult ThemSV(User us)
        {
            var lop = new LopDao();
            var nganh = new NganhDao();
            SetViewBag(lop.Id_lop_MacDinh());
            SetViewBag2(nganh.Id_Nganh_MacDinh());
            return View();
        }
        [HttpPost]
        public ActionResult ThemSV(SinhVien model)
        {

            var dao = new SinhVienDao();
            if (dao.KiemTraTrungMaSV(model.MaSV) == 1)
            {
                dao.create1(model);
                SetViewBag(model.Id_Lop);
                SetViewBag2(model.Id_Nganh);
                ViewBag.Loi = "Thêm thành công";
                return View(dao.GetSV(model.MaSV)); }
            else {
                SetViewBag(model.Id_Lop);
                SetViewBag2(model.Id_Nganh);
                ViewBag.Loi = "Trùng mã sinh viên";
                return View();
            }


            
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new LopDao();
            ViewBag.Id_Lop = new SelectList(dao.ListCurent(), "Id_Lop", "TenLop", selectedId);
        }
        public void SetViewBag2(int? selectedId = null)
        {
            var dao = new NganhDao();
            ViewBag.Id_Nganh = new SelectList(dao.ListCurent(), "Id_Nganh", "TenNganh", selectedId);
        }




    }
}
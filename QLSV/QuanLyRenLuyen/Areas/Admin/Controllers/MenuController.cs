using Model.Dao;
using Model.EF;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyRenLuyen.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThongKe(User user1)
        {
            /*var NamHoc = new NamHocDao();
            ViewBag.ListNamHoc = NamHoc.ListAll();
            var HocKy = new HocKiDao();
            ViewBag.ListHocKy = HocKy.ListAll();
            var user = new UserDao().GetById(user1.UserName);*/
            return View();//user);
        }
        [HttpPost]
        public ActionResult ThongKe(string Id_NamHoc, string Id_HocKy)
        {
            return View();
        }

        [HttpGet]
        public ActionResult NguoiDung(SinhVien SV)
        {
            SetViewBag(SV.Id_Lop);
            SetViewBag2(SV.Id_Nganh);
            return View(SV);
        }

        [HttpPost]
        public ActionResult NguoiDung(SinhVien model, string name)
        {

            var dao = new SinhVienDao();
            dao.Update(model);


            SetViewBag(model.Id_Lop);
            SetViewBag2(model.Id_Nganh);
            return View(dao.GetSV(model.MaSV));
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
        public ActionResult Index(SinhVien sv)
        {
            var SinhVien = new SinhVienDao();
            SinhVien.XoaSV(sv.MaSV);
            return View();
        }

        [HttpGet]
        public ActionResult XuatFile()
        {

            return View();
        }
        [HttpPost]
        public ActionResult XuatFile(string a)
        {


            var List = new SinhVienDao().ListSinhVien();


            if (List.Count() != 0)
            {
                ExcelPackage Ep = new ExcelPackage();
                ExcelWorksheet sheet = Ep.Workbook.Worksheets.Add("Report");
                sheet.Cells["A1"].Value = "Mã sinh viên";
                sheet.Cells["B1"].Value = "Họ và tên";
                sheet.Cells["C1"].Value = "Giới tính";
                sheet.Cells["D1"].Value = "Số điện thoại";
                sheet.Cells["E1"].Value = "Email";
                sheet.Cells["F1"].Value = "Ngày sinh";
                sheet.Cells["G1"].Value = "Nơi sinh";
                sheet.Cells["H1"].Value = "Chỗ tạm trú";
                sheet.Cells["I1"].Value = "Chức vụ";
                sheet.Cells["J1"].Value = "Lớp";
                sheet.Cells["K1"].Value = "Ngành";
                sheet.Cells["L1"].Value = "Khoa";
                int row = 2;
                foreach (var item in List)
                {
                    sheet.Cells[string.Format("A{0}", row)].Value = item.MaSV;
                    sheet.Cells[string.Format("B{0}", row)].Value = item.HoTen;
                    sheet.Cells[string.Format("C{0}", row)].Value = item.GioiTinh;
                    sheet.Cells[string.Format("D{0}", row)].Value = item.SoDT;
                    sheet.Cells[string.Format("E{0}", row)].Value = item.Email;
                    sheet.Cells[string.Format("F{0}", row)].Value = item.NgaySinh + "";
                    sheet.Cells[string.Format("G{0}", row)].Value = item.NoiSinh;
                    sheet.Cells[string.Format("H{0}", row)].Value = item.ChoTamTru;
                    sheet.Cells[string.Format("I{0}", row)].Value = item.ChucVu;
                    sheet.Cells[string.Format("J{0}", row)].Value = item.Lop.TenLop;
                    sheet.Cells[string.Format("K{0}", row)].Value = item.Nganh.TenNganh;
                    sheet.Cells[string.Format("L{0}", row)].Value = item.Nganh.Khoa.TenKhoa;

                    row++;
                }

                sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            else ModelState.AddModelError("", "Không tồn tại sinh viên.");


            return View();
        }




        [HttpGet]
        public ActionResult NhapFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NhapFile(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Bạn chưa tải file lên<br>";
                return View();
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/assets/excel/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    //read data form excel
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    var listSV = new SinhVienDao();
                    for (int row = 2; row < range.Rows.Count; row++)
                    {
                        var sv = new SinhVien();
                        sv.MaSV = double.Parse(((Excel.Range)range.Cells[row, 1]).Text);
                        sv.HoTen = ((Excel.Range)range.Cells[row, 2]).Text;
                        sv.GioiTinh = ((Excel.Range)range.Cells[row, 3]).Text;
                        sv.SoDT = ((Excel.Range)range.Cells[row, 4]).Text;
                        sv.Email = ((Excel.Range)range.Cells[row, 5]).Text;
                        sv.NgaySinh = DateTime.Now;
                        sv.NoiSinh = ((Excel.Range)range.Cells[row, 7]).Text;
                        sv.ChoTamTru = ((Excel.Range)range.Cells[row, 8]).Text;
                        sv.ChucVu = ((Excel.Range)range.Cells[row, 9]).Text;

                        var Lop = new LopDao();

                        sv.Id_Lop = Lop.lop(((Excel.Range)range.Cells[row, 10]).Text).Id_Lop;

                        var nganh = new NganhDao();

                        sv.Id_Nganh = nganh.nganh(((Excel.Range)range.Cells[row, 11]).Text).Id_Nganh;
                        listSV.create1(sv);


                    }

                    return View();
                }

                else
                {
                    ViewBag.Error = "Bạn chưa tải file lên";
                    return View();
                }
            }


            return View();
        }



        [HttpGet]
        public ActionResult ThemLop()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemLop(Lop lop)
        {
            var lopdao = new LopDao();
            lopdao.themlop(lop);
           
            return View();
        }














    } }
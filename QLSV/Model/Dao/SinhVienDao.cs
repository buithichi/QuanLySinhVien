using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Model.Dao
{
    public class SinhVienDao
    {
        Model1 db = null;
         public SinhVienDao()
         {
             db = new Model1();
         }
         public List<SinhVien> ListSinhVien()
         {
             return db.SinhViens.OrderByDescending(x => x.MaSV).Where(x=>x.xoa ==0).ToList();
         }

         public SinhVien GetSV(double MaSV)
         {
             return db.SinhViens.Where(x => x.xoa == 0 && x.MaSV == MaSV).SingleOrDefault();
         }

        public void XoaSV(double MaSV)
        {
            var SV = db.SinhViens.Find(MaSV);
            if (SV != null)
            {
                SV.xoa = 1;
                db.SaveChanges();
            }
        }

        public int nam()
        {
            return db.SinhViens.Where(x => x.xoa == 0 && x.GioiTinh == "Nam").Count();
        }
        public int nu()
        {
            return db.SinhViens.Where(x => x.xoa == 0 && x.GioiTinh == "Nữ").Count();
        }
    
         public void Insert(SinhVien SV)   
         {
             db.SinhViens.Add(SV);
             db.SaveChanges();
         }

        public int KiemTraTrungMaSV(double MaSV)
        {
            List<SinhVien> list = db.SinhViens.OrderByDescending(x => x.MaSV).Where(x => x.MaSV == MaSV ).ToList();
            if (list.Count() == 0)
                return 1;
            else return 0;
        }

        public void create(double MaSV,string HoTen)
         {
             var SV = new SinhVien();
             SV.MaSV = MaSV;
             SV.HoTen = HoTen;
             SV.Anh = "/assets/client/image/hack.jpg";
             SV.xoa = 0;
             Insert(SV);
         }

        public void create1(SinhVien SV)
        {
            var sinhVien = new SinhVien();
            sinhVien.MaSV = SV.MaSV;
            sinhVien.HoTen = SV.HoTen;
            sinhVien.GioiTinh = SV.GioiTinh;
            sinhVien.SoDT = SV.SoDT;
            sinhVien.Email = SV.Email;
            sinhVien.NgaySinh = SV.NgaySinh;
            sinhVien.NoiSinh = SV.NoiSinh;
            sinhVien.ChoTamTru = SV.ChoTamTru;
            sinhVien.ChucVu = SV.ChucVu;
            sinhVien.Anh = "/assets/client/image/hack.jpg";
            sinhVien.xoa = 0;
            sinhVien.Id_Lop = SV.Id_Lop;
            sinhVien.Id_Nganh = SV.Id_Nganh;
            Insert(sinhVien);
        }

        public void Update(SinhVien SV)
         {
             var sinhVien = GetSV(SV.MaSV);

             sinhVien.HoTen = SV.HoTen;
             sinhVien.GioiTinh = SV.GioiTinh;
             sinhVien.SoDT = SV.SoDT;
             sinhVien.Email = SV.Email;
             sinhVien.NgaySinh = SV.NgaySinh;
             sinhVien.NoiSinh = SV.NoiSinh;
             sinhVien.ChoTamTru = SV.ChoTamTru;
             sinhVien.ChucVu = SV.ChucVu;
             sinhVien.xoa = 0;
             sinhVien.Id_Lop = SV.Id_Lop;
            sinhVien.Id_Nganh = SV.Id_Nganh;
            db.SaveChanges();
         }

         public List<SinhVien> ListSinhVienSearch(string search_text)
         {
             if (search_text == null || search_text.Equals(""))
                 return ListSinhVien();
             else
             {
                 List<SinhVien> list = db.SinhViens.OrderByDescending(x => x.MaSV).Where(x => x.HoTen == search_text && x.xoa == 0).ToList();
                if (list.Count() == 0)
                 {
                     if (IsNumber(search_text))
                     {
                         double a = Double.Parse(search_text);
                         list = db.SinhViens.OrderByDescending(x => x.MaSV).Where(x => x.MaSV == a && x.xoa == 0).ToList();
                         if (list.Count() == 0)
                         {
                             return ListSinhVien();
                         }
                         else return list;
                     }
                    else
                    {
                        var nganh = db.Nganhs.Where(x => x.TenNganh == search_text ).SingleOrDefault();
                        if(nganh == null)
                        {
                            return ListSinhVien();
                        }
                        else
                        {
                            list = db.SinhViens.OrderByDescending(x => x.MaSV).Where(x => x.Id_Nganh == nganh.Id_Nganh).ToList();
                            if (list.Count() == 0)
                            {
                                return ListSinhVien();
                            }
                            else return list;
                        }
                       
                    }
                 }
                 else return list;
             }

         }

         private bool IsNumber(string s)
         {
             foreach (Char c in s)
             {
                 if (!Char.IsDigit(c))
                     return false;
             }
             return true;
         }
         
    }
}

using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LopDao
    {

        Model1 db = null;
        public LopDao()
        {
            db = new Model1();
        }

        public List<Lop> ListAll()
        {
            return db.Lops.ToList();
       }


        public List<Lop> ListCurent()
        {
            DateTime ngaythang =  DateTime.Now;
            int? namHienTai = ngaythang.Year;
            return db.Lops.ToList();
        }

        public int Id_lop_MacDinh()
        {
            return db.Lops.ToList()[0].Id_Lop;
        }

        public Lop lop(string tenlop)
        {
            return db.Lops.Where(x => x.TenLop == tenlop).First();
        }

        public void themlop(Lop lop)
        {
            db.Lops.Add(lop);
            db.SaveChanges();
        }


    }
}


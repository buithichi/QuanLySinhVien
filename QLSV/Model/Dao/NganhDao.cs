using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NganhDao
    {

        Model1 db = null;
        public NganhDao()
        {
            db = new Model1();
        }

        public List<Nganh> ListAll()
        {
            return db.Nganhs.ToList();
        }


        public List<Nganh> ListCurent()
        {
            return db.Nganhs.ToList();
        }

        public int Id_Nganh_MacDinh()
        {
            return db.Nganhs.ToList()[0].Id_Nganh;
        }


        public Nganh nganh(string tennganh)
        {
                return db.Nganhs.Where(x => x.TenNganh == tennganh).First();
        }

    }
}

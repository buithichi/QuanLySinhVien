namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        public double MaSV { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(15)]
        public string SoDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(400)]
        public string NoiSinh { get; set; }

        [StringLength(400)]
        public string ChoTamTru { get; set; }

        [StringLength(20)]
        public string ChucVu { get; set; }

        [StringLength(1000)]
        public string Anh { get; set; }

        public int? Id_Lop { get; set; }

        public int? Id_Nganh { get; set; }

        public int? xoa { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual Nganh Nganh { get; set; }
    }
}

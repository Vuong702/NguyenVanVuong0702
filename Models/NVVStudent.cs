using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenVanVuong0702.Models
{
    public class NVVStudent
    {
        [Key]
         public int MaSinhVien { get; set; }
       
        public string TenSinhVien{ get; set; }
          public string lop { get; set; }
    
    }
}
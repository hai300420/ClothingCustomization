using System.ComponentModel.DataAnnotations;

namespace ClothingCustomization.DTO
{
    public class UserDTO
    {
        [Required]
        public string TaiKhoan { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        
        public string? DiaChi { get; set; }

        public string? DienThoai { get; set; }
        [Required]
        public string Email { get; set; }
  
        public string? Hinh { get; set; }

    }
}

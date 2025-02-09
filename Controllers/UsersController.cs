using ClothingCustomization.Data;
using ClothingCustomization.DTO;
using ClothingCustomization.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothingCustomization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(IUserRepository userRepo, IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = userRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromQuery] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the user already exists
            var existingUser = (await _userRepo.GetUsers()).FirstOrDefault(x => x.TaiKhoan == userDto.TaiKhoan);
            if (existingUser != null)
            {
                return BadRequest("Tai khoan nay da su dung");
            }


            // Map DTO to Entity
            var newUser = new User
            {
                TaiKhoan = userDto.TaiKhoan,
                MatKhau = userDto.MatKhau,
                HoTen = userDto.HoTen,
                GioiTinh = userDto.GioiTinh,
                NgaySinh = userDto.NgaySinh,
                DiaChi = userDto.DiaChi,
                DienThoai = userDto.DienThoai,
                Email = userDto.Email,
                RoleId = 3,
                HieuLuc = true,
            };

            await _userRepo.Register(newUser);

            return Ok(new { Message = "Tai khoan dang ki thanh cong", UserId = newUser.UserId });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string taikhoan, string matkhau)
        {
            var user = await _userRepo.Login(taikhoan, matkhau);
            if (user != null)
            {
                // Store user in session
                _httpContextAccessor.HttpContext.Session.SetInt32("UserId", user.UserId);
                return Ok(user);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return BadRequest(new { Message = "Ban chua dang nhap" });
            }

            _httpContextAccessor.HttpContext.Session.Clear();
            return Ok(new { Message = "Da dang xuat thanh cong" });
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepo.GetUsers());
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepo.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }
    }
}

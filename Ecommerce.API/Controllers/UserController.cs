using Ecommerce.BL.Dtos.User;
using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("RegiterAdmin")]
        [Authorize(Policy = "SuperAdminOnly")]
        public async Task<ActionResult> RegisterAdmin(RegisterDto registerDto)
        {
            #region create new user

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Governorate = registerDto.Governorate,
                Adress = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result= await _userManager.CreateAsync(user,registerDto.Password);
            if(!result.Succeeded)
            { 
                return BadRequest(result.Errors); 
            }
            #endregion

            #region creat claims

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"admin"),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            await _userManager.AddClaimsAsync(user, claimList);
            #endregion

            return Ok();
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
        {
            #region create new user

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Governorate = registerDto.Governorate,
                Adress = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            #endregion

            #region creat claims

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"user"),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            await _userManager.AddClaimsAsync(user, claimList);
            #endregion

            return Ok();
        }


        [HttpPost]
       [ Route("login")]
       public async Task<ActionResult<TokenDto>>Login(LoginDto credential)
        {
            var user = await _userManager.FindByEmailAsync(credential.Email);
            if (user == null) { return Unauthorized(); }
            var isAuthentication =await _userManager.CheckPasswordAsync(user, credential.Password);
            if (!isAuthentication) { return Unauthorized(); }
            var claimList =await _userManager.GetClaimsAsync(user);

            #region secret key
            var secretKeyString = _configuration.GetValue<string>("secretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ??"");
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);
            #endregion

            #region combination of secretKey,algorthim
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            #endregion

            #region generate token
            var expiryDate = DateTime.Now.AddDays(7);
            var token = new JwtSecurityToken(
                claims: claimList,
                expires: expiryDate,
                signingCredentials: signInCredentials);
            #endregion

            #region convert token to string
            var tokenHandelar = new JwtSecurityTokenHandler();
            var tokenString = tokenHandelar.WriteToken(token);
            #endregion

            return Ok(new TokenDto(tokenString));

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDetailsDto>> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return new UserDetailsDto(user.UserName, user.Email);
        }

        [HttpGet]
        [Route("EmailExists")]
        public async Task<ActionResult<bool>>CheckEmailExists([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

    }
}

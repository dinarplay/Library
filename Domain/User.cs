using Domain.Common;
using System.Security.Claims;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Reserve> ReservedBooks { get; set; }
        public ClaimsPrincipal ToClaimsPrincipal() //Конвертировать текущего User'а в ClaimPrincipal
        {
            var claims = new Claim[]
            {
                new ("Id", Id.ToString()),
                new (ClaimTypes.Name, Name),
                new (ClaimTypes.Email, Email),
                new (ClaimTypes.Hash, Password),
                new (ClaimTypes.Role, RoleId.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(claims, "ScBlazor");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
        public static User FromClaimsPrincipal(ClaimsPrincipal principal) //Конвертировать ClaimPrincipal в User'а
        {
            var user = new User()
            {
                Name = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
                Email = principal.FindFirst(ClaimTypes.Email)?.Value ?? "",
                Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
                RoleId = Convert.ToInt32(principal.FindFirst(ClaimTypes.Role)?.Value ?? "0"),
                Id = Convert.ToInt32(principal.FindFirst("Id")?.Value ?? "0"),
            };
            return user;
        }
    }
}


using Domain.Common;

namespace Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool IsChoised { get; set; } = true;
        List<User> Users { get; set; }  
    }
}

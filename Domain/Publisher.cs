using Domain.Common;

namespace Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsChoised { get; set; } = true;
        public List<Book> Books { get; set; }
    }
}

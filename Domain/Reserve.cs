using Domain.Common;

namespace Domain
{
    public class Reserve : BaseEntity
    {
        public bool IsTaken { get; set; }
        public DateTime Created { get; set; }
        public DateTime Canceling { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public bool IsDone { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}

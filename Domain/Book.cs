using Domain.Common;

namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
    }
}

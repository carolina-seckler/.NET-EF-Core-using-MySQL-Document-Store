using Library.Domain.Model;

namespace Library.Application.Commands.Model
{
    public class BookCommandModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int Language { get; set; }
        public int IdPublisher { get; set; }
        public virtual PublisherCommandModel Publisher { get; set; }
    }
}

using Domain.Model.Enums;

namespace Domain.Model
{
    public class Work : BaseEntity
    {
        public DateOnly DateOfWork { get; set; }
        public DateOnly DateOfNote { get; set; }
        public string Place { get; set; }
        public KindOfWork KindOfWork { get; set; }
        public string Tasks { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
    }
}

using Domain.Model.Enums;

namespace Contracts.Dtos.Task
{
    public class WorkDto
    {
        public int Id { get; set; }
        public DateOnly DateOfWork { get; set; }
        public DateOnly DateOfNote { get; set; }
        public string Place { get; set; }
        public KindOfWork KindOfWork { get; set; }
        public string Tasks { get; set; }
        public decimal Price { get; set; }
    }
}

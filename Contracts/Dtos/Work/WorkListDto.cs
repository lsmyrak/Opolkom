namespace Contracts.Dtos.Task;

public class WorkListDto
{
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }

    public List<WorkDto> Tasks { get; set; } = new List<WorkDto>();

    public void Calc()
    {
        Count = Tasks.Count;

        foreach (var task in Tasks)
        {
            TotalPrice += task.Price;
        }
    }
}

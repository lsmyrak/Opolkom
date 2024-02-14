using Contracts.Dtos.Task;
using Domain.Model;

namespace WebAPI.Mappers
{
    public static class ManualMappingExtention
    {
        public static WorkDto ToDto(this Work work)
        {
            if (work != null)
            {
                return new WorkDto
                {
                    DateOfNote = work.DateOfNote,
                    DateOfWork = work.DateOfWork,
                    Id = work.Id,
                    KindOfWork = work.KindOfWork,
                    Place = work.Place,
                    Price = work.Price,
                    Tasks = work.Tasks,
                    Settled = work.Settled,
                };
            }
            return null;
        }
    }
}

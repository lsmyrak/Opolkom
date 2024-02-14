namespace Domain.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public virtual List<Work> Works { get; private set; }


        public User()
        {
            Works = new List<Work>();
        }
        /// <summary>
        /// work Section
        /// </summary>
        /// <param name="work"></param>
        public void AddWork(Work work)
        {
            Works.Add(work);
        }
        public void RemoveWork(Work work)
        {
            Works.Remove(work);
        }
        public void ClearWork()
        {
            Works.Clear();
        }
        public void UpdateWork(Work work)
        {
            var workUpdate = Works.SingleOrDefault(x => x.Id == work.Id);
            if (workUpdate != null)
            {
                workUpdate.Tasks = work.Tasks;
                workUpdate.Place = work.Place;
                workUpdate.DateOfWork = work.DateOfWork;
                workUpdate.DateOfNote = work.DateOfNote;
                workUpdate.KindOfWork = work.KindOfWork;
                workUpdate.Price = work.Price;
            }
        }
        public void Settlement(int idWork)
        {
            var work = Works.FirstOrDefault(x => x.Id == idWork);
            if (work != null)
            {
                work.Settled = true;
            }
        }
    }
}

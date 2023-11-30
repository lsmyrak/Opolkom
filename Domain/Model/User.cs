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
    }
}

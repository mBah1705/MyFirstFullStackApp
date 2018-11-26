namespace Common.Models
{
    public class CandidateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestId { get; set; }

        public string TestName { get; set; }
        public int Grade { get; set; }
    }
}

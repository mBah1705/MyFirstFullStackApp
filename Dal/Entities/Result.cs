namespace Dal.Entities
{
    public partial class Result
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? AnswerId { get; set; }

        public Answer Answer { get; set; }
        public Candidate Candidate { get; set; }
    }
}

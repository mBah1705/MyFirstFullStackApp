namespace Common.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? AnswerId { get; set; }

        public AnswerModel Answer { get; set; }
        public CandidateModel Candidate { get; set; }
    }
}

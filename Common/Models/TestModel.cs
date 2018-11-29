using System.Collections.Generic;

namespace Common.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<CandidateModel> Candidate { get; set; }
        public ICollection<TestQuestionModel> TestQuestion { get; set; }
    }
}

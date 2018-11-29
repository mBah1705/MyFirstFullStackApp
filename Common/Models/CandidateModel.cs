using System.Collections.Generic;

namespace Common.Models
{
    public class CandidateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestId { get; set; }

        public TestModel Test { get; set; }
        public ICollection<ResultModel> Result { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class CandidateWithResultModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestId { get; set; }

        public string TestTitle { get; set; }
        public int Score { get; set; }
    }
}

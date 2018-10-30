using System;
using System.Collections.Generic;

namespace Dal.Entities.DB
{
    public partial class Candidate
    {
        public Candidate()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestId { get; set; }

        public Test Test { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}

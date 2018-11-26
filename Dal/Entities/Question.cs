using System.Collections.Generic;

namespace Dal.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Statement { get; set; }

        public ICollection<Answer> Answer { get; set; }
        public ICollection<TestQuestion> TestQuestion { get; set; }
    }
}

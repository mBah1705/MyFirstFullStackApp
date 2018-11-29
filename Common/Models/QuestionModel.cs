using System.Collections.Generic;

namespace Common.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Statement { get; set; }

        public ICollection<AnswerModel> Answer { get; set; }
        public ICollection<TestQuestionModel> TestQuestion { get; set; }
    }
}

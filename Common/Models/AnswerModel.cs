using System.Collections.Generic;

namespace Common.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public bool IsGood { get; set; }

        public QuestionModel Question { get; set; }
        public ICollection<ResultModel> Result { get; set; }
    }
}

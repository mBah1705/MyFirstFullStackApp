namespace Dal.Entities.DB
{
    public partial class TestQuestion
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
        public Test Test { get; set; }
    }
}

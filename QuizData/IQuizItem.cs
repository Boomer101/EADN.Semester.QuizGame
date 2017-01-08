namespace QuizData
{
    public interface IQuizItem
    {
        QuizGameElement QuizGame { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}
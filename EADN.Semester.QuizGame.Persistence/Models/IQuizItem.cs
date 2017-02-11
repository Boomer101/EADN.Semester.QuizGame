using System;

namespace EADN.Semester.QuizGame.Persistence
{
    public interface IQuizItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
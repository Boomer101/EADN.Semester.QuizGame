using System;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    public interface IQuizItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
using System;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    public interface IQuizBase
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
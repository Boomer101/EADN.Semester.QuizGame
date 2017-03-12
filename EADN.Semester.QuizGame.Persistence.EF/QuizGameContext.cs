using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class QuizGameContext : DbContext
    {
        public QuizGameContext() : base("name=QuizGameDBConnectionString")
        { }

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}

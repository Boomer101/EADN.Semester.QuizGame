using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF.Models
{
    public class Question : QuizBase
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public Question()
        {
            Topics = new HashSet<Topic>();
            Quizzes = new HashSet<Quiz>();
            Answers = new HashSet<Answer>();
        }
    }
}

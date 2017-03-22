using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF.Models
{
    public class Player : User
    {
        public virtual ICollection<Quiz> PlayedQuizzes { get; set; }
    }
}

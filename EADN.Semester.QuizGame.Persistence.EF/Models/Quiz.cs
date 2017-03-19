
using EADN.Semester.QuizGame.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class Quiz : QuizBase
    {
        public Models.QuizType QuizType { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}


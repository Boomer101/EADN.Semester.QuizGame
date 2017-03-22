
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF.Models
{
    /// <summary>
    /// Entity Framework Quiz represantion
    /// </summary>
    /// <seealso cref="EADN.Semester.QuizGame.Persistence.EF.Models.QuizBase" />
    public class Quiz : QuizBase
    {
        public Models.QuizType QuizType { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public int MinAmountQuestions { get; set; }
        public int MaxAmountQuestions { get; set; }
        public virtual Player Player { get; set; } 

        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}


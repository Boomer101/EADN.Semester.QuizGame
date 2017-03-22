using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF.Models
{
    public class Answer : QuizBase
    {
        [Required]
        [MaxLength(255)]
        public string AnswerText { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
        public bool ChosenByUser { get; set; }
    }
}

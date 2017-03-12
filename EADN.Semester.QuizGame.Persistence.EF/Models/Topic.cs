using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class Topic : QuizBase
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}

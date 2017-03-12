using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class Question : QuizBase
    {
        public ICollection<Topic> Topics { get; set; }

        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        public Question()
        {
            Topics = new HashSet<Topic>();
        }
    }
}

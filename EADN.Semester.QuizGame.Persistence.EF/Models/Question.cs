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
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public Question()
        {
            Topics = new HashSet<Topic>();
        }
    }
}

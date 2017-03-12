using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence.EF.Models
{
    public class AdminUser : User
    {
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string Password { get;set;}
    }
}

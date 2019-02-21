using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class UserEntity : BaseEntity {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public virtual List<ProjectLogEntity> ProjectLogs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class CompanyEntity: BaseEntity {
        [Required]
        public string Name { get; set; } 

        public string Description { get; set; }

        public string WebSite { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public virtual List<ProjectEntity> Projects { get; set; }
    }
}

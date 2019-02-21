using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class ProjectEntity: BaseEntity {
        [Required]
        public string Name { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsInProgress { get; set; }



        public CompanyEntity Company { get; set; }
        public virtual List<ProjectLogEntity> ProjectLogs { get; set; }
    }
}


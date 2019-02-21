using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class ProjectLogEntity: BaseEntity {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public ProjectEntity Project { get; set; }
        public UserEntity User { get; set; }
        public virtual List<ScreenShotEntity> ScreenShots { get; set; }
    }
}

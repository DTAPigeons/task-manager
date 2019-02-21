using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class ScreenShotEntity:BaseEntity {
        public string Location { get; set; }
        public DateTime TimeTaken { get; set; }
        [ForeignKey("ProjectLog")]
        public int ProjectLogId { get; set; }

        public ProjectLogEntity ProjectLog { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess {
    class TaskManagerContext:  DbContext{
       public TaskManagerContext() : base() { }

        DbSet<UserEntity> Users { get; set; }
        DbSet<CompanyEntity> Companies { get; set; }
        DbSet<ProjectEntity> Projects { get; set; }
        DbSet<ProjectLogEntity> ProjectLogs { get; set; }
        DbSet<ScreenShotEntity> ScreenShots { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities {
    class BaseEntity {
        [Key]
        public int ID { get; set; }

        public BaseEntity() {

        }
    }
}

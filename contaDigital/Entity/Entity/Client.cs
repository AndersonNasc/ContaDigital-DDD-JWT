using Entity.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    [Table("TB_CLIENT")]
    public class Client: Validation
    {
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("CPF")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Column("FullName")]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Column("Agency")]
        [MaxLength(255)]
        public string Agency { get; set; }

        [Column("Account")]
        [MaxLength(255)]
        public string Account { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

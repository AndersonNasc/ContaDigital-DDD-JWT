using Entity.Enums;
using Entity.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    [Table("TB_ACCOUNT")]
    public class Account: Validation
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("NumberAccount")]
        public string NumberAccount { get; set; }

        [Column("TipoConta")]
        public TypeAccount TipoConta { get; set; }

        [Column("Bank")]
        public string Bank { get; set; }

        [Column("Agency")]
        public string Agency { get; set; }

        [Column("Balance")]
        public decimal Balance { get; set; }

        [Column("DateOpenAccount")]
        public DateTime DateOpenAccount  { get; set; }

        [Column("DateSetBanlance")]
        public DateTime DateSetBanlance { get; set; }

        [Column("OpenDate")]
        public DateTime OpenDate { get; set; }

        [Column("StatesAccount")]
        public StatusAccount StatesAccount { get; set; }
    }
}

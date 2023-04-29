using Entity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class ApplicationUser: IdentityUser
    {
        [Column("USR_IDADE")]
        public int Age { get; set; }

        [Column("USR_CELULAR")]
        public string Phone { get; set; }

        [Column("USR_TIPO")]
        public TypeUser? Tipo { get; set; }
    }
}

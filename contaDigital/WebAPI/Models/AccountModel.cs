using Entity.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class AccountModel
    {
        public Guid Id { get; set; }

        public string NumberAccount { get; set; }

        public int TipoConta { get; set; }

        public string Bank { get; set; }

        public string Agency { get; set; }

        public string Balance { get; set; }        
    }
}

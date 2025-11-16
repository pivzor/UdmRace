using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdmurtRace.Domain.Entities
{
    public class ClientEntity
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SurName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public List<SaleEntity> Sales = new List<SaleEntity>();
    }
}

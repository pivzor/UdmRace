using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdmurtRace.Domain.Entities
{
    public class SaleEntity
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public string Status { get; set; }
        public string Notes { get; set; }

        public int ClientId { get; set; }
        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public RaceEntity Race { get; set; }

        [ForeignKey("ClientId")]
        public ClientEntity Client { get; set; }

    }
}

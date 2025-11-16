using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UdmurtRace.Domain.Entities
{
    public class RaceEntity
    {
        [Key]
        public int RaceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(10)]
        public string DepartureDate { get; set; }

        [Required]
        [MaxLength(5)]
        public string DepartureTime { get; set; }

        [Required]
        [Range(10,2)]
        public float PriceTicket { get; set; }

        [Required]
        public int Seats { get; set; }
        public string Description { get; set; }

        public List<SaleEntity> Sales { get; set; } = new List<SaleEntity>();
    }
}

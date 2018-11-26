using Biob.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biob.Data.Models
{
    [Table("Tickets")]
    public class Ticket : DeleteableModelBase<Guid>
    {
        //Fields:
        
        //Todo when customer is added:
        //[ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [ForeignKey("Showtime")]
        public Guid ShowtimeId { get; set; }
        //Should only have ShowTime as that includes Hall:
        //[ForeignKey("Hall")]
        //public Guid HallId { get; set; }
        [ForeignKey("Seat")]
        public Guid SeatId { get; set; }
        public bool Reserved { get; set; }
        public bool Paid { get; set; }
        public int Price { get; set; }

        //Foreign key:
        //public Customer Customer { get; set; }
        public Showtime Showtime { get; set; }
        //public Hall Hall { get; set; }
        public Seat Seat { get; set; }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models
{
    public class BidHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Display(Name = "User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey("Listing")]
        [Display(Name = "Listing")]
        public int ListingId { get; set; }

        public Listing Listing { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
    }
}

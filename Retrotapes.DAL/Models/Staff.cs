using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Retrotapes.DAL.Models
{
    [Table("staff")]
    public partial class Staff
    {
        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }

        [Required]
        [Column("first_name")]
        [StringLength(45)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column("last_name")]
        [StringLength(45)]
        public string LastName { get; set; } = null!;

        [Column("address_id")]
        public int AddressId { get; set; }

        [Column("picture")]
        public byte[]? Picture { get; set; }

        [Column("email")]
        [StringLength(50)]
        public string? Email { get; set; }

        [Column("store_id")]
        public int StoreId { get; set; }

        [Column("active")]
        public bool Active { get; set; }  // If using tinyint(1) for boolean

        [Required]
        [Column("username")]
        [StringLength(16)]
        public string Username { get; set; } = null!;

        [Column("password")]
        [StringLength(40)]
        public string? Password { get; set; }

        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        // Navigation properties (can be handled with Fluent API if you prefer)
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; } = null!;

        [ForeignKey("StoreId")]
        public virtual Store? Store { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
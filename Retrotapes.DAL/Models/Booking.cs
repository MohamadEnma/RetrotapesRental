using Retrotapes.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [ForeignKey("Inventory")]
    public int InventoryId { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime BookingDate { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime RentalDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReturnDate { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal RentalAmount { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? LateFee { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Reserved"; // Reserved, Active, Returned, Overdue

    [ForeignKey("Staff")]
    public byte? StaffId { get; set; }

    public DateTime LastUpdate { get; set; } = DateTime.Now;

    // Navigation Properties
    public virtual Customer Customer { get; set; }
    public virtual Inventory Inventory { get; set; }
    public virtual Staff Staff { get; set; }
}
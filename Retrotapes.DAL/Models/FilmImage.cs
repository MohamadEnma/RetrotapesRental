using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Models
{
    public class FilmImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        [ForeignKey("Film")]
        public int FilmId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImageType { get; set; } // "Poster", "Thumbnail", "Banner", "Screenshot"

        [MaxLength(100)]
        public string AltText { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? FileSizeKB { get; set; }

        [MaxLength(10)]
        public string FileExtension { get; set; } // "jpg", "png", "webp"

        public int? Width { get; set; }
        public int? Height { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsPrimary { get; set; } = false; // Main poster/image

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual Film Film { get; set; }
    }
}

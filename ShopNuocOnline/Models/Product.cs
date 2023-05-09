namespace ShopNuocOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double ProductPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Image { get; set; }

        public DateTime ProductDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}

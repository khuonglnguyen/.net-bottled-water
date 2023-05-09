
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ShopNuocOnline.Models
{
    [Table("AspNetUsers")]
    public partial class AspNetUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class DetailViewModel
    {
      //  [ForeignKey("DetailViewModel")]
      [Key]
        public Animal? Animal{ get; set; }
        public IEnumerable<Comment>? AnimalComments { get; set; }
        public string? AnimalCategory { get; set; }
    }
}

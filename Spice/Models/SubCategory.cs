using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class SubCategory
    {
        //primary key
        [Key]
        public int Id { get; set; }

        [Display(Name = "SubCategory Name")]
        [Required]
        public string Name { get; set; }
        
        //reference
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        //foreign key should be virtual
        //for LINQ include statement
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}

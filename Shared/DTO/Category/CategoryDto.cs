using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Category
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name Required")]
        public required string Name { get; set; }
    }
}

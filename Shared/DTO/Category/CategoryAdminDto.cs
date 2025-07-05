using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Category
{
    public class CategoryAdminDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public ICollection<TutorRequest> TutorRequestList { get; set; } = new List<TutorRequest>();
    }
}

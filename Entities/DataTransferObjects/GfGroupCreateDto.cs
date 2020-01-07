using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class GfGroupCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }
    }
}

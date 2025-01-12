using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? Status { get; set; }
        [Display(Name = "Date Of Entry")]
        [DataType(DataType.Date)]
        public DateTime DateOfEntry { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Animals.Models
{
    public class Animal
    {
        private string desc;
        public int Id { get; set; }
        [Required(ErrorMessage = "Name value is reqiered")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description value is reqiered")]
        public string Description { get {return desc; } set { desc = value ?? ""; } }
        [Required(ErrorMessage = "Category value is reqiered")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Area value is reqiered")]
        public string Area { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceRazor.Models;

public class Category
{
    [Key] // Indicates this is the primary key
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    [StringLength(100, ErrorMessage = "Name must be 100 characters or less")]
    [Display(Name = "Name of the Category")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Display Order is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Display Order must be higher than 0")]
    [Display(Name = "Display Order")]
    public int DisplayOrder { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now; // Current Default Date
}

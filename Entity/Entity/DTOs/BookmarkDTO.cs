namespace Entity.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookmarkDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of a ticket!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter an URL!")]
        [StringLength(500, ErrorMessage ="URL cannot contain more than 500 characters!")]
        public string URL { get; set; }

        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "You have to add a Category ID!")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID needs to be greater than 0!")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "You have to enter date!")]
        public DateTime CreateDate { get; set; }

        public virtual Category Category { get; set; }

    }
}

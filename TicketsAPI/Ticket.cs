using System.ComponentModel.DataAnnotations;

namespace webd3000Api
{
    public class Ticket
    {
        [Required(ErrorMessage = "Concert ID is required.")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must be 100 characters or less.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [MaxLength(20, ErrorMessage = "Phone number must be 20 characters or less.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Invalid credit card format.")]
        [MaxLength(19, ErrorMessage = "Credit card number must be 19 characters or less.")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date is required.")]
        [MaxLength(7, ErrorMessage = "Expiration date must be 7 characters or less.")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required.")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security code must be 3 or 4 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "Address must be 100 characters or less.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(50, ErrorMessage = "City must be 50 characters or less.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [MaxLength(50, ErrorMessage = "Province must be 50 characters or less.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [MaxLength(10, ErrorMessage = "Postal code must be 10 characters or less.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(50, ErrorMessage = "Country must be 50 characters or less.")]
        public string Country { get; set; } = string.Empty;
    }
}

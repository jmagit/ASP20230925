using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoFW.Models {
    class CustomerMetadata {
        [StringLength(8)]
        [DisplayName("Tratamiento")]
        public string Title { get; set; }
        [Display(Name = "Nombre")]
        [Required, StringLength(maximumLength: 50, MinimumLength = 2)]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "Debe estar en mayúsculas")]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string MiddleName { get; set; }
        [Required, StringLength(maximumLength: 50, MinimumLength = 2)]
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [StringLength(50), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public System.DateTime ModifiedDate { get; set; }
    }

    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer : IValidatableObject {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if(ModifiedDate.Date.CompareTo(DateTime.Now) > 0)
                yield return new ValidationResult("Tiene que ser una fecha pasada", new[] { nameof(ModifiedDate) });
        }
        public IEnumerable<ValidationResult> GetValidationErrors() {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this,
                      context,
                      validationResults,
                      true);
            return validationResults;
        }

        public bool IsValid { get => GetValidationErrors().Count() == 0; }
        public bool IsInvalid { get => !IsValid; }

    }

}
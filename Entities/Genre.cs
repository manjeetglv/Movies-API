using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Genre: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Following validtion is class specific validation and is called after the all the attribute validations like [Require], [Url] etc.
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstLetter = Name[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("First letter of genre name should be capital", new string[]{nameof(Name)});
                }
            }
        }
    }
}
